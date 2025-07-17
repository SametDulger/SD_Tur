using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
{
    public class CustomerDistributionService : ICustomerDistributionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerDistributionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDistributionDto>> GetAllAsync()
        {
            var customerDistributions = await _unitOfWork.CustomerDistributions.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDistributionDto>>(customerDistributions);
        }

        public async Task<CustomerDistributionDto> GetByIdAsync(int id)
        {
            var customerDistribution = await _unitOfWork.CustomerDistributions.GetByIdAsync(id);
            return _mapper.Map<CustomerDistributionDto>(customerDistribution);
        }

        public async Task<IEnumerable<CustomerDistributionDto>> GetByTourScheduleAsync(int tourScheduleId)
        {
            var customerDistributions = await _unitOfWork.CustomerDistributions.GetByTourScheduleAsync(tourScheduleId);
            return _mapper.Map<IEnumerable<CustomerDistributionDto>>(customerDistributions);
        }

        public async Task<IEnumerable<CustomerDistributionDto>> GetByBusAsync(int busId)
        {
            var customerDistributions = await _unitOfWork.CustomerDistributions.GetByBusAsync(busId);
            return _mapper.Map<IEnumerable<CustomerDistributionDto>>(customerDistributions);
        }

        public async Task<IEnumerable<CustomerDistributionDto>> GetByTicketAsync(int ticketId)
        {
            var customerDistributions = await _unitOfWork.CustomerDistributions.GetByTicketAsync(ticketId);
            return _mapper.Map<IEnumerable<CustomerDistributionDto>>(customerDistributions);
        }

        public async Task<IEnumerable<CustomerDistributionDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var customerDistributions = await _unitOfWork.CustomerDistributions.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<CustomerDistributionDto>>(customerDistributions);
        }

        public async Task<IEnumerable<CustomerDistributionDto>> GetByStatusAsync(string status)
        {
            var customerDistributions = await _unitOfWork.CustomerDistributions.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<CustomerDistributionDto>>(customerDistributions);
        }

        public async Task<CustomerDistributionDto> CreateAsync(CreateCustomerDistributionDto createDto)
        {
            var customerDistribution = _mapper.Map<CustomerDistribution>(createDto);
            customerDistribution.IsActive = true;
            
            await _unitOfWork.CustomerDistributions.AddAsync(customerDistribution);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CustomerDistributionDto>(customerDistribution);
        }

        public async Task<CustomerDistributionDto> UpdateAsync(UpdateCustomerDistributionDto updateDto)
        {
            var existingCustomerDistribution = await _unitOfWork.CustomerDistributions.GetByIdAsync(updateDto.Id);
            if (existingCustomerDistribution == null)
                throw new ArgumentException("Customer distribution not found");
            
            _mapper.Map(updateDto, existingCustomerDistribution);
            
            await _unitOfWork.CustomerDistributions.UpdateAsync(existingCustomerDistribution);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CustomerDistributionDto>(existingCustomerDistribution);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CustomerDistributions.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 