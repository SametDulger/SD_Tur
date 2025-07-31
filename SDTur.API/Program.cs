using Microsoft.EntityFrameworkCore;
using SDTur.Application.Mapping;
using SDTur.Application.Services.Financial.Interfaces;
using SDTur.Application.Services.Master.Interfaces;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Application.Services.Tour.Interfaces;
using SDTur.Application.Services.Financial.Implementations;
using SDTur.Application.Services.Master.Implementations;
using SDTur.Application.Services.System.Implementations;
using SDTur.Application.Services.Tour.Implementations;
using SDTur.Core.Interfaces.Core;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configuration
builder.Services.AddDbContext<SDTurDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<ITourScheduleService, TourScheduleService>();
builder.Services.AddScoped<IServiceScheduleService, ServiceScheduleService>();
builder.Services.AddScoped<ITourExpenseService, TourExpenseService>();
builder.Services.AddScoped<ITourIncomeService, TourIncomeService>();
builder.Services.AddScoped<IPassCompanyService, PassCompanyService>();
builder.Services.AddScoped<IPassAgreementService, PassAgreementService>();
builder.Services.AddScoped<IAccountTransactionService, AccountTransactionService>();
builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();
builder.Services.AddScoped<INationalityService, NationalityService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ICashService, CashService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITourOperationService, TourOperationService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IBusAssignmentService, BusAssignmentService>();
builder.Services.AddScoped<ICustomerDistributionService, CustomerDistributionService>();
builder.Services.AddScoped<ICommissionCalculationService, CommissionCalculationService>();
builder.Services.AddScoped<ITourReportService, TourReportService>();
builder.Services.AddScoped<IFinancialReportService, FinancialReportService>();
builder.Services.AddScoped<ISystemLogService, SystemLogService>();
builder.Services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
