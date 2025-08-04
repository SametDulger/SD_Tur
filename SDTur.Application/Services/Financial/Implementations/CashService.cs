using AutoMapper;
using SDTur.Application.DTOs.Financial.Cash;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.Application.Services.Financial.Implementations
{
    public class CashService : ICashService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CashService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CashDto>> GetAllAsync()
        {
            var cashTransactions = await _unitOfWork.Cash.GetAllAsync();
            return _mapper.Map<IEnumerable<CashDto>>(cashTransactions);
        }

        public async Task<CashDto?> GetByIdAsync(int id)
        {
            var cashTransaction = await _unitOfWork.Cash.GetByIdAsync(id);
            return cashTransaction != null ? _mapper.Map<CashDto>(cashTransaction) : null;
        }

        public async Task<IEnumerable<CashDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var cashTransactions = await _unitOfWork.Cash.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<CashDto>>(cashTransactions);
        }

        public async Task<IEnumerable<CashDto>> GetByTransactionTypeAsync(string transactionType)
        {
            var cashTransactions = await _unitOfWork.Cash.GetByTransactionTypeAsync(transactionType);
            return _mapper.Map<IEnumerable<CashDto>>(cashTransactions);
        }

        public async Task<decimal> GetTotalBalanceAsync(DateTime date, string currency)
        {
            return await _unitOfWork.Cash.GetTotalBalanceAsync(date, currency);
        }

        public async Task<CashDto?> CreateAsync(CreateCashDto createDto)
        {
            var entity = _mapper.Map<Cash>(createDto);
            var created = await _unitOfWork.Cash.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CashDto>(created);
        }

        public async Task<CashDto?> UpdateAsync(UpdateCashDto updateDto)
        {
            var entity = await _unitOfWork.Cash.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Cash.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CashDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Cash.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 