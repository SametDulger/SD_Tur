using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<CashDto> GetByIdAsync(int id)
        {
            var cashTransaction = await _unitOfWork.Cash.GetByIdAsync(id);
            return _mapper.Map<CashDto>(cashTransaction);
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

        public async Task<CashDto> CreateAsync(CreateCashDto createDto)
        {
            var cashTransaction = _mapper.Map<Cash>(createDto);
            cashTransaction.IsActive = true;
            
            await _unitOfWork.Cash.AddAsync(cashTransaction);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CashDto>(cashTransaction);
        }

        public async Task<CashDto> UpdateAsync(UpdateCashDto updateDto)
        {
            var cashTransaction = await _unitOfWork.Cash.GetByIdAsync(updateDto.Id);
            if (cashTransaction == null)
                throw new ArgumentException("Kasa işlemi bulunamadı");
            
            _mapper.Map(updateDto, cashTransaction);
            
            await _unitOfWork.Cash.UpdateAsync(cashTransaction);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CashDto>(cashTransaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Cash.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 