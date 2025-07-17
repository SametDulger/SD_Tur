using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExchangeRateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExchangeRateDto>> GetAllAsync()
        {
            var exchangeRates = await _unitOfWork.ExchangeRates.GetAllAsync();
            return _mapper.Map<IEnumerable<ExchangeRateDto>>(exchangeRates);
        }

        public async Task<ExchangeRateDto> GetByIdAsync(int id)
        {
            var exchangeRate = await _unitOfWork.ExchangeRates.GetByIdAsync(id);
            return _mapper.Map<ExchangeRateDto>(exchangeRate);
        }

        public async Task<ExchangeRateDto> CreateAsync(CreateExchangeRateDto createDto)
        {
            var exchangeRate = _mapper.Map<ExchangeRate>(createDto);
            exchangeRate.IsActive = true;
            
            await _unitOfWork.ExchangeRates.AddAsync(exchangeRate);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<ExchangeRateDto>(exchangeRate);
        }

        public async Task<ExchangeRateDto> UpdateAsync(UpdateExchangeRateDto updateDto)
        {
            var exchangeRate = await _unitOfWork.ExchangeRates.GetByIdAsync(updateDto.Id);
            if (exchangeRate == null)
                throw new ArgumentException("Döviz kuru bulunamadı");

            _mapper.Map(updateDto, exchangeRate);
            
            await _unitOfWork.ExchangeRates.UpdateAsync(exchangeRate);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<ExchangeRateDto>(exchangeRate);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ExchangeRates.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ExchangeRateDto> GetLatestRateAsync(string fromCurrency, string toCurrency)
        {
            var exchangeRate = await _unitOfWork.ExchangeRates.GetLatestRateAsync(fromCurrency, toCurrency);
            return _mapper.Map<ExchangeRateDto>(exchangeRate);
        }

        public async Task<IEnumerable<ExchangeRateDto>> GetRatesByDateAsync(DateTime date)
        {
            var exchangeRates = await _unitOfWork.ExchangeRates.GetRatesByDateAsync(date);
            return _mapper.Map<IEnumerable<ExchangeRateDto>>(exchangeRates);
        }

        public async Task<IEnumerable<ExchangeRateDto>> GetRatesByCurrencyAsync(string currency)
        {
            var exchangeRates = await _unitOfWork.ExchangeRates.GetRatesByCurrencyAsync(currency);
            return _mapper.Map<IEnumerable<ExchangeRateDto>>(exchangeRates);
        }
    }
} 