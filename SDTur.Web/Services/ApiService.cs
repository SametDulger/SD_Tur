using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using SDTur.Web.Models;
using SDTur.Web.Models.Financial.Accounts;
using SDTur.Web.Models.Financial.Cash;
using SDTur.Web.Models.Financial.Invoices;
using SDTur.Web.Models.Financial.Reports;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Models.Master.Branches;
using SDTur.Web.Models.Master.People;
using SDTur.Web.Models.Master.Transport;
using SDTur.Web.Models.Master.References;
using SDTur.Web.Models.Master.Locations;
using SDTur.Web.Models.Master.Accommodation;
using SDTur.Web.Models.Master.Pass;
using SDTur.Web.Models.System.Users;
using SDTur.Web.Models.System.Reports;
using SDTur.Web.Models.System.Logs;
using SDTur.Web.Models.Tour.Core;
using SDTur.Web.Models.Tour.Operations;
using SDTur.Web.Models.Tour.Financial;

namespace SDTur.Web.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        private void AddAuthorizationHeader()
        {
            var token = _httpContextAccessor.HttpContext?.Session.GetString("JWTToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        // Generic CRUD operations
        public async Task<T?> GetAsync<T>(string url)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, _jsonOptions);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            AddAuthorizationHeader();
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data)
        {
            AddAuthorizationHeader();
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
        }

        public async Task DeleteAsync(string url)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        // Financial - Accounts
        public async Task<IEnumerable<AccountViewModel>> GetAccountsAsync()
        {
            return await GetAsync<IEnumerable<AccountViewModel>>("api/accounts") ?? new List<AccountViewModel>();
        }

        public async Task<AccountViewModel?> GetAccountByIdAsync(int id)
        {
            return await GetAsync<AccountViewModel>($"api/accounts/{id}");
        }

        public async Task<AccountViewModel> CreateAccountAsync(AccountCreateViewModel model)
        {
            return await PostAsync<AccountCreateViewModel, AccountViewModel>("api/accounts", model) ?? new AccountViewModel();
        }

        public async Task<AccountViewModel> UpdateAccountAsync(AccountEditViewModel model)
        {
            return await PutAsync<AccountEditViewModel, AccountViewModel>($"api/accounts/{model.Id}", model) ?? new AccountViewModel();
        }

        public async Task DeleteAccountAsync(int id)
        {
            await DeleteAsync($"api/accounts/{id}");
        }

        // Financial - Account Transactions
        public async Task<IEnumerable<AccountTransactionViewModel>> GetAccountTransactionsAsync()
        {
            return await GetAsync<IEnumerable<AccountTransactionViewModel>>("api/accounttransactions") ?? new List<AccountTransactionViewModel>();
        }

        public async Task<AccountTransactionViewModel?> GetAccountTransactionByIdAsync(int id)
        {
            return await GetAsync<AccountTransactionViewModel>($"api/accounttransactions/{id}");
        }

        public async Task<AccountTransactionViewModel> CreateAccountTransactionAsync(AccountTransactionCreateViewModel model)
        {
            return await PostAsync<AccountTransactionCreateViewModel, AccountTransactionViewModel>("api/accounttransactions", model) ?? new AccountTransactionViewModel();
        }

        public async Task<AccountTransactionViewModel> UpdateAccountTransactionAsync(AccountTransactionEditViewModel model)
        {
            return await PutAsync<AccountTransactionEditViewModel, AccountTransactionViewModel>($"api/accounttransactions/{model.Id}", model) ?? new AccountTransactionViewModel();
        }

        public async Task DeleteAccountTransactionAsync(int id)
        {
            await DeleteAsync($"api/accounttransactions/{id}");
        }

        // Financial - Cash
        public async Task<IEnumerable<CashViewModel>> GetCashAsync()
        {
            return await GetAsync<IEnumerable<CashViewModel>>("api/cash") ?? new List<CashViewModel>();
        }

        public async Task<CashViewModel?> GetCashByIdAsync(int id)
        {
            return await GetAsync<CashViewModel>($"api/cash/{id}");
        }

        public async Task<CashViewModel> CreateCashAsync(CashCreateViewModel model)
        {
            return await PostAsync<CashCreateViewModel, CashViewModel>("api/cash", model) ?? new CashViewModel();
        }

        public async Task<CashViewModel> UpdateCashAsync(CashEditViewModel model)
        {
            return await PutAsync<CashEditViewModel, CashViewModel>($"api/cash/{model.Id}", model) ?? new CashViewModel();
        }

        public async Task DeleteCashAsync(int id)
        {
            await DeleteAsync($"api/cash/{id}");
        }

        // Financial - Invoices
        public async Task<IEnumerable<InvoiceViewModel>> GetInvoicesAsync()
        {
            return await GetAsync<IEnumerable<InvoiceViewModel>>("api/invoices") ?? new List<InvoiceViewModel>();
        }

        public async Task<InvoiceViewModel?> GetInvoiceByIdAsync(int id)
        {
            return await GetAsync<InvoiceViewModel>($"api/invoices/{id}");
        }

        public async Task<InvoiceViewModel> CreateInvoiceAsync(InvoiceCreateViewModel model)
        {
            return await PostAsync<InvoiceCreateViewModel, InvoiceViewModel>("api/invoices", model) ?? new InvoiceViewModel();
        }

        public async Task<InvoiceViewModel> UpdateInvoiceAsync(InvoiceEditViewModel model)
        {
            return await PutAsync<InvoiceEditViewModel, InvoiceViewModel>($"api/invoices/{model.Id}", model) ?? new InvoiceViewModel();
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            await DeleteAsync($"api/invoices/{id}");
        }

        // Financial - Invoice Details
        public async Task<IEnumerable<InvoiceDetailViewModel>> GetInvoiceDetailsAsync()
        {
            return await GetAsync<IEnumerable<InvoiceDetailViewModel>>("api/invoice-details") ?? new List<InvoiceDetailViewModel>();
        }

        public async Task<InvoiceDetailViewModel?> GetInvoiceDetailByIdAsync(int id)
        {
            return await GetAsync<InvoiceDetailViewModel>($"api/invoice-details/{id}");
        }

        public async Task<IEnumerable<InvoiceDetailViewModel>> GetInvoiceDetailsByInvoiceIdAsync(int invoiceId)
        {
            return await GetAsync<IEnumerable<InvoiceDetailViewModel>>($"api/invoice-details/by-invoice/{invoiceId}") ?? new List<InvoiceDetailViewModel>();
        }

        public async Task<InvoiceDetailViewModel> CreateInvoiceDetailAsync(InvoiceDetailCreateViewModel model)
        {
            return await PostAsync<InvoiceDetailCreateViewModel, InvoiceDetailViewModel>("api/invoice-details", model) ?? new InvoiceDetailViewModel();
        }

        public async Task<InvoiceDetailViewModel> UpdateInvoiceDetailAsync(InvoiceDetailEditViewModel model)
        {
            return await PutAsync<InvoiceDetailEditViewModel, InvoiceDetailViewModel>($"api/invoice-details/{model.Id}", model) ?? new InvoiceDetailViewModel();
        }

        public async Task DeleteInvoiceDetailAsync(int id)
        {
            await DeleteAsync($"api/invoice-details/{id}");
        }

        // Financial - Exchange Rates
        public async Task<IEnumerable<ExchangeRateViewModel>> GetExchangeRatesAsync()
        {
            return await GetAsync<IEnumerable<ExchangeRateViewModel>>("api/exchangerates") ?? new List<ExchangeRateViewModel>();
        }

        public async Task<ExchangeRateViewModel?> GetExchangeRateByIdAsync(int id)
        {
            return await GetAsync<ExchangeRateViewModel>($"api/exchangerates/{id}");
        }

        public async Task<ExchangeRateViewModel> CreateExchangeRateAsync(ExchangeRateCreateViewModel model)
        {
            return await PostAsync<ExchangeRateCreateViewModel, ExchangeRateViewModel>("api/exchangerates", model) ?? new ExchangeRateViewModel();
        }

        public async Task<ExchangeRateViewModel> UpdateExchangeRateAsync(ExchangeRateEditViewModel model)
        {
            return await PutAsync<ExchangeRateEditViewModel, ExchangeRateViewModel>($"api/exchangerates/{model.Id}", model) ?? new ExchangeRateViewModel();
        }

        public async Task DeleteExchangeRateAsync(int id)
        {
            await DeleteAsync($"api/exchangerates/{id}");
        }

        // Financial - Commission Calculations
        public async Task<IEnumerable<CommissionCalculationViewModel>> GetCommissionCalculationsAsync()
        {
            return await GetAsync<IEnumerable<CommissionCalculationViewModel>>("api/commissioncalculations") ?? new List<CommissionCalculationViewModel>();
        }

        public async Task<CommissionCalculationViewModel?> GetCommissionCalculationByIdAsync(int id)
        {
            return await GetAsync<CommissionCalculationViewModel>($"api/commissioncalculations/{id}");
        }

        public async Task<CommissionCalculationViewModel> CreateCommissionCalculationAsync(CommissionCalculationCreateViewModel model)
        {
            return await PostAsync<CommissionCalculationCreateViewModel, CommissionCalculationViewModel>("api/commissioncalculations", model) ?? new CommissionCalculationViewModel();
        }

        public async Task<CommissionCalculationViewModel> UpdateCommissionCalculationAsync(CommissionCalculationEditViewModel model)
        {
            return await PutAsync<CommissionCalculationEditViewModel, CommissionCalculationViewModel>($"api/commissioncalculations/{model.Id}", model) ?? new CommissionCalculationViewModel();
        }

        public async Task DeleteCommissionCalculationAsync(int id)
        {
            await DeleteAsync($"api/commissioncalculations/{id}");
        }

        // Financial - Financial Reports
        public async Task<IEnumerable<FinancialReportViewModel>> GetFinancialReportsAsync()
        {
            return await GetAsync<IEnumerable<FinancialReportViewModel>>("api/financialreports") ?? new List<FinancialReportViewModel>();
        }

        public async Task<FinancialReportViewModel?> GetFinancialReportByIdAsync(int id)
        {
            return await GetAsync<FinancialReportViewModel>($"api/financialreports/{id}");
        }

        public async Task<FinancialReportViewModel> CreateFinancialReportAsync(FinancialReportCreateViewModel model)
        {
            return await PostAsync<FinancialReportCreateViewModel, FinancialReportViewModel>("api/financialreports", model) ?? new FinancialReportViewModel();
        }

        public async Task<FinancialReportViewModel> UpdateFinancialReportAsync(FinancialReportEditViewModel model)
        {
            return await PutAsync<FinancialReportEditViewModel, FinancialReportViewModel>($"api/financialreports/{model.Id}", model) ?? new FinancialReportViewModel();
        }

        public async Task DeleteFinancialReportAsync(int id)
        {
            await DeleteAsync($"api/financialreports/{id}");
        }

        // Master - Branches
        public async Task<IEnumerable<BranchViewModel>> GetBranchesAsync()
        {
            return await GetAsync<IEnumerable<BranchViewModel>>("api/branches") ?? new List<BranchViewModel>();
        }

        public async Task<BranchViewModel?> GetBranchByIdAsync(int id)
        {
            return await GetAsync<BranchViewModel>($"api/branches/{id}");
        }

        public async Task<BranchViewModel> CreateBranchAsync(BranchCreateViewModel model)
        {
            return await PostAsync<BranchCreateViewModel, BranchViewModel>("api/branches", model) ?? new BranchViewModel();
        }

        public async Task<BranchViewModel> UpdateBranchAsync(BranchEditViewModel model)
        {
            return await PutAsync<BranchEditViewModel, BranchViewModel>($"api/branches/{model.Id}", model) ?? new BranchViewModel();
        }

        public async Task DeleteBranchAsync(int id)
        {
            await DeleteAsync($"api/branches/{id}");
        }

        // Master - Employees
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeesAsync()
        {
            return await GetAsync<IEnumerable<EmployeeViewModel>>("api/employees") ?? new List<EmployeeViewModel>();
        }

        public async Task<EmployeeViewModel?> GetEmployeeByIdAsync(int id)
        {
            return await GetAsync<EmployeeViewModel>($"api/employees/{id}");
        }

        public async Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeCreateViewModel model)
        {
            return await PostAsync<EmployeeCreateViewModel, EmployeeViewModel>("api/employees", model) ?? new EmployeeViewModel();
        }

        public async Task<EmployeeViewModel> UpdateEmployeeAsync(EmployeeEditViewModel model)
        {
            return await PutAsync<EmployeeEditViewModel, EmployeeViewModel>($"api/employees/{model.Id}", model) ?? new EmployeeViewModel();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await DeleteAsync($"api/employees/{id}");
        }

        // Master - Regions
        public async Task<IEnumerable<RegionViewModel>> GetRegionsAsync()
        {
            return await GetAsync<IEnumerable<RegionViewModel>>("api/regions") ?? new List<RegionViewModel>();
        }

        public async Task<RegionViewModel?> GetRegionByIdAsync(int id)
        {
            return await GetAsync<RegionViewModel>($"api/regions/{id}");
        }

        public async Task<RegionViewModel> CreateRegionAsync(RegionCreateViewModel model)
        {
            return await PostAsync<RegionCreateViewModel, RegionViewModel>("api/regions", model) ?? new RegionViewModel();
        }

        public async Task<RegionViewModel> UpdateRegionAsync(RegionEditViewModel model)
        {
            return await PutAsync<RegionEditViewModel, RegionViewModel>($"api/regions/{model.Id}", model) ?? new RegionViewModel();
        }

        public async Task DeleteRegionAsync(int id)
        {
            await DeleteAsync($"api/regions/{id}");
        }

        // Master - Hotels
        public async Task<IEnumerable<HotelViewModel>> GetHotelsAsync()
        {
            return await GetAsync<IEnumerable<HotelViewModel>>("api/hotels") ?? new List<HotelViewModel>();
        }

        public async Task<HotelViewModel?> GetHotelByIdAsync(int id)
        {
            return await GetAsync<HotelViewModel>($"api/hotels/{id}");
        }

        public async Task<HotelViewModel> CreateHotelAsync(HotelCreateViewModel model)
        {
            return await PostAsync<HotelCreateViewModel, HotelViewModel>("api/hotels", model) ?? new HotelViewModel();
        }

        public async Task<HotelViewModel> UpdateHotelAsync(HotelEditViewModel model)
        {
            return await PutAsync<HotelEditViewModel, HotelViewModel>($"api/hotels/{model.Id}", model) ?? new HotelViewModel();
        }

        public async Task DeleteHotelAsync(int id)
        {
            await DeleteAsync($"api/hotels/{id}");
        }

        // Master - Buses
        public async Task<IEnumerable<BusViewModel>> GetBusesAsync()
        {
            return await GetAsync<IEnumerable<BusViewModel>>("api/buses") ?? new List<BusViewModel>();
        }

        public async Task<BusViewModel?> GetBusByIdAsync(int id)
        {
            return await GetAsync<BusViewModel>($"api/buses/{id}");
        }

        public async Task<BusViewModel> CreateBusAsync(BusCreateViewModel model)
        {
            return await PostAsync<BusCreateViewModel, BusViewModel>("api/buses", model) ?? new BusViewModel();
        }

        public async Task<BusViewModel> UpdateBusAsync(BusEditViewModel model)
        {
            return await PutAsync<BusEditViewModel, BusViewModel>($"api/buses/{model.Id}", model) ?? new BusViewModel();
        }

        public async Task DeleteBusAsync(int id)
        {
            await DeleteAsync($"api/buses/{id}");
        }

        // Master - Currencies
        public async Task<IEnumerable<CurrencyViewModel>> GetCurrenciesAsync()
        {
            return await GetAsync<IEnumerable<CurrencyViewModel>>("api/currencies") ?? new List<CurrencyViewModel>();
        }

        public async Task<CurrencyViewModel?> GetCurrencyByIdAsync(int id)
        {
            return await GetAsync<CurrencyViewModel>($"api/currencies/{id}");
        }

        public async Task<CurrencyViewModel> CreateCurrencyAsync(CurrencyCreateViewModel model)
        {
            return await PostAsync<CurrencyCreateViewModel, CurrencyViewModel>("api/currencies", model) ?? new CurrencyViewModel();
        }

        public async Task<CurrencyViewModel> UpdateCurrencyAsync(CurrencyEditViewModel model)
        {
            return await PutAsync<CurrencyEditViewModel, CurrencyViewModel>($"api/currencies/{model.Id}", model) ?? new CurrencyViewModel();
        }

        public async Task DeleteCurrencyAsync(int id)
        {
            await DeleteAsync($"api/currencies/{id}");
        }

        // Master - Nationalities
        public async Task<IEnumerable<NationalityViewModel>> GetNationalitiesAsync()
        {
            return await GetAsync<IEnumerable<NationalityViewModel>>("api/nationalities") ?? new List<NationalityViewModel>();
        }

        public async Task<NationalityViewModel?> GetNationalityByIdAsync(int id)
        {
            return await GetAsync<NationalityViewModel>($"api/nationalities/{id}");
        }

        public async Task<NationalityViewModel> CreateNationalityAsync(NationalityCreateViewModel model)
        {
            return await PostAsync<NationalityCreateViewModel, NationalityViewModel>("api/nationalities", model) ?? new NationalityViewModel();
        }

        public async Task<NationalityViewModel> UpdateNationalityAsync(NationalityEditViewModel model)
        {
            return await PutAsync<NationalityEditViewModel, NationalityViewModel>($"api/nationalities/{model.Id}", model) ?? new NationalityViewModel();
        }

        public async Task DeleteNationalityAsync(int id)
        {
            await DeleteAsync($"api/nationalities/{id}");
        }

        // Master - Pass Companies
        public async Task<IEnumerable<PassCompanyViewModel>> GetPassCompaniesAsync()
        {
            return await GetAsync<IEnumerable<PassCompanyViewModel>>("api/passcompanies") ?? new List<PassCompanyViewModel>();
        }

        public async Task<PassCompanyViewModel?> GetPassCompanyByIdAsync(int id)
        {
            return await GetAsync<PassCompanyViewModel>($"api/passcompanies/{id}");
        }

        public async Task<PassCompanyViewModel> CreatePassCompanyAsync(PassCompanyCreateViewModel model)
        {
            return await PostAsync<PassCompanyCreateViewModel, PassCompanyViewModel>("api/passcompanies", model) ?? new PassCompanyViewModel();
        }

        public async Task<PassCompanyViewModel> UpdatePassCompanyAsync(PassCompanyEditViewModel model)
        {
            return await PutAsync<PassCompanyEditViewModel, PassCompanyViewModel>($"api/passcompanies/{model.Id}", model) ?? new PassCompanyViewModel();
        }

        public async Task DeletePassCompanyAsync(int id)
        {
            await DeleteAsync($"api/passcompanies/{id}");
        }

        // Master - Pass Agreements
        public async Task<IEnumerable<PassAgreementViewModel>> GetPassAgreementsAsync()
        {
            return await GetAsync<IEnumerable<PassAgreementViewModel>>("api/passagreements") ?? new List<PassAgreementViewModel>();
        }

        public async Task<PassAgreementViewModel?> GetPassAgreementByIdAsync(int id)
        {
            return await GetAsync<PassAgreementViewModel>($"api/passagreements/{id}");
        }

        public async Task<PassAgreementViewModel> CreatePassAgreementAsync(PassAgreementCreateViewModel model)
        {
            return await PostAsync<PassAgreementCreateViewModel, PassAgreementViewModel>("api/passagreements", model) ?? new PassAgreementViewModel();
        }

        public async Task<PassAgreementViewModel> UpdatePassAgreementAsync(PassAgreementEditViewModel model)
        {
            return await PutAsync<PassAgreementEditViewModel, PassAgreementViewModel>($"api/passagreements/{model.Id}", model) ?? new PassAgreementViewModel();
        }

        public async Task DeletePassAgreementAsync(int id)
        {
            await DeleteAsync($"api/passagreements/{id}");
        }

        // System - Users
        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            return await GetAsync<IEnumerable<UserViewModel>>("api/users") ?? new List<UserViewModel>();
        }

        public async Task<UserViewModel?> GetUserByIdAsync(int id)
        {
            return await GetAsync<UserViewModel>($"api/users/{id}");
        }

        public async Task<UserViewModel> CreateUserAsync(UserCreateViewModel model)
        {
            return await PostAsync<UserCreateViewModel, UserViewModel>("api/users", model) ?? new UserViewModel();
        }

        public async Task<UserViewModel> UpdateUserAsync(UserEditViewModel model)
        {
            return await PutAsync<UserEditViewModel, UserViewModel>($"api/users/{model.Id}", model) ?? new UserViewModel();
        }

        public async Task DeleteUserAsync(int id)
        {
            await DeleteAsync($"api/users/{id}");
        }

        // System - Reports
        public async Task<IEnumerable<ReportViewModel>> GetReportsAsync()
        {
            return await GetAsync<IEnumerable<ReportViewModel>>("api/reports") ?? new List<ReportViewModel>();
        }

        public async Task<ReportViewModel?> GetReportByIdAsync(int id)
        {
            return await GetAsync<ReportViewModel>($"api/reports/{id}");
        }

        public async Task<ReportViewModel> CreateReportAsync(ReportCreateViewModel model)
        {
            return await PostAsync<ReportCreateViewModel, ReportViewModel>("api/reports", model) ?? new ReportViewModel();
        }

        public async Task<ReportViewModel> UpdateReportAsync(ReportEditViewModel model)
        {
            return await PutAsync<ReportEditViewModel, ReportViewModel>($"api/reports/{model.Id}", model) ?? new ReportViewModel();
        }

        public async Task DeleteReportAsync(int id)
        {
            await DeleteAsync($"api/reports/{id}");
        }

        // System - System Logs
        public async Task<IEnumerable<SystemLogViewModel>> GetSystemLogsAsync()
        {
            return await GetAsync<IEnumerable<SystemLogViewModel>>("api/systemlogs") ?? new List<SystemLogViewModel>();
        }

        public async Task<SystemLogViewModel?> GetSystemLogByIdAsync(int id)
        {
            return await GetAsync<SystemLogViewModel>($"api/systemlogs/{id}");
        }

        // Tour - Tours
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

        // Tour - Tour Schedules
        public async Task<IEnumerable<TourScheduleViewModel>> GetTourSchedulesAsync()
        {
            return await GetAsync<IEnumerable<TourScheduleViewModel>>("api/tourschedules") ?? new List<TourScheduleViewModel>();
        }

        public async Task<TourScheduleViewModel?> GetTourScheduleByIdAsync(int id)
        {
            return await GetAsync<TourScheduleViewModel>($"api/tourschedules/{id}");
        }

        public async Task<TourScheduleViewModel> CreateTourScheduleAsync(TourScheduleCreateViewModel model)
        {
            return await PostAsync<TourScheduleCreateViewModel, TourScheduleViewModel>("api/tourschedules", model) ?? new TourScheduleViewModel();
        }

        public async Task<TourScheduleViewModel> UpdateTourScheduleAsync(TourScheduleEditViewModel model)
        {
            return await PutAsync<TourScheduleEditViewModel, TourScheduleViewModel>($"api/tourschedules/{model.Id}", model) ?? new TourScheduleViewModel();
        }

        public async Task DeleteTourScheduleAsync(int id)
        {
            await DeleteAsync($"api/tourschedules/{id}");
        }

        // Tour - Service Schedules
        public async Task<IEnumerable<ServiceScheduleViewModel>> GetServiceSchedulesAsync()
        {
            return await GetAsync<IEnumerable<ServiceScheduleViewModel>>("api/serviceschedules") ?? new List<ServiceScheduleViewModel>();
        }

        public async Task<ServiceScheduleViewModel?> GetServiceScheduleByIdAsync(int id)
        {
            return await GetAsync<ServiceScheduleViewModel>($"api/serviceschedules/{id}");
        }

        public async Task<ServiceScheduleViewModel> CreateServiceScheduleAsync(ServiceScheduleCreateViewModel model)
        {
            return await PostAsync<ServiceScheduleCreateViewModel, ServiceScheduleViewModel>("api/serviceschedules", model) ?? new ServiceScheduleViewModel();
        }

        public async Task<ServiceScheduleViewModel> UpdateServiceScheduleAsync(ServiceScheduleEditViewModel model)
        {
            return await PutAsync<ServiceScheduleEditViewModel, ServiceScheduleViewModel>($"api/serviceschedules/{model.Id}", model) ?? new ServiceScheduleViewModel();
        }

        public async Task DeleteServiceScheduleAsync(int id)
        {
            await DeleteAsync($"api/serviceschedules/{id}");
        }

        // Tour - Tickets
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

        // Tour - Tour Operations
        public async Task<IEnumerable<TourOperationViewModel>> GetTourOperationsAsync()
        {
            return await GetAsync<IEnumerable<TourOperationViewModel>>("api/touroperations") ?? new List<TourOperationViewModel>();
        }

        public async Task<TourOperationViewModel?> GetTourOperationByIdAsync(int id)
        {
            return await GetAsync<TourOperationViewModel>($"api/touroperations/{id}");
        }

        public async Task<TourOperationViewModel> CreateTourOperationAsync(TourOperationCreateViewModel model)
        {
            return await PostAsync<TourOperationCreateViewModel, TourOperationViewModel>("api/touroperations", model) ?? new TourOperationViewModel();
        }

        public async Task<TourOperationViewModel> UpdateTourOperationAsync(TourOperationEditViewModel model)
        {
            return await PutAsync<TourOperationEditViewModel, TourOperationViewModel>($"api/touroperations/{model.Id}", model) ?? new TourOperationViewModel();
        }

        public async Task DeleteTourOperationAsync(int id)
        {
            await DeleteAsync($"api/touroperations/{id}");
        }

        // Tour - Bus Assignments
        public async Task<IEnumerable<BusAssignmentViewModel>> GetBusAssignmentsAsync()
        {
            return await GetAsync<IEnumerable<BusAssignmentViewModel>>("api/busassignments") ?? new List<BusAssignmentViewModel>();
        }

        public async Task<BusAssignmentViewModel?> GetBusAssignmentByIdAsync(int id)
        {
            return await GetAsync<BusAssignmentViewModel>($"api/busassignments/{id}");
        }

        public async Task<BusAssignmentViewModel> CreateBusAssignmentAsync(BusAssignmentCreateViewModel model)
        {
            return await PostAsync<BusAssignmentCreateViewModel, BusAssignmentViewModel>("api/busassignments", model) ?? new BusAssignmentViewModel();
        }

        public async Task<BusAssignmentViewModel> UpdateBusAssignmentAsync(BusAssignmentEditViewModel model)
        {
            return await PutAsync<BusAssignmentEditViewModel, BusAssignmentViewModel>($"api/busassignments/{model.Id}", model) ?? new BusAssignmentViewModel();
        }

        public async Task DeleteBusAssignmentAsync(int id)
        {
            await DeleteAsync($"api/busassignments/{id}");
        }

        // Tour - Customer Distributions
        public async Task<IEnumerable<CustomerDistributionViewModel>> GetCustomerDistributionsAsync()
        {
            return await GetAsync<IEnumerable<CustomerDistributionViewModel>>("api/customerdistributions") ?? new List<CustomerDistributionViewModel>();
        }

        public async Task<CustomerDistributionViewModel?> GetCustomerDistributionByIdAsync(int id)
        {
            return await GetAsync<CustomerDistributionViewModel>($"api/customerdistributions/{id}");
        }

        public async Task<CustomerDistributionViewModel> CreateCustomerDistributionAsync(CustomerDistributionCreateViewModel model)
        {
            return await PostAsync<CustomerDistributionCreateViewModel, CustomerDistributionViewModel>("api/customerdistributions", model) ?? new CustomerDistributionViewModel();
        }

        public async Task<CustomerDistributionViewModel> UpdateCustomerDistributionAsync(CustomerDistributionEditViewModel model)
        {
            return await PutAsync<CustomerDistributionEditViewModel, CustomerDistributionViewModel>($"api/customerdistributions/{model.Id}", model) ?? new CustomerDistributionViewModel();
        }

        public async Task DeleteCustomerDistributionAsync(int id)
        {
            await DeleteAsync($"api/customerdistributions/{id}");
        }

        // Tour - Tour Expenses
        public async Task<IEnumerable<TourExpenseViewModel>> GetTourExpensesAsync()
        {
            return await GetAsync<IEnumerable<TourExpenseViewModel>>("api/tourexpenses") ?? new List<TourExpenseViewModel>();
        }

        public async Task<TourExpenseViewModel?> GetTourExpenseByIdAsync(int id)
        {
            return await GetAsync<TourExpenseViewModel>($"api/tourexpenses/{id}");
        }

        public async Task<TourExpenseViewModel> CreateTourExpenseAsync(TourExpenseCreateViewModel model)
        {
            return await PostAsync<TourExpenseCreateViewModel, TourExpenseViewModel>("api/tourexpenses", model) ?? new TourExpenseViewModel();
        }

        public async Task<TourExpenseViewModel> UpdateTourExpenseAsync(TourExpenseEditViewModel model)
        {
            return await PutAsync<TourExpenseEditViewModel, TourExpenseViewModel>($"api/tourexpenses/{model.Id}", model) ?? new TourExpenseViewModel();
        }

        public async Task DeleteTourExpenseAsync(int id)
        {
            await DeleteAsync($"api/tourexpenses/{id}");
        }

        // Tour - Tour Incomes
        public async Task<IEnumerable<TourIncomeViewModel>> GetTourIncomesAsync()
        {
            return await GetAsync<IEnumerable<TourIncomeViewModel>>("api/tourincomes") ?? new List<TourIncomeViewModel>();
        }

        public async Task<TourIncomeViewModel?> GetTourIncomeByIdAsync(int id)
        {
            return await GetAsync<TourIncomeViewModel>($"api/tourincomes/{id}");
        }

        public async Task<TourIncomeViewModel> CreateTourIncomeAsync(TourIncomeCreateViewModel model)
        {
            return await PostAsync<TourIncomeCreateViewModel, TourIncomeViewModel>("api/tourincomes", model) ?? new TourIncomeViewModel();
        }

        public async Task<TourIncomeViewModel> UpdateTourIncomeAsync(TourIncomeEditViewModel model)
        {
            return await PutAsync<TourIncomeEditViewModel, TourIncomeViewModel>($"api/tourincomes/{model.Id}", model) ?? new TourIncomeViewModel();
        }

        public async Task DeleteTourIncomeAsync(int id)
        {
            await DeleteAsync($"api/tourincomes/{id}");
        }

        // Tour - Tour Reports
        public async Task<IEnumerable<TourReportViewModel>> GetTourReportsAsync()
        {
            return await GetAsync<IEnumerable<TourReportViewModel>>("api/tourreports") ?? new List<TourReportViewModel>();
        }

        public async Task<TourReportViewModel?> GetTourReportByIdAsync(int id)
        {
            return await GetAsync<TourReportViewModel>($"api/tourreports/{id}");
        }

        public async Task<TourReportViewModel> CreateTourReportAsync(TourReportCreateViewModel model)
        {
            return await PostAsync<TourReportCreateViewModel, TourReportViewModel>("api/tourreports", model) ?? new TourReportViewModel();
        }

        public async Task<TourReportViewModel> UpdateTourReportAsync(TourReportEditViewModel model)
        {
            return await PutAsync<TourReportEditViewModel, TourReportViewModel>($"api/tourreports/{model.Id}", model) ?? new TourReportViewModel();
        }

        public async Task DeleteTourReportAsync(int id)
        {
            await DeleteAsync($"api/tourreports/{id}");
        }
    }
} 