using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SDTur.Application.DTOs.Tour.Ticket;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using System.Linq;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync()
        {
            var tickets = await _unitOfWork.Tickets.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<TicketDto> GetTicketByIdAsync(int id)
        {
            var ticket = await _unitOfWork.Tickets.GetTicketWithDetailsAsync(id);
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<TicketDto> GetTicketByNumberAsync(string ticketNumber)
        {
            var tickets = await _unitOfWork.Tickets.FindAsync(t => t.TicketNumber == ticketNumber);
            var ticket = tickets.FirstOrDefault();
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByTourDateAsync(DateTime tourDate)
        {
            var tickets = await _unitOfWork.Tickets.GetTicketsByTourDateAsync(tourDate);
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByBranchAsync(int branchId)
        {
            var tickets = await _unitOfWork.Tickets.GetTicketsByBranchAsync(branchId);
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<IEnumerable<TicketDto>> GetPassTicketsAsync()
        {
            var tickets = await _unitOfWork.Tickets.GetPassTicketsAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto)
        {
            var ticket = _mapper.Map<Ticket>(createTicketDto);
            
            // Generate ticket number
            ticket.TicketNumber = await _unitOfWork.Tickets.GenerateTicketNumberAsync();
            
            // Calculate rest amount
            ticket.RestAmount = ticket.TotalAmount - ticket.PaidAmount;
            
            var createdTicket = await _unitOfWork.Tickets.AddAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TicketDto>(createdTicket);
        }

        public async Task<TicketDto> UpdateTicketAsync(UpdateTicketDto updateTicketDto)
        {
            var existingTicket = await _unitOfWork.Tickets.GetByIdAsync(updateTicketDto.Id);
            if (existingTicket == null)
                return null;

            _mapper.Map(updateTicketDto, existingTicket);
            existingTicket.RestAmount = existingTicket.TotalAmount - existingTicket.PaidAmount;
            
            var updatedTicket = await _unitOfWork.Tickets.UpdateAsync(existingTicket);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TicketDto>(updatedTicket);
        }

        public async Task CancelTicketAsync(int id)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);
            if (ticket != null)
            {
                ticket.IsCancelled = true;
                await _unitOfWork.Tickets.UpdateAsync(ticket);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<string> GenerateTicketNumberAsync()
        {
            return await _unitOfWork.Tickets.GenerateTicketNumberAsync();
        }
    }
} 