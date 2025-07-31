using AutoMapper;
using SDTur.Application.DTOs.Financial.Account;
using SDTur.Application.DTOs.Financial.AccountTransaction;
using SDTur.Application.DTOs.Financial.Cash;
using SDTur.Application.DTOs.Financial.CommissionCalculation;
using SDTur.Application.DTOs.Financial.ExchangeRate;
using SDTur.Application.DTOs.Financial.FinancialReport;
using SDTur.Application.DTOs.Financial.Invoice;
using SDTur.Application.DTOs.Financial.InvoiceDetail;
using SDTur.Application.DTOs.Master.Branch;
using SDTur.Application.DTOs.Master.Bus;
using SDTur.Application.DTOs.Master.Currency;
using SDTur.Application.DTOs.Master.Employee;
using SDTur.Application.DTOs.Master.Hotel;
using SDTur.Application.DTOs.Master.Nationality;
using SDTur.Application.DTOs.Master.PassAgreement;
using SDTur.Application.DTOs.Master.PassCompany;
using SDTur.Application.DTOs.Master.Region;
using SDTur.Application.DTOs.System.Report;
using SDTur.Application.DTOs.System.SystemLog;
using SDTur.Application.DTOs.System.User;
using SDTur.Application.DTOs.Tour.BusAssignment;
using SDTur.Application.DTOs.Tour.CustomerDistribution;
using SDTur.Application.DTOs.Tour.ServiceSchedule;
using SDTur.Application.DTOs.Tour.Ticket;
using SDTur.Application.DTOs.Tour.Tour;
using SDTur.Application.DTOs.Tour.TourExpense;
using SDTur.Application.DTOs.Tour.TourIncome;
using SDTur.Application.DTOs.Tour.TourOperation;
using SDTur.Application.DTOs.Tour.TourReport;
using SDTur.Application.DTOs.Tour.TourSchedule;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Entities.Master;
using SDTur.Core.Entities.System;
using SDTur.Core.Entities.Tour;

