using System;
using System.Threading.Tasks;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories;

namespace SDTur.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SDTurDbContext _context;
        private ITourRepository? _tours;
        private IBranchRepository? _branches;
        private IEmployeeRepository? _employees;
        private IRegionRepository? _regions;
        private IHotelRepository? _hotels;
        private ITicketRepository? _tickets;
        private ITourScheduleRepository? _tourSchedules;
        private IServiceScheduleRepository? _serviceSchedules;
        private IBusRepository? _buses;
        private ITourExpenseRepository? _tourExpenses;
        private ITourIncomeRepository? _tourIncomes;
        private IPassCompanyRepository? _passCompanies;
        private IPassAgreementRepository? _passAgreements;
        private IAccountTransactionRepository? _accountTransactions;
        private IExchangeRateRepository? _exchangeRates;
        private INationalityRepository? _nationalities;
        private ICurrencyRepository? _currencies;
        private IUserRepository? _users;
        private IInvoiceRepository? _invoices;
        private ICashRepository? _cash;
        private IAccountRepository? _accounts;
        private ITourOperationRepository? _tourOperations;
        private IReportRepository? _reports;
        private IBusAssignmentRepository? _busAssignments;
        private ICustomerDistributionRepository? _customerDistributions;
        private ICommissionCalculationRepository? _commissionCalculations;
        private ITourReportRepository? _tourReports;
        private IFinancialReportRepository? _financialReports;
        private ISystemLogRepository? _systemLogs;

        public UnitOfWork(SDTurDbContext context)
        {
            _context = context;
        }

        public ITourRepository Tours => _tours ??= new TourRepository(_context);
        public IBranchRepository Branches => _branches ??= new BranchRepository(_context);
        public IEmployeeRepository Employees => _employees ??= new EmployeeRepository(_context);
        public IRegionRepository Regions => _regions ??= new RegionRepository(_context);
        public IHotelRepository Hotels => _hotels ??= new HotelRepository(_context);
        public ITicketRepository Tickets => _tickets ??= new TicketRepository(_context);
        public ITourScheduleRepository TourSchedules => _tourSchedules ??= new TourScheduleRepository(_context);
        public IServiceScheduleRepository ServiceSchedules => _serviceSchedules ??= new ServiceScheduleRepository(_context);
        public IBusRepository Buses => _buses ??= new BusRepository(_context);
        public ITourExpenseRepository TourExpenses => _tourExpenses ??= new TourExpenseRepository(_context);
        public ITourIncomeRepository TourIncomes => _tourIncomes ??= new TourIncomeRepository(_context);
        public IPassCompanyRepository PassCompanies => _passCompanies ??= new PassCompanyRepository(_context);
        public IPassAgreementRepository PassAgreements => _passAgreements ??= new PassAgreementRepository(_context);
        public IAccountTransactionRepository AccountTransactions => _accountTransactions ??= new AccountTransactionRepository(_context);
        public IExchangeRateRepository ExchangeRates => _exchangeRates ??= new ExchangeRateRepository(_context);
        public INationalityRepository Nationalities => _nationalities ??= new NationalityRepository(_context);
        public ICurrencyRepository Currencies => _currencies ??= new CurrencyRepository(_context);
        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IInvoiceRepository Invoices => _invoices ??= new InvoiceRepository(_context);
        public ICashRepository Cash => _cash ??= new CashRepository(_context);
        public IAccountRepository Accounts => _accounts ??= new AccountRepository(_context);
        public ITourOperationRepository TourOperations => _tourOperations ??= new TourOperationRepository(_context);
        public IReportRepository Reports => _reports ??= new ReportRepository(_context);
        public IBusAssignmentRepository BusAssignments => _busAssignments ??= new BusAssignmentRepository(_context);
        public ICustomerDistributionRepository CustomerDistributions => _customerDistributions ??= new CustomerDistributionRepository(_context);
        public ICommissionCalculationRepository CommissionCalculations => _commissionCalculations ??= new CommissionCalculationRepository(_context);
        public ITourReportRepository TourReports => _tourReports ??= new TourReportRepository(_context);
        public IFinancialReportRepository FinancialReports => _financialReports ??= new FinancialReportRepository(_context);
        public ISystemLogRepository SystemLogs => _systemLogs ??= new SystemLogRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
} 