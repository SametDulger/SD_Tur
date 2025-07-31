using AutoMapper;
using SDTur.Application.DTOs.Financial.Account;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.Application.Services.Financial.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            var accounts = await _unitOfWork.Accounts.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }

        public async Task<IEnumerable<AccountDto>> GetActiveAsync()
        {
            var accounts = await _unitOfWork.Accounts.GetActiveAccountsAsync();
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }

        public async Task<AccountDto> GetByIdAsync(int id)
        {
            var account = await _unitOfWork.Accounts.GetByIdAsync(id);
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> GetWithTransactionsAsync(int id)
        {
            var account = await _unitOfWork.Accounts.GetAccountWithTransactionsAsync(id);
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<IEnumerable<AccountDto>> GetByAccountTypeAsync(string accountType)
        {
            var accounts = await _unitOfWork.Accounts.GetByAccountTypeAsync(accountType);
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }

        public async Task<decimal> GetAccountBalanceAsync(int accountId)
        {
            return await _unitOfWork.Accounts.GetAccountBalanceAsync(accountId);
        }

        public async Task<AccountDto> CreateAsync(CreateAccountDto createDto)
        {
            var account = _mapper.Map<Account>(createDto);
            account.IsActive = true;
            
            await _unitOfWork.Accounts.AddAsync(account);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> UpdateAsync(UpdateAccountDto updateDto)
        {
            var account = await _unitOfWork.Accounts.GetByIdAsync(updateDto.Id);
            if (account == null)
                throw new ArgumentException("Cari hesap bulunamadı");
            
            _mapper.Map(updateDto, account);
            
            await _unitOfWork.Accounts.UpdateAsync(account);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<AccountDto>(account);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Accounts.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 