using System;
using System.Threading.Tasks;

namespace SDTur.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITourRepository Tours { get; }
        IBranchRepository Branches { get; }
        IEmployeeRepository Employees { get; }
        IRegionRepository Regions { get; }
        IHotelRepository Hotels { get; }
        ITicketRepository Tickets { get; }
        ITourScheduleRepository TourSchedules { get; }
        IServiceScheduleRepository ServiceSchedules { get; }
        IBusRepository Buses { get; }
        ITourExpenseRepository TourExpenses { get; }
        ITourIncomeRepository TourIncomes { get; }
        IPassCompanyRepository PassCompanies { get; }
        IPassAgreementRepository PassAgreements { get; }
        IAccountTransactionRepository AccountTransactions { get; }
        IExchangeRateRepository ExchangeRates { get; }
        INationalityRepository Nationalities { get; }
        ICurrencyRepository Currencies { get; }
        IUserRepository Users { get; }
        IInvoiceRepository Invoices { get; }
        ICashRepository Cash { get; }
        IAccountRepository Accounts { get; }
        ITourOperationRepository TourOperations { get; }
        IReportRepository Reports { get; }
        IBusAssignmentRepository BusAssignments { get; }
        ICustomerDistributionRepository CustomerDistributions { get; }
        ICommissionCalculationRepository CommissionCalculations { get; }
        ITourReportRepository TourReports { get; }
        IFinancialReportRepository FinancialReports { get; }
        ISystemLogRepository SystemLogs { get; }
        
        Task<int> SaveChangesAsync();
    }
} 