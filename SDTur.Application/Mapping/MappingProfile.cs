using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;

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

            // Ticket mappings with navigation properties
            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour != null ? src.Tour.Name : ""))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch != null ? src.Branch.Name : ""))
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel != null ? src.Hotel.Name : ""));
            CreateMap<CreateTicketDto, Ticket>();
            CreateMap<UpdateTicketDto, Ticket>();

            // Branch mappings
            CreateMap<Branch, BranchDto>();
            CreateMap<CreateBranchDto, Branch>();
            CreateMap<UpdateBranchDto, Branch>();

            // Employee mappings
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch != null ? src.Branch.Name : ""));
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            // Region mappings
            CreateMap<Region, RegionDto>();
            CreateMap<CreateRegionDto, Region>();
            CreateMap<UpdateRegionDto, Region>();

            // Hotel mappings
            CreateMap<Hotel, HotelDto>()
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.Region != null ? src.Region.Name : ""));
            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto, Hotel>();

            // Bus mappings
            CreateMap<Bus, BusDto>();
            CreateMap<CreateBusDto, Bus>();
            CreateMap<UpdateBusDto, Bus>();

            // TourSchedule mappings
            CreateMap<TourSchedule, TourScheduleDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour != null ? src.Tour.Name : ""));
            CreateMap<CreateTourScheduleDto, TourSchedule>();
            CreateMap<UpdateTourScheduleDto, TourSchedule>();

            // ServiceSchedule mappings
            CreateMap<ServiceSchedule, ServiceScheduleDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour != null ? src.Tour.Name : ""))
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.Region != null ? src.Region.Name : ""));
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

            // PassAgreement mappings
            CreateMap<PassAgreement, PassAgreementDto>();
            CreateMap<CreatePassAgreementDto, PassAgreement>();
            CreateMap<UpdatePassAgreementDto, PassAgreement>();

            // AccountTransaction mappings
            CreateMap<AccountTransaction, AccountTransactionDto>();
            CreateMap<CreateAccountTransactionDto, AccountTransaction>();
            CreateMap<UpdateAccountTransactionDto, AccountTransaction>();

            // ExchangeRate mappings
            CreateMap<ExchangeRate, ExchangeRateDto>();
            CreateMap<CreateExchangeRateDto, ExchangeRate>();
            CreateMap<UpdateExchangeRateDto, ExchangeRate>();

            // Nationality mappings
            CreateMap<Nationality, NationalityDto>();
            CreateMap<CreateNationalityDto, Nationality>();
            CreateMap<UpdateNationalityDto, Nationality>();

            // Currency mappings
            CreateMap<Currency, CurrencyDto>();
            CreateMap<CreateCurrencyDto, Currency>();
            CreateMap<UpdateCurrencyDto, Currency>();

            // User mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : ""))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch != null ? src.Branch.Name : ""));
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Invoice mappings
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.PassCompanyName, opt => opt.MapFrom(src => src.PassCompany != null ? src.PassCompany.Name : ""));
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceDto, Invoice>();

            // InvoiceDetail mappings
            CreateMap<InvoiceDetail, InvoiceDetailDto>()
                .ForMember(dest => dest.TourScheduleInfo, opt => opt.MapFrom(src => src.TourSchedule != null && src.TourSchedule.Tour != null ? $"{src.TourSchedule.Tour.Name} - {src.TourSchedule.TourDate:dd.MM.yyyy}" : ""));
            CreateMap<CreateInvoiceDetailDto, InvoiceDetail>();
            CreateMap<UpdateInvoiceDetailDto, InvoiceDetail>();

            // BusAssignment mappings
            CreateMap<BusAssignment, BusAssignmentDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.TourSchedule != null && src.TourSchedule.Tour != null ? src.TourSchedule.Tour.Name : ""))
                .ForMember(dest => dest.TourDate, opt => opt.MapFrom(src => src.TourSchedule != null ? src.TourSchedule.TourDate : DateTime.MinValue))
                .ForMember(dest => dest.BusPlateNumber, opt => opt.MapFrom(src => src.Bus != null ? src.Bus.PlateNumber : ""))
                .ForMember(dest => dest.BusModel, opt => opt.MapFrom(src => src.Bus != null ? src.Bus.Model : ""))
                .ForMember(dest => dest.BusCapacity, opt => opt.MapFrom(src => src.Bus != null ? src.Bus.Capacity : 0));

            // CustomerDistribution mappings
            CreateMap<CustomerDistribution, CustomerDistributionDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.TourSchedule != null && src.TourSchedule.Tour != null ? src.TourSchedule.Tour.Name : ""))
                .ForMember(dest => dest.TourDate, opt => opt.MapFrom(src => src.TourSchedule != null ? src.TourSchedule.TourDate : DateTime.MinValue))
                .ForMember(dest => dest.BusPlateNumber, opt => opt.MapFrom(src => src.Bus != null ? src.Bus.PlateNumber : ""))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Ticket != null ? src.Ticket.CustomerName : ""))
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Ticket != null && src.Ticket.Hotel != null ? src.Ticket.Hotel.Name : ""))
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(src => src.Ticket != null && src.Ticket.Hotel != null && src.Ticket.Hotel.Region != null ? src.Ticket.Hotel.Region.Name : ""));

            // CommissionCalculation mappings
            CreateMap<CommissionCalculation, CommissionCalculationDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : ""));

            // TourReport mappings
            CreateMap<TourReport, TourReportDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.TourSchedule != null && src.TourSchedule.Tour != null ? src.TourSchedule.Tour.Name : ""))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : ""));

            // FinancialReport mappings
            CreateMap<FinancialReport, FinancialReportDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : ""));

            // SystemLog mappings
            CreateMap<SystemLog, SystemLogDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : ""))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : ""));
        }
    }
} 