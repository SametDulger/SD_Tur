using AutoMapper;
using SDTur.Application.DTOs.Tour.CustomerDistribution;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
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

        public async Task<CustomerDistributionDto?> GetByIdAsync(int id)
        {
            var customerDistribution = await _unitOfWork.CustomerDistributions.GetByIdAsync(id);
            return customerDistribution != null ? _mapper.Map<CustomerDistributionDto>(customerDistribution) : null;
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

        public async Task<CustomerDistributionDto?> CreateAsync(CreateCustomerDistributionDto createDto)
        {
            var entity = _mapper.Map<CustomerDistribution>(createDto);
            var created = await _unitOfWork.CustomerDistributions.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CustomerDistributionDto>(created);
        }

        public async Task<CustomerDistributionDto?> UpdateAsync(UpdateCustomerDistributionDto updateDto)
        {
            var entity = await _unitOfWork.CustomerDistributions.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.CustomerDistributions.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CustomerDistributionDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var customerDistribution = await _unitOfWork.CustomerDistributions.GetByIdAsync(id);
            if (customerDistribution == null)
                return;

            await _unitOfWork.CustomerDistributions.DeleteAsync(customerDistribution.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 