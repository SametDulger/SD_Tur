using System.Text;
using System.Text.Json;
using SDTur.Web.Models;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Models.Tour.Operations;

namespace SDTur.Web.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // Tour methods
        public async Task<IEnumerable<TourViewModel>> GetToursAsync()
        {
            var response = await _httpClient.GetAsync("api/tours");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TourViewModel>>(content, _jsonOptions) ?? new List<TourViewModel>();
        }

        public async Task<IEnumerable<TourViewModel>> GetActiveToursAsync()
        {
            var response = await _httpClient.GetAsync("api/tours/active");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TourViewModel>>(content, _jsonOptions) ?? new List<TourViewModel>();
        }

        public async Task<TourViewModel?> GetTourByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/tours/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TourViewModel>(content, _jsonOptions);
            }
            return null;
        }

        public async Task<TourViewModel> CreateTourAsync(TourCreateViewModel createTourViewModel)
        {
            var json = JsonSerializer.Serialize(createTourViewModel, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/tours", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TourViewModel>(responseContent, _jsonOptions)!;
        }

        public async Task<TourViewModel> UpdateTourAsync(TourEditViewModel updateTourViewModel)
        {
            var json = JsonSerializer.Serialize(updateTourViewModel, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/tours/{updateTourViewModel.Id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TourViewModel>(responseContent, _jsonOptions)!;
        }

        public async Task DeleteTourAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/tours/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Ticket methods
        public async Task<IEnumerable<TicketViewModel>> GetTicketsAsync()
        {
            var response = await _httpClient.GetAsync("api/tickets");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketViewModel>>(content, _jsonOptions) ?? new List<TicketViewModel>();
        }

        public async Task<TicketViewModel?> GetTicketByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/tickets/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TicketViewModel>(content, _jsonOptions);
            }
            return null;
        }

        public async Task<TicketViewModel?> GetTicketByNumberAsync(string ticketNumber)
        {
            var response = await _httpClient.GetAsync($"api/tickets/number/{ticketNumber}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TicketViewModel>(content, _jsonOptions);
            }
            return null;
        }

        public async Task<IEnumerable<TicketViewModel>> GetTicketsByTourDateAsync(DateTime tourDate)
        {
            var response = await _httpClient.GetAsync($"api/tickets/tour-date/{tourDate:yyyy-MM-dd}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketViewModel>>(content, _jsonOptions) ?? new List<TicketViewModel>();
        }

        public async Task<IEnumerable<TicketViewModel>> GetTicketsByBranchAsync(int branchId)
        {
            var response = await _httpClient.GetAsync($"api/tickets/branch/{branchId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketViewModel>>(content, _jsonOptions) ?? new List<TicketViewModel>();
        }

        public async Task<IEnumerable<TicketViewModel>> GetPassTicketsAsync()
        {
            var response = await _httpClient.GetAsync("api/tickets/pass");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketViewModel>>(content, _jsonOptions) ?? new List<TicketViewModel>();
        }

        public async Task<TicketViewModel> CreateTicketAsync(TicketCreateViewModel createTicketViewModel)
        {
            var json = JsonSerializer.Serialize(createTicketViewModel, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/tickets", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TicketViewModel>(responseContent, _jsonOptions)!;
        }

        public async Task<TicketViewModel> UpdateTicketAsync(TicketEditViewModel updateTicketViewModel)
        {
            var json = JsonSerializer.Serialize(updateTicketViewModel, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/tickets/{updateTicketViewModel.Id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TicketViewModel>(responseContent, _jsonOptions)!;
        }

        public async Task DeleteTicketAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/tickets/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task CancelTicketAsync(int id)
        {
            var response = await _httpClient.PostAsync($"api/tickets/{id}/cancel", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> GenerateTicketNumberAsync()
        {
            var response = await _httpClient.GetAsync("api/tickets/generate-number");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, _jsonOptions);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
        }

        public async Task DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
} 