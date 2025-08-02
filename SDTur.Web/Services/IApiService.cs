using SDTur.Web.Models;
using SDTur.Web.Models.Financial.Accounts;
using SDTur.Web.Models.Financial.Cash;
using SDTur.Web.Models.Financial.Invoices;
using SDTur.Web.Models.Financial.Reports;
using SDTur.Web.Models.Financial.Transactions;
using SDTur.Web.Models.Master.Branches;
using SDTur.Web.Models.Master.People;
using SDTur.Web.Models.Master.Locations;
using SDTur.Web.Models.Master.Transport;
using SDTur.Web.Models.Master.References;
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
    public interface IApiService
    {
        // Generic CRUD operations
        Task<T?> GetAsync<T>(string url);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data);
        Task DeleteAsync(string url);

        // Financial - Accounts
        Task<IEnumerable<AccountViewModel>> GetAccountsAsync();
        Task<AccountViewModel?> GetAccountByIdAsync(int id);
        Task<AccountViewModel> CreateAccountAsync(AccountCreateViewModel model);
        Task<AccountViewModel> UpdateAccountAsync(AccountEditViewModel model);
        Task DeleteAccountAsync(int id);

        // Financial - Account Transactions
        Task<IEnumerable<AccountTransactionViewModel>> GetAccountTransactionsAsync();
        Task<AccountTransactionViewModel?> GetAccountTransactionByIdAsync(int id);
        Task<AccountTransactionViewModel> CreateAccountTransactionAsync(AccountTransactionCreateViewModel model);
        Task<AccountTransactionViewModel> UpdateAccountTransactionAsync(AccountTransactionEditViewModel model);
        Task DeleteAccountTransactionAsync(int id);

        // Financial - Cash
        Task<IEnumerable<CashViewModel>> GetCashAsync();
        Task<CashViewModel?> GetCashByIdAsync(int id);
        Task<CashViewModel> CreateCashAsync(CashCreateViewModel model);
        Task<CashViewModel> UpdateCashAsync(CashEditViewModel model);
        Task DeleteCashAsync(int id);

        // Financial - Invoices
        Task<IEnumerable<InvoiceViewModel>> GetInvoicesAsync();
        Task<InvoiceViewModel?> GetInvoiceByIdAsync(int id);
        Task<InvoiceViewModel> CreateInvoiceAsync(InvoiceCreateViewModel model);
        Task<InvoiceViewModel> UpdateInvoiceAsync(InvoiceEditViewModel model);
        Task DeleteInvoiceAsync(int id);

        // Financial - Invoice Details
        Task<IEnumerable<InvoiceDetailViewModel>> GetInvoiceDetailsAsync();
        Task<InvoiceDetailViewModel?> GetInvoiceDetailByIdAsync(int id);
        Task<IEnumerable<InvoiceDetailViewModel>> GetInvoiceDetailsByInvoiceIdAsync(int invoiceId);
        Task<InvoiceDetailViewModel> CreateInvoiceDetailAsync(InvoiceDetailCreateViewModel model);
        Task<InvoiceDetailViewModel> UpdateInvoiceDetailAsync(InvoiceDetailEditViewModel model);
        Task DeleteInvoiceDetailAsync(int id);

        // Financial - Exchange Rates
        Task<IEnumerable<ExchangeRateViewModel>> GetExchangeRatesAsync();
        Task<ExchangeRateViewModel?> GetExchangeRateByIdAsync(int id);
        Task<ExchangeRateViewModel> CreateExchangeRateAsync(ExchangeRateCreateViewModel model);
        Task<ExchangeRateViewModel> UpdateExchangeRateAsync(ExchangeRateEditViewModel model);
        Task DeleteExchangeRateAsync(int id);

        // Financial - Commission Calculations
        Task<IEnumerable<CommissionCalculationViewModel>> GetCommissionCalculationsAsync();
        Task<CommissionCalculationViewModel?> GetCommissionCalculationByIdAsync(int id);
        Task<CommissionCalculationViewModel> CreateCommissionCalculationAsync(CommissionCalculationCreateViewModel model);
        Task<CommissionCalculationViewModel> UpdateCommissionCalculationAsync(CommissionCalculationEditViewModel model);
        Task DeleteCommissionCalculationAsync(int id);

        // Financial - Financial Reports
        Task<IEnumerable<FinancialReportViewModel>> GetFinancialReportsAsync();
        Task<FinancialReportViewModel?> GetFinancialReportByIdAsync(int id);
        Task<FinancialReportViewModel> CreateFinancialReportAsync(FinancialReportCreateViewModel model);
        Task<FinancialReportViewModel> UpdateFinancialReportAsync(FinancialReportEditViewModel model);
        Task DeleteFinancialReportAsync(int id);

        // Master - Branches
        Task<IEnumerable<BranchViewModel>> GetBranchesAsync();
        Task<BranchViewModel?> GetBranchByIdAsync(int id);
        Task<BranchViewModel> CreateBranchAsync(BranchCreateViewModel model);
        Task<BranchViewModel> UpdateBranchAsync(BranchEditViewModel model);
        Task DeleteBranchAsync(int id);

        // Master - Employees
        Task<IEnumerable<EmployeeViewModel>> GetEmployeesAsync();
        Task<EmployeeViewModel?> GetEmployeeByIdAsync(int id);
        Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeCreateViewModel model);
        Task<EmployeeViewModel> UpdateEmployeeAsync(EmployeeEditViewModel model);
        Task DeleteEmployeeAsync(int id);

        // Master - Regions
        Task<IEnumerable<RegionViewModel>> GetRegionsAsync();
        Task<RegionViewModel?> GetRegionByIdAsync(int id);
        Task<RegionViewModel> CreateRegionAsync(RegionCreateViewModel model);
        Task<RegionViewModel> UpdateRegionAsync(RegionEditViewModel model);
        Task DeleteRegionAsync(int id);

        // Master - Hotels
        Task<IEnumerable<HotelViewModel>> GetHotelsAsync();
        Task<HotelViewModel?> GetHotelByIdAsync(int id);
        Task<HotelViewModel> CreateHotelAsync(HotelCreateViewModel model);
        Task<HotelViewModel> UpdateHotelAsync(HotelEditViewModel model);
        Task DeleteHotelAsync(int id);

        // Master - Buses
        Task<IEnumerable<BusViewModel>> GetBusesAsync();
        Task<BusViewModel?> GetBusByIdAsync(int id);
        Task<BusViewModel> CreateBusAsync(BusCreateViewModel model);
        Task<BusViewModel> UpdateBusAsync(BusEditViewModel model);
        Task DeleteBusAsync(int id);

        // Master - Currencies
        Task<IEnumerable<CurrencyViewModel>> GetCurrenciesAsync();
        Task<CurrencyViewModel?> GetCurrencyByIdAsync(int id);
        Task<CurrencyViewModel> CreateCurrencyAsync(CurrencyCreateViewModel model);
        Task<CurrencyViewModel> UpdateCurrencyAsync(CurrencyEditViewModel model);
        Task DeleteCurrencyAsync(int id);

        // Master - Nationalities
        Task<IEnumerable<NationalityViewModel>> GetNationalitiesAsync();
        Task<NationalityViewModel?> GetNationalityByIdAsync(int id);
        Task<NationalityViewModel> CreateNationalityAsync(NationalityCreateViewModel model);
        Task<NationalityViewModel> UpdateNationalityAsync(NationalityEditViewModel model);
        Task DeleteNationalityAsync(int id);

        // Master - Pass Companies
        Task<IEnumerable<PassCompanyViewModel>> GetPassCompaniesAsync();
        Task<PassCompanyViewModel?> GetPassCompanyByIdAsync(int id);
        Task<PassCompanyViewModel> CreatePassCompanyAsync(PassCompanyCreateViewModel model);
        Task<PassCompanyViewModel> UpdatePassCompanyAsync(PassCompanyEditViewModel model);
        Task DeletePassCompanyAsync(int id);

        // Master - Pass Agreements
        Task<IEnumerable<PassAgreementViewModel>> GetPassAgreementsAsync();
        Task<PassAgreementViewModel?> GetPassAgreementByIdAsync(int id);
        Task<PassAgreementViewModel> CreatePassAgreementAsync(PassAgreementCreateViewModel model);
        Task<PassAgreementViewModel> UpdatePassAgreementAsync(PassAgreementEditViewModel model);
        Task DeletePassAgreementAsync(int id);

        // System - Users
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel?> GetUserByIdAsync(int id);
        Task<UserViewModel> CreateUserAsync(UserCreateViewModel model);
        Task<UserViewModel> UpdateUserAsync(UserEditViewModel model);
        Task DeleteUserAsync(int id);

        // System - Reports
        Task<IEnumerable<ReportViewModel>> GetReportsAsync();
        Task<ReportViewModel?> GetReportByIdAsync(int id);
        Task<ReportViewModel> CreateReportAsync(ReportCreateViewModel model);
        Task<ReportViewModel> UpdateReportAsync(ReportEditViewModel model);
        Task DeleteReportAsync(int id);

        // System - System Logs
        Task<IEnumerable<SystemLogViewModel>> GetSystemLogsAsync();
        Task<SystemLogViewModel?> GetSystemLogByIdAsync(int id);

        // Tour - Tours
        Task<IEnumerable<TourViewModel>> GetToursAsync();
        Task<IEnumerable<TourViewModel>> GetActiveToursAsync();
        Task<TourViewModel?> GetTourByIdAsync(int id);
        Task<TourViewModel> CreateTourAsync(TourCreateViewModel createTourViewModel);
        Task<TourViewModel> UpdateTourAsync(TourEditViewModel updateTourViewModel);
        Task DeleteTourAsync(int id);

        // Tour - Tour Schedules
        Task<IEnumerable<TourScheduleViewModel>> GetTourSchedulesAsync();
        Task<TourScheduleViewModel?> GetTourScheduleByIdAsync(int id);
        Task<TourScheduleViewModel> CreateTourScheduleAsync(TourScheduleCreateViewModel model);
        Task<TourScheduleViewModel> UpdateTourScheduleAsync(TourScheduleEditViewModel model);
        Task DeleteTourScheduleAsync(int id);

        // Tour - Service Schedules
        Task<IEnumerable<ServiceScheduleViewModel>> GetServiceSchedulesAsync();
        Task<ServiceScheduleViewModel?> GetServiceScheduleByIdAsync(int id);
        Task<ServiceScheduleViewModel> CreateServiceScheduleAsync(ServiceScheduleCreateViewModel model);
        Task<ServiceScheduleViewModel> UpdateServiceScheduleAsync(ServiceScheduleEditViewModel model);
        Task DeleteServiceScheduleAsync(int id);

        // Tour - Tickets
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

        // Tour - Tour Operations
        Task<IEnumerable<TourOperationViewModel>> GetTourOperationsAsync();
        Task<TourOperationViewModel?> GetTourOperationByIdAsync(int id);
        Task<TourOperationViewModel> CreateTourOperationAsync(TourOperationCreateViewModel model);
        Task<TourOperationViewModel> UpdateTourOperationAsync(TourOperationEditViewModel model);
        Task DeleteTourOperationAsync(int id);

        // Tour - Bus Assignments
        Task<IEnumerable<BusAssignmentViewModel>> GetBusAssignmentsAsync();
        Task<BusAssignmentViewModel?> GetBusAssignmentByIdAsync(int id);
        Task<BusAssignmentViewModel> CreateBusAssignmentAsync(BusAssignmentCreateViewModel model);
        Task<BusAssignmentViewModel> UpdateBusAssignmentAsync(BusAssignmentEditViewModel model);
        Task DeleteBusAssignmentAsync(int id);

        // Tour - Customer Distributions
        Task<IEnumerable<CustomerDistributionViewModel>> GetCustomerDistributionsAsync();
        Task<CustomerDistributionViewModel?> GetCustomerDistributionByIdAsync(int id);
        Task<CustomerDistributionViewModel> CreateCustomerDistributionAsync(CustomerDistributionCreateViewModel model);
        Task<CustomerDistributionViewModel> UpdateCustomerDistributionAsync(CustomerDistributionEditViewModel model);
        Task DeleteCustomerDistributionAsync(int id);

        // Tour - Tour Expenses
        Task<IEnumerable<TourExpenseViewModel>> GetTourExpensesAsync();
        Task<TourExpenseViewModel?> GetTourExpenseByIdAsync(int id);
        Task<TourExpenseViewModel> CreateTourExpenseAsync(TourExpenseCreateViewModel model);
        Task<TourExpenseViewModel> UpdateTourExpenseAsync(TourExpenseEditViewModel model);
        Task DeleteTourExpenseAsync(int id);

        // Tour - Tour Incomes
        Task<IEnumerable<TourIncomeViewModel>> GetTourIncomesAsync();
        Task<TourIncomeViewModel?> GetTourIncomeByIdAsync(int id);
        Task<TourIncomeViewModel> CreateTourIncomeAsync(TourIncomeCreateViewModel model);
        Task<TourIncomeViewModel> UpdateTourIncomeAsync(TourIncomeEditViewModel model);
        Task DeleteTourIncomeAsync(int id);

        // Tour - Tour Reports
        Task<IEnumerable<TourReportViewModel>> GetTourReportsAsync();
        Task<TourReportViewModel?> GetTourReportByIdAsync(int id);
        Task<TourReportViewModel> CreateTourReportAsync(TourReportCreateViewModel model);
        Task<TourReportViewModel> UpdateTourReportAsync(TourReportEditViewModel model);
        Task DeleteTourReportAsync(int id);
    }
} 