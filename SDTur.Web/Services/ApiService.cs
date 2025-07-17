using System.Text;
using System.Text.Json;
using SDTur.Application.DTOs;

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
        public async Task<IEnumerable<TourDto>> GetToursAsync()
        {
            var response = await _httpClient.GetAsync("api/tours");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TourDto>>(content, _jsonOptions) ?? new List<TourDto>();
        }

        public async Task<IEnumerable<TourDto>> GetActiveToursAsync()
        {
            var response = await _httpClient.GetAsync("api/tours/active");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TourDto>>(content, _jsonOptions) ?? new List<TourDto>();
        }

        public async Task<TourDto> GetTourByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/tours/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TourDto>(content, _jsonOptions);
            }
            return null;
        }

        public async Task<TourDto> CreateTourAsync(CreateTourDto createTourDto)
        {
            var json = JsonSerializer.Serialize(createTourDto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/tours", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TourDto>(responseContent, _jsonOptions);
        }

        public async Task<TourDto> UpdateTourAsync(UpdateTourDto updateTourDto)
        {
            var json = JsonSerializer.Serialize(updateTourDto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/tours/{updateTourDto.Id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TourDto>(responseContent, _jsonOptions);
        }

        public async Task DeleteTourAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/tours/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Ticket methods
        public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
        {
            var response = await _httpClient.GetAsync("api/tickets");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketDto>>(content, _jsonOptions) ?? new List<TicketDto>();
        }

        public async Task<TicketDto> GetTicketByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/tickets/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TicketDto>(content, _jsonOptions);
            }
            return null;
        }

        public async Task<TicketDto> GetTicketByNumberAsync(string ticketNumber)
        {
            var response = await _httpClient.GetAsync($"api/tickets/number/{ticketNumber}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TicketDto>(content, _jsonOptions);
            }
            return null;
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByTourDateAsync(DateTime tourDate)
        {
            var response = await _httpClient.GetAsync($"api/tickets/tour-date/{tourDate:yyyy-MM-dd}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketDto>>(content, _jsonOptions) ?? new List<TicketDto>();
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByBranchAsync(int branchId)
        {
            var response = await _httpClient.GetAsync($"api/tickets/branch/{branchId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketDto>>(content, _jsonOptions) ?? new List<TicketDto>();
        }

        public async Task<IEnumerable<TicketDto>> GetPassTicketsAsync()
        {
            var response = await _httpClient.GetAsync("api/tickets/pass");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TicketDto>>(content, _jsonOptions) ?? new List<TicketDto>();
        }

        public async Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto)
        {
            var json = JsonSerializer.Serialize(createTicketDto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/tickets", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TicketDto>(responseContent, _jsonOptions);
        }

        public async Task<TicketDto> UpdateTicketAsync(UpdateTicketDto updateTicketDto)
        {
            var json = JsonSerializer.Serialize(updateTicketDto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/tickets/{updateTicketDto.Id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TicketDto>(responseContent, _jsonOptions);
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

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, _jsonOptions);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data)
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