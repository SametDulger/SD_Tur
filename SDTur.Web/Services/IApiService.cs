using SDTur.Web.Models;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Models.Tour.Operations;

namespace SDTur.Web.Services
{
    public interface IApiService
    {
        Task<IEnumerable<TourViewModel>> GetToursAsync();
        Task<IEnumerable<TourViewModel>> GetActiveToursAsync();
        Task<TourViewModel?> GetTourByIdAsync(int id);
        Task<TourViewModel> CreateTourAsync(TourCreateViewModel createTourViewModel);
        Task<TourViewModel> UpdateTourAsync(TourEditViewModel updateTourViewModel);
        Task DeleteTourAsync(int id);

        Task<IEnumerable<TicketViewModel>> GetTicketsAsync();
        Task<TicketViewModel?> GetTicketByIdAsync(int id);
        Task<TicketViewModel?> GetTicketByNumberAsync(string ticketNumber);
        Task<IEnumerable<TicketViewModel>> GetTicketsByTourDateAsync(DateTime tourDate);
        Task<IEnumerable<TicketViewModel>> GetTicketsByBranchAsync(int branchId);
        Task<IEnumerable<TicketViewModel>> GetPassTicketsAsync();
        Task<TicketViewModel> CreateTicketAsync(TicketCreateViewModel createTicketViewModel);
        Task<TicketViewModel> UpdateTicketAsync(TicketEditViewModel updateTicketViewModel);
        Task DeleteTicketAsync(int id);
        Task CancelTicketAsync(int id);
        Task<string> GenerateTicketNumberAsync();
        Task<T?> GetAsync<T>(string url);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data);
        Task DeleteAsync(string url);
    }
} 