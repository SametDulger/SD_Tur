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

        public async Task<TicketDto?> GetTicketByIdAsync(int id)
        {
            var ticket = await _unitOfWork.Tickets.GetTicketWithDetailsAsync(id);
            return ticket != null ? _mapper.Map<TicketDto>(ticket) : null;
        }

        public async Task<TicketDto?> GetTicketByNumberAsync(string ticketNumber)
        {
            var tickets = await _unitOfWork.Tickets.FindAsync(t => t.TicketNumber == ticketNumber);
            var ticket = tickets.FirstOrDefault();
            return ticket != null ? _mapper.Map<TicketDto>(ticket) : null;
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

        public async Task<TicketDto?> CreateAsync(CreateTicketDto createDto)
        {
            var entity = _mapper.Map<Ticket>(createDto);
            var created = await _unitOfWork.Tickets.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TicketDto>(created);
        }

        public async Task<TicketDto?> UpdateAsync(UpdateTicketDto updateDto)
        {
            var entity = await _unitOfWork.Tickets.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Tickets.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TicketDto>(updated);
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