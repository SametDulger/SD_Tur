using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
using SDTur.Core.Interfaces.System;
using SDTur.Core.Interfaces.Master;
using SDTur.Core.Interfaces.Financial;
using SDTur.Core.Interfaces.Tour;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.UnitOfWork;
using SDTur.Infrastructure.Repositories.System;
using SDTur.Infrastructure.Repositories.Master;
using SDTur.Infrastructure.Repositories.Financial;
using SDTur.Infrastructure.Repositories.Tour;
using SDTur.Infrastructure.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"] ?? "your-super-secret-key-with-at-least-32-characters";
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

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
builder.Services.AddScoped<IAuthService, AuthService>();
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

// Repository registrations
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISystemLogRepository, SystemLogRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// Master repositories
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<IPassCompanyRepository, PassCompanyRepository>();
builder.Services.AddScoped<IPassAgreementRepository, PassAgreementRepository>();
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

// Tour repositories
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITourScheduleRepository, TourScheduleRepository>();
builder.Services.AddScoped<IServiceScheduleRepository, ServiceScheduleRepository>();
builder.Services.AddScoped<ITourExpenseRepository, TourExpenseRepository>();
builder.Services.AddScoped<ITourIncomeRepository, TourIncomeRepository>();
builder.Services.AddScoped<ITourOperationRepository, TourOperationRepository>();
builder.Services.AddScoped<ITourReportRepository, TourReportRepository>();
builder.Services.AddScoped<IBusAssignmentRepository, BusAssignmentRepository>();
builder.Services.AddScoped<ICustomerDistributionRepository, CustomerDistributionRepository>();

// Financial repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
builder.Services.AddScoped<ICashRepository, CashRepository>();
builder.Services.AddScoped<ICommissionCalculationRepository, CommissionCalculationRepository>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();
builder.Services.AddScoped<IFinancialReportRepository, FinancialReportRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SDTurDbContext>();
    await SeedData.SeedUsers(context);
}

app.Run();