namespace SDTur.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Tour mappings
            CreateMap<Tour, TourDto>();
            CreateMap<CreateTourDto, Tour>();
            CreateMap<UpdateTourDto, Tour>();

            // PassCompany mappings
            CreateMap<PassCompany, PassCompanyDto>();
            CreateMap<CreatePassCompanyDto, PassCompany>();
            CreateMap<UpdatePassCompanyDto, PassCompany>();

            // PassAgreement mappings
            CreateMap<PassAgreement, PassAgreementDto>();
            CreateMap<CreatePassAgreementDto, PassAgreement>();
            CreateMap<UpdatePassAgreementDto, PassAgreement>();

            // Ticket mappings
            CreateMap<Ticket, TicketDto>();
            CreateMap<CreateTicketDto, Ticket>();
            CreateMap<UpdateTicketDto, Ticket>();

            // Branch mappings
            CreateMap<Branch, BranchDto>();
            CreateMap<CreateBranchDto, Branch>();
            CreateMap<UpdateBranchDto, Branch>();

            // Employee mappings
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            // Region mappings
            CreateMap<Region, RegionDto>();
            CreateMap<CreateRegionDto, Region>();
            CreateMap<UpdateRegionDto, Region>();

            // Hotel mappings
            CreateMap<Hotel, HotelDto>();
            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto, Hotel>();

            // Bus mappings
            CreateMap<Bus, BusDto>();
            CreateMap<CreateBusDto, Bus>();
            CreateMap<UpdateBusDto, Bus>();

            // Currency mappings
            CreateMap<Currency, CurrencyDto>();
            CreateMap<CreateCurrencyDto, Currency>();
            CreateMap<UpdateCurrencyDto, Currency>();

            // Nationality mappings
            CreateMap<Nationality, NationalityDto>();
            CreateMap<CreateNationalityDto, Nationality>();
            CreateMap<UpdateNationalityDto, Nationality>();

            // TourSchedule mappings
            CreateMap<TourSchedule, TourScheduleDto>();
            CreateMap<CreateTourScheduleDto, TourSchedule>();
            CreateMap<UpdateTourScheduleDto, TourSchedule>();

            // ServiceSchedule mappings
            CreateMap<ServiceSchedule, ServiceScheduleDto>();
            CreateMap<CreateServiceScheduleDto, ServiceSchedule>();
            CreateMap<UpdateServiceScheduleDto, ServiceSchedule>();

            // TourExpense mappings
            CreateMap<TourExpense, TourExpenseDto>();
            CreateMap<CreateTourExpenseDto, TourExpense>();
            CreateMap<UpdateTourExpenseDto, TourExpense>();

            // TourIncome mappings
            CreateMap<TourIncome, TourIncomeDto>();
            CreateMap<CreateTourIncomeDto, TourIncome>();
            CreateMap<UpdateTourIncomeDto, TourIncome>();

            // TourOperation mappings
            CreateMap<TourOperation, TourOperationDto>();
            CreateMap<CreateTourOperationDto, TourOperation>();
            CreateMap<UpdateTourOperationDto, TourOperation>();



            // Cash mappings
            CreateMap<Cash, CashDto>();
            CreateMap<CreateCashDto, Cash>();
            CreateMap<UpdateCashDto, Cash>();

            // Account mappings
            CreateMap<Account, AccountDto>();
            CreateMap<CreateAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();

            // AccountTransaction mappings
            CreateMap<AccountTransaction, AccountTransactionDto>();
            CreateMap<CreateAccountTransactionDto, AccountTransaction>();
            CreateMap<UpdateAccountTransactionDto, AccountTransaction>();

            // ExchangeRate mappings
            CreateMap<ExchangeRate, ExchangeRateDto>();
            CreateMap<CreateExchangeRateDto, ExchangeRate>();
            CreateMap<UpdateExchangeRateDto, ExchangeRate>();

            // User mappings
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Invoice mappings
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceDto, Invoice>();

            // InvoiceDetail mappings
            CreateMap<InvoiceDetail, InvoiceDetailDto>();
            CreateMap<CreateInvoiceDetailDto, InvoiceDetail>();
            CreateMap<UpdateInvoiceDetailDto, InvoiceDetail>();

            // BusAssignment mappings
            CreateMap<BusAssignment, BusAssignmentDto>();
            CreateMap<CreateBusAssignmentDto, BusAssignment>();
            CreateMap<UpdateBusAssignmentDto, BusAssignment>();

            // CustomerDistribution mappings
            CreateMap<CustomerDistribution, CustomerDistributionDto>();
            CreateMap<CreateCustomerDistributionDto, CustomerDistribution>();
            CreateMap<UpdateCustomerDistributionDto, CustomerDistribution>();

            // CommissionCalculation mappings
            CreateMap<CommissionCalculation, CommissionCalculationDto>();
            CreateMap<CreateCommissionCalculationDto, CommissionCalculation>();
            CreateMap<UpdateCommissionCalculationDto, CommissionCalculation>();

            // TourReport mappings
            CreateMap<TourReport, TourReportDto>();
            CreateMap<CreateTourReportDto, TourReport>();
            CreateMap<UpdateTourReportDto, TourReport>();

            // FinancialReport mappings
            CreateMap<FinancialReport, FinancialReportDto>();
            CreateMap<CreateFinancialReportDto, FinancialReport>();
            CreateMap<UpdateFinancialReportDto, FinancialReport>();

            // SystemLog mappings
            CreateMap<SystemLog, SystemLogDto>();
            CreateMap<CreateSystemLogDto, SystemLog>();
            CreateMap<UpdateSystemLogDto, SystemLog>();

            // Report mappings
            CreateMap<Report, ReportDto>();
            CreateMap<CreateReportDto, Report>();
            CreateMap<UpdateReportDto, Report>();
        }
    }
} 