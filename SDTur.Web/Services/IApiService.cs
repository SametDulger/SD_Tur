using SDTur.Application.DTOs;

namespace SDTur.Web.Services
{
    public interface IApiService
    {
        Task<IEnumerable<TourDto>> GetToursAsync();
        Task<IEnumerable<TourDto>> GetActiveToursAsync();
        Task<TourDto> GetTourByIdAsync(int id);
        Task<TourDto> CreateTourAsync(CreateTourDto createTourDto);
        Task<TourDto> UpdateTourAsync(UpdateTourDto updateTourDto);
        Task DeleteTourAsync(int id);

        Task<IEnumerable<TicketDto>> GetTicketsAsync();
        Task<TicketDto> GetTicketByIdAsync(int id);
        Task<TicketDto> GetTicketByNumberAsync(string ticketNumber);
        Task<IEnumerable<TicketDto>> GetTicketsByTourDateAsync(DateTime tourDate);
        Task<IEnumerable<TicketDto>> GetTicketsByBranchAsync(int branchId);
        Task<IEnumerable<TicketDto>> GetPassTicketsAsync();
        Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto);
        Task<TicketDto> UpdateTicketAsync(UpdateTicketDto updateTicketDto);
        Task DeleteTicketAsync(int id);
        Task CancelTicketAsync(int id);
        Task<string> GenerateTicketNumberAsync();
        Task<T> GetAsync<T>(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data);
        Task DeleteAsync(string url);
    }
} 