using AutoMapper;
using SDTur.Application.DTOs.Financial.AccountTransaction;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.Application.Services.Financial.Implementations
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountTransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountTransactionDto>> GetAllAsync()
        {
            var accountTransactions = await _unitOfWork.AccountTransactions.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountTransactionDto>>(accountTransactions);
        }

        public async Task<AccountTransactionDto> GetByIdAsync(int id)
        {
            var accountTransaction = await _unitOfWork.AccountTransactions.GetByIdAsync(id);
            return _mapper.Map<AccountTransactionDto>(accountTransaction);
        }

        public async Task<AccountTransactionDto> CreateAsync(CreateAccountTransactionDto createDto)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(createDto);
            accountTransaction.IsActive = true;
            
            await _unitOfWork.AccountTransactions.AddAsync(accountTransaction);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<AccountTransactionDto>(accountTransaction);
        }

        public async Task<AccountTransactionDto> UpdateAsync(UpdateAccountTransactionDto updateDto)
        {
            var accountTransaction = await _unitOfWork.AccountTransactions.GetByIdAsync(updateDto.Id);
            if (accountTransaction == null)
                throw new ArgumentException("Hesap işlemi bulunamadı");

            _mapper.Map(updateDto, accountTransaction);
            
            await _unitOfWork.AccountTransactions.UpdateAsync(accountTransaction);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<AccountTransactionDto>(accountTransaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.AccountTransactions.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<AccountTransactionDto>> GetByPassCompanyAsync(int passCompanyId)
        {
            var accountTransactions = await _unitOfWork.AccountTransactions.GetTransactionsByPassCompanyAsync(passCompanyId);
            return _mapper.Map<IEnumerable<AccountTransactionDto>>(accountTransactions);
        }

        public async Task<IEnumerable<AccountTransactionDto>> GetByTourScheduleAsync(int tourScheduleId)
        {
            var accountTransactions = await _unitOfWork.AccountTransactions.GetTransactionsByTourScheduleAsync(tourScheduleId);
            return _mapper.Map<IEnumerable<AccountTransactionDto>>(accountTransactions);
        }

        public async Task<IEnumerable<AccountTransactionDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var accountTransactions = await _unitOfWork.AccountTransactions.GetTransactionsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<AccountTransactionDto>>(accountTransactions);
        }
    }
} 