using AutoMapper;
using SDTur.Application.DTOs.Master.Currency;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CurrencyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllAsync()
        {
            var currencies = await _unitOfWork.Currencies.GetAllAsync();
            return _mapper.Map<IEnumerable<CurrencyDto>>(currencies);
        }

        public async Task<IEnumerable<CurrencyDto>> GetActiveAsync()
        {
            var currencies = await _unitOfWork.Currencies.GetAllAsync();
            return _mapper.Map<IEnumerable<CurrencyDto>>(currencies.Where(c => c.IsActive));
        }

        public async Task<CurrencyDto> GetByIdAsync(int id)
        {
            var currency = await _unitOfWork.Currencies.GetByIdAsync(id);
            return _mapper.Map<CurrencyDto>(currency);
        }

        public async Task<CurrencyDto> CreateAsync(CreateCurrencyDto createDto)
        {
            var currency = _mapper.Map<Currency>(createDto);
            currency.IsActive = true;
            
            await _unitOfWork.Currencies.AddAsync(currency);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CurrencyDto>(currency);
        }

        public async Task<CurrencyDto> UpdateAsync(UpdateCurrencyDto updateDto)
        {
            var currency = await _unitOfWork.Currencies.GetByIdAsync(updateDto.Id);
            if (currency == null)
                return null;

            _mapper.Map(updateDto, currency);
            await _unitOfWork.Currencies.UpdateAsync(currency);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<CurrencyDto>(currency);
        }

        public async Task DeleteAsync(int id)
        {
            var currency = await _unitOfWork.Currencies.GetByIdAsync(id);
            if (currency == null)
                return;

            await _unitOfWork.Currencies.DeleteAsync(currency.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 