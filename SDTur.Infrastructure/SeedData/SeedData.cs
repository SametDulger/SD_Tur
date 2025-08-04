using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Master;
using SDTur.Core.Entities.System;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Entities.Tour;
using SDTur.Application.Enums;
using SDTur.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SDTur.Infrastructure.SeedData
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Tour Types
            SeedTourTypes(modelBuilder);
            
            // Seed Currencies
            SeedCurrencies(modelBuilder);
            
            // Seed Regions
            SeedRegions(modelBuilder);
            
            // Seed Nationalities
            SeedNationalities(modelBuilder);
            
            // Seed Branches
            SeedBranches(modelBuilder);
            
            // Seed Employees
            SeedEmployees(modelBuilder);
            
            // Seed Hotels
            SeedHotels(modelBuilder);
            
            // Seed Buses
            SeedBuses(modelBuilder);
            
            // Seed Pass Companies
            SeedPassCompanies(modelBuilder);
            
            // Seed Users
            SeedUsers(modelBuilder);
            
            // Seed Accounts
            SeedAccounts(modelBuilder);
            
            // Seed Tours
            SeedTours(modelBuilder);
            
            // Seed Tour Schedules
            SeedTourSchedules(modelBuilder);
            
            // Seed Service Schedules
            SeedServiceSchedules(modelBuilder);
            
            // Seed Pass Agreements
            SeedPassAgreements(modelBuilder);
            
            // Seed Exchange Rates
            SeedExchangeRates(modelBuilder);
            
            // Seed Tour Expenses
            SeedTourExpenses(modelBuilder);
            
            // Seed Tour Incomes
            SeedTourIncomes(modelBuilder);
            
            // Seed Account Transactions
            SeedAccountTransactions(modelBuilder);
            
            // Seed Invoices
            SeedInvoices(modelBuilder);
            
            // Seed Invoice Details
            SeedInvoiceDetails(modelBuilder);
            
            // Seed Cash
            SeedCash(modelBuilder);
            
            // Seed Tour Operations
            SeedTourOperations(modelBuilder);
            
            // Seed Reports
            SeedReports(modelBuilder);
            
            // Seed Bus Assignments
            SeedBusAssignments(modelBuilder);
            
            // Seed Customer Distributions
            SeedCustomerDistributions(modelBuilder);
            
            // Seed Commission Calculations
            SeedCommissionCalculations(modelBuilder);
            
            // Seed Tour Reports
            SeedTourReports(modelBuilder);
            
            // Seed Financial Reports
            SeedFinancialReports(modelBuilder);
            
            // Seed System Logs
            SeedSystemLogs(modelBuilder);
            
            // Seed Tickets (en son eklenmeli çünkü diğer entity'lere bağımlı)
            SeedTickets(modelBuilder);
        }

        private static void SeedTourTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourType>().HasData(
                new TourType
                {
                    Id = 1,
                    Name = "Günlük Tur",
                    Description = "Tek günlük turlar",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 2,
                    Name = "Hafta Sonu Turu",
                    Description = "Hafta sonu turları",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 3,
                    Name = "Uzun Tur",
                    Description = "Uzun süreli turlar",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 4,
                    Name = "Kültür Turu",
                    Description = "Kültürel turlar",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 5,
                    Name = "Doğa Turu",
                    Description = "Doğa turları",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 6,
                    Name = "Şehir Turu",
                    Description = "Şehir turları",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 7,
                    Name = "Tarih Turu",
                    Description = "Tarihi turlar",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 8,
                    Name = "Deniz Turu",
                    Description = "Deniz turları",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 9,
                    Name = "Dağ Turu",
                    Description = "Dağ turları",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                },
                new TourType
                {
                    Id = 10,
                    Name = "Özel Tur",
                    Description = "Özel turlar",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = null
                }
            );
        }

        private static void SeedCurrencies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Code = "TRY", Name = "Türk Lirası", Symbol = "₺", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Currency { Id = 2, Code = "USD", Name = "Amerikan Doları", Symbol = "$", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Currency { Id = 3, Code = "EUR", Name = "Euro", Symbol = "€", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Currency { Id = 4, Name = "İngiliz Sterlini", Code = "GBP", Symbol = "£", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedRegions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = 1, Name = "Kapadokya", Description = "Kapadokya bölgesi", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Region { Id = 2, Name = "İstanbul", Description = "İstanbul şehri", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Region { Id = 3, Name = "Ege", Description = "Ege bölgesi", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Region { Id = 4, Name = "Akdeniz", Description = "Akdeniz Bölgesi", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Region { Id = 5, Name = "Karadeniz", Description = "Karadeniz Bölgesi", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Region { Id = 6, Name = "Doğu Anadolu", Description = "Doğu Anadolu Bölgesi", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Region { Id = 7, Name = "Güneydoğu Anadolu", Description = "Güneydoğu Anadolu Bölgesi", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedNationalities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nationality>().HasData(
                new Nationality { Id = 1, Code = "TR", Name = "Türk", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Nationality { Id = 2, Code = "DE", Name = "Alman", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Nationality { Id = 3, Code = "US", Name = "Amerikan", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Nationality { Id = 4, Name = "Fransız", Code = "FR", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Nationality { Id = 5, Name = "İtalyan", Code = "IT", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Nationality { Id = 6, Name = "Rus", Code = "RU", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Nationality { Id = 7, Name = "Arap", Code = "SA", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedBranches(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, Name = "Merkez Şube", Address = "İstanbul Merkez", Phone = "0212 000 00 01", Email = "merkez@sdtur.com", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Branch { Id = 2, Name = "Anadolu Şube", Address = "Anadolu Yakası", Phone = "0216 000 00 01", Email = "istanbul@sdtur.com", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Branch { Id = 3, Name = "Avrupa Şube", Address = "Avrupa Yakası", Phone = "0212 000 00 02", Email = "izmir@sdtur.com", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { 
                    Id = 1, 
                    FirstName = "Ahmet", 
                    LastName = "Yılmaz", 
                    Email = "ahmet@sdtur.com", 
                    Phone = "0532 000 00 01", 
                    Position = "Sales", 
                    Salary = 5000, 
                    CurrencyId = 1,
                    HireDate = new DateTime(2024, 1, 1).AddYears(-2),
                    CommissionRate = 10.0m,
                    BranchId = 1,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Employee { 
                    Id = 2, 
                    FirstName = "Ayşe", 
                    LastName = "Demir", 
                    Email = "ayse@sdtur.com", 
                    Phone = "0532 000 00 02", 
                    Position = "Operations", 
                    Salary = 4500, 
                    CurrencyId = 1,
                    HireDate = new DateTime(2024, 1, 1).AddYears(-1),
                    CommissionRate = 8.0m,
                    BranchId = 2,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Employee { 
                    Id = 3, 
                    FirstName = "Mehmet", 
                    LastName = "Kaya", 
                    Email = "mehmet@sdtur.com", 
                    Phone = "0532 000 00 03", 
                    Position = "Accounting", 
                    Salary = 6000, 
                    CurrencyId = 1,
                    HireDate = new DateTime(2024, 1, 1).AddMonths(-6),
                    CommissionRate = 5.0m,
                    BranchId = 3,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedHotels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Grand Hotel Ankara", Address = "Ankara Kızılay", Phone = "0312 123 45 67", RegionId = 1, Order = 1, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Hotel { Id = 2, Name = "Marmara Hotel İstanbul", Address = "İstanbul Taksim", Phone = "0212 123 45 67", RegionId = 2, Order = 1, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Hotel { Id = 3, Name = "Ege Hotel İzmir", Address = "İzmir Alsancak", Phone = "0232 123 45 67", RegionId = 3, Order = 1, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedBuses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>().HasData(
                new Bus { Id = 1, PlateNumber = "06 ABC 123", Model = "Mercedes Travego", Capacity = 49, DriverName = "Ahmet Şoför", DriverPhone = "0532 123 45 67", IsOwned = true, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Bus { Id = 2, PlateNumber = "34 DEF 456", Model = "Neoplan Cityliner", Capacity = 45, DriverName = "Mehmet Şoför", DriverPhone = "0533 123 45 67", IsOwned = true, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Bus { Id = 3, PlateNumber = "35 GHI 789", Model = "Setra ComfortClass", Capacity = 52, DriverName = "Ali Şoför", DriverPhone = "0534 123 45 67", IsOwned = false, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedPassCompanies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassCompany>().HasData(
                new PassCompany { Id = 1, Name = "Museum Pass", ContactPerson = "Ahmet Yılmaz", Phone = "0532 123 45 67", Email = "info@museumpass.com", Address = "İstanbul", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new PassCompany { Id = 2, Name = "Transport Pass", ContactPerson = "Ayşe Demir", Phone = "0533 123 45 67", Email = "info@transportpass.com", Address = "Ankara", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new PassCompany { Id = 3, Name = "Tourist Pass", ContactPerson = "Mehmet Kaya", Phone = "0534 123 45 67", Email = "info@touristpass.com", Address = "İzmir", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@sdtur.com", 
                    Phone = "0532 000 00 01", 
                    EmployeeId = 1,
                    BranchId = 1,
                    Role = "Admin",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new User { 
                    Id = 2, 
                    Username = "manager",
                    Password = BCrypt.Net.BCrypt.HashPassword("Manager123!"),
                    FirstName = "Manager",
                    LastName = "User",
                    Email = "manager@sdtur.com", 
                    Phone = "0532 000 00 02", 
                    EmployeeId = 2,
                    BranchId = 2,
                    Role = "Manager",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new User { 
                    Id = 3, 
                    Username = "sales",
                    Password = BCrypt.Net.BCrypt.HashPassword("Sales123!"),
                    FirstName = "Sales",
                    LastName = "User",
                    Email = "sales@sdtur.com", 
                    Phone = "0532 000 00 03", 
                    EmployeeId = 3,
                    BranchId = 3,
                    Role = "Sales",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedAccounts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account {
                    Id = 1,
                    AccountNumber = "1001",
                    AccountName = "Nakit Kasa",
                    AccountType = "Other",
                    ContactPerson = "Kasiyer",
                    Phone = "0212 000 00 01",
                    Email = "kasa@sdtur.com",
                    Address = "Merkez Kasa",
                    CurrentBalance = 0,
                    Currency = "TRY",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Account {
                    Id = 2,
                    AccountNumber = "1002",
                    AccountName = "Banka Hesabı",
                    AccountType = "Other",
                    ContactPerson = "Banka Yetkilisi",
                    Phone = "0212 000 00 02",
                    Email = "banka@sdtur.com",
                    Address = "Ziraat Bankası Şubesi",
                    CurrentBalance = 0,
                    Currency = "TRY",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Account {
                    Id = 3,
                    AccountNumber = "1003",
                    AccountName = "Döviz Hesabı",
                    AccountType = "Other",
                    ContactPerson = "Döviz Yetkilisi",
                    Phone = "0212 000 00 03",
                    Email = "doviz@sdtur.com",
                    Address = "Garanti Bankası Şubesi",
                    CurrentBalance = 0,
                    Currency = "USD",
                    IsActive = true,
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedTours(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>().HasData(
                new Tour { 
                    Id = 1, 
                    Name = "Kapadokya Turu", 
                    Description = "Kapadokya bölgesi 2 günlük tur", 
                    Duration = 48, 
                    Price = 1500, 
                    Currency = "TRY", 
                    TourTypeId = 3, // Uzun Tur
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Tour { 
                    Id = 2, 
                    Name = "İstanbul Turu", 
                    Description = "İstanbul şehir turu 1 gün", 
                    Duration = 24, 
                    Price = 800, 
                    Currency = "TRY", 
                    TourTypeId = 1, // Günlük Tur
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Tour { 
                    Id = 3, 
                    Name = "Ege Turu", 
                    Description = "Ege bölgesi 3 günlük tur", 
                    Duration = 72, 
                    Price = 2000, 
                    Currency = "TRY", 
                    TourTypeId = 3, // Uzun Tur
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedTourSchedules(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourSchedule>().HasData(
                new TourSchedule { 
                    Id = 1, 
                    TourId = 1, 
                    TourDate = new DateTime(2024, 1, 1).AddDays(7), 
                    IsCompleted = false, 
                    IsCancelled = false, 
                    TotalIncome = 0, 
                    TotalExpense = 0, 
                    NetProfit = 0, 
                    Notes = "Kapadokya turu programı",
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new TourSchedule { 
                    Id = 2, 
                    TourId = 1, 
                    TourDate = new DateTime(2024, 1, 1).AddDays(14), 
                    IsCompleted = false, 
                    IsCancelled = false, 
                    TotalIncome = 0, 
                    TotalExpense = 0, 
                    NetProfit = 0, 
                    Notes = "Kapadokya turu programı",
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new TourSchedule { 
                    Id = 3, 
                    TourId = 2, 
                    TourDate = new DateTime(2024, 1, 1).AddDays(5), 
                    IsCompleted = false, 
                    IsCancelled = false, 
                    TotalIncome = 0, 
                    TotalExpense = 0, 
                    NetProfit = 0, 
                    Notes = "İstanbul turu programı",
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new TourSchedule { 
                    Id = 4, 
                    TourId = 3, 
                    TourDate = new DateTime(2024, 1, 1).AddDays(10), 
                    IsCompleted = false, 
                    IsCancelled = false, 
                    TotalIncome = 0, 
                    TotalExpense = 0, 
                    NetProfit = 0, 
                    Notes = "Ege turu programı",
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedServiceSchedules(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceSchedule>().HasData(
                new ServiceSchedule { Id = 1, TourId = 1, RegionId = 1, ServiceDate = new DateTime(2024, 1, 1).AddDays(7), ServiceTime = new TimeSpan(8, 0, 0), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new ServiceSchedule { Id = 2, TourId = 1, RegionId = 1, ServiceDate = new DateTime(2024, 1, 1).AddDays(8), ServiceTime = new TimeSpan(9, 0, 0), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new ServiceSchedule { Id = 3, TourId = 2, RegionId = 2, ServiceDate = new DateTime(2024, 1, 1).AddDays(5), ServiceTime = new TimeSpan(10, 0, 0), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new ServiceSchedule { Id = 4, TourId = 3, RegionId = 3, ServiceDate = new DateTime(2024, 1, 1).AddDays(10), ServiceTime = new TimeSpan(7, 0, 0), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedPassAgreements(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassAgreement>().HasData(
                new PassAgreement { Id = 1, PassCompanyId = 1, TourId = 1, OutgoingFullPrice = 1500, OutgoingHalfPrice = 750, IncomingFullPrice = 1400, IncomingHalfPrice = 700, Currency = "TRY", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new PassAgreement { Id = 2, PassCompanyId = 2, TourId = 2, OutgoingFullPrice = 800, OutgoingHalfPrice = 400, IncomingFullPrice = 750, IncomingHalfPrice = 375, Currency = "TRY", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new PassAgreement { Id = 3, PassCompanyId = 3, TourId = 3, OutgoingFullPrice = 2000, OutgoingHalfPrice = 1000, IncomingFullPrice = 1800, IncomingHalfPrice = 900, Currency = "TRY", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedExchangeRates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate { Id = 1, FromCurrency = "TRY", ToCurrency = "USD", Rate = 0.035m, RateDate = new DateTime(2024, 1, 1).Date, Date = new DateTime(2024, 1, 1).Date, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new ExchangeRate { Id = 2, FromCurrency = "TRY", ToCurrency = "EUR", Rate = 0.032m, RateDate = new DateTime(2024, 1, 1).Date, Date = new DateTime(2024, 1, 1).Date, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new ExchangeRate { Id = 3, FromCurrency = "USD", ToCurrency = "TRY", Rate = 28.50m, RateDate = new DateTime(2024, 1, 1).Date, Date = new DateTime(2024, 1, 1).Date, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new ExchangeRate { Id = 4, FromCurrency = "EUR", ToCurrency = "TRY", Rate = 31.25m, RateDate = new DateTime(2024, 1, 1).Date, Date = new DateTime(2024, 1, 1).Date, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedTourExpenses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourExpense>().HasData(
                new TourExpense { Id = 1, TourScheduleId = 1, Description = "Otobüs kirası", Amount = 5000, Currency = "TRY", Category = "Other", ExpenseDate = new DateTime(2024, 1, 1).AddDays(7), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new TourExpense { Id = 2, TourScheduleId = 1, Description = "Rehber ücreti", Amount = 1500, Currency = "TRY", Category = "Other", ExpenseDate = new DateTime(2024, 1, 1).AddDays(7), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new TourExpense { Id = 3, TourScheduleId = 2, Description = "Otobüs kirası", Amount = 5000, Currency = "TRY", Category = "Other", ExpenseDate = new DateTime(2024, 1, 1).AddDays(14), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new TourExpense { Id = 4, TourScheduleId = 3, Description = "Transfer ücreti", Amount = 2000, Currency = "TRY", Category = "Other", ExpenseDate = new DateTime(2024, 1, 1).AddDays(5), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedTourIncomes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourIncome>().HasData(
                new TourIncome { Id = 1, TourScheduleId = 1, Description = "Bilet satışı", Amount = 45000, Currency = "TRY", Category = "Ticket", IncomeDate = new DateTime(2024, 1, 1).AddDays(7), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new TourIncome { Id = 2, TourScheduleId = 2, Description = "Bilet satışı", Amount = 30000, Currency = "TRY", Category = "Ticket", IncomeDate = new DateTime(2024, 1, 1).AddDays(14), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new TourIncome { Id = 3, TourScheduleId = 3, Description = "Bilet satışı", Amount = 20000, Currency = "TRY", Category = "Ticket", IncomeDate = new DateTime(2024, 1, 1).AddDays(5), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new TourIncome { Id = 4, TourScheduleId = 4, Description = "Bilet satışı", Amount = 70000, Currency = "TRY", Category = "Ticket", IncomeDate = new DateTime(2024, 1, 1).AddDays(10), IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedAccountTransactions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTransaction>().HasData(
                new AccountTransaction { Id = 1, AccountId = 1, PassCompanyId = 1, TourScheduleId = 1, Amount = 5000, TransactionType = TransactionType.Debit.ToString(), TransactionDate = new DateTime(2024, 1, 1), Currency = "TRY", Description = "Otobüs kirası ödemesi", Reference = "REF-001", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new AccountTransaction { Id = 2, AccountId = 1, PassCompanyId = null, TourScheduleId = 1, Amount = 45000, TransactionType = TransactionType.Credit.ToString(), TransactionDate = new DateTime(2024, 1, 1), Currency = "TRY", Description = "Bilet satış geliri", Reference = "REF-002", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new AccountTransaction { Id = 3, AccountId = 2, PassCompanyId = 2, TourScheduleId = 2, Amount = 30000, TransactionType = TransactionType.Credit.ToString(), TransactionDate = new DateTime(2024, 1, 1), Currency = "USD", Description = "Bilet satış geliri", Reference = "REF-003", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedInvoices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { 
                    Id = 1, 
                    InvoiceNumber = "INV-2024-001",
                    InvoiceDate = new DateTime(2024, 1, 1),
                    PassCompanyId = 1, 
                    TotalAmount = 45000, 
                    Currency = "TRY", 
                    Status = "Paid",
                    Notes = "Kapadokya turu faturası",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Invoice { 
                    Id = 2, 
                    InvoiceNumber = "INV-2024-002",
                    InvoiceDate = new DateTime(2024, 1, 1),
                    PassCompanyId = 2, 
                    TotalAmount = 20000, 
                    Currency = "TRY", 
                    Status = "Paid",
                    Notes = "İstanbul turu faturası",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Invoice { 
                    Id = 3, 
                    InvoiceNumber = "INV-2024-003",
                    InvoiceDate = new DateTime(2024, 1, 1),
                    PassCompanyId = 3, 
                    TotalAmount = 70000, 
                    Currency = "TRY", 
                    Status = "Paid",
                    Notes = "Ege turu faturası",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedInvoiceDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>().HasData(
                new InvoiceDetail { 
                    Id = 1, 
                    InvoiceId = 1, 
                    TourScheduleId = 1, 
                    Description = "Kapadokya Turu", 
                    Amount = 45000, 
                    Currency = "TRY", 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new InvoiceDetail { 
                    Id = 2, 
                    InvoiceId = 2, 
                    TourScheduleId = 3, 
                    Description = "İstanbul Turu", 
                    Amount = 20000, 
                    Currency = "TRY", 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new InvoiceDetail { 
                    Id = 3, 
                    InvoiceId = 3, 
                    TourScheduleId = 4, 
                    Description = "Ege Turu", 
                    Amount = 70000, 
                    Currency = "TRY", 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedCash(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cash>().HasData(
                new Cash { 
                    Id = 1, 
                    Amount = 50000, 
                    Currency = "TRY", 
                    TransactionDate = new DateTime(2024, 1, 1), 
                    TransactionType = "Income",
                    Description = "Günlük nakit", 
                    Category = "Manual",
                    IsAutomatic = false,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Cash { 
                    Id = 2, 
                    Amount = 1000, 
                    Currency = "USD", 
                    TransactionDate = new DateTime(2024, 1, 1), 
                    TransactionType = "Income",
                    Description = "Döviz nakit", 
                    Category = "Manual",
                    IsAutomatic = false,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Cash { 
                    Id = 3, 
                    Amount = 500, 
                    Currency = "EUR", 
                    TransactionDate = new DateTime(2024, 1, 1), 
                    TransactionType = "Income",
                    Description = "Euro nakit", 
                    Category = "Manual",
                    IsAutomatic = false,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedTourOperations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourOperation>().HasData(
                new TourOperation { 
                    Id = 1, 
                    TourScheduleId = 1, 
                    BusId = 1, 
                    EmployeeId = 1, 
                    OperationType = "Başlangıç", 
                    OperationDate = new DateTime(2024, 1, 1).AddDays(7), 
                    Status = "Started",
                    Notes = "Tur başladı", 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1), 
                    IsDeleted = false
                },
                new TourOperation { 
                    Id = 2, 
                    TourScheduleId = 1, 
                    BusId = 1, 
                    EmployeeId = 1, 
                    OperationType = "Bitiş", 
                    OperationDate = new DateTime(2024, 1, 1).AddDays(9), 
                    Status = "Completed",
                    Notes = "Tur bitti", 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1), 
                    IsDeleted = false
                },
                new TourOperation { 
                    Id = 3, 
                    TourScheduleId = 2, 
                    BusId = 2, 
                    EmployeeId = 2, 
                    OperationType = "Başlangıç", 
                    OperationDate = new DateTime(2024, 1, 1).AddDays(14), 
                    Status = "Started",
                    Notes = "Tur başladı", 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1), 
                    IsDeleted = false
                }
            );
        }

        private static void SeedReports(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().HasData(
                new Report { 
                    Id = 1, 
                    ReportName = "Aylık Satış Raporu", 
                    ReportType = "Satış", 
                    ReportDate = new DateTime(2024, 1, 1), 
                    Parameters = "{}", 
                    GeneratedBy = "System",
                    FilePath = "/reports/monthly-sales.pdf",
                    FileType = "PDF",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Report { 
                    Id = 2, 
                    ReportName = "Günlük Gelir Raporu", 
                    ReportType = "Gelir", 
                    ReportDate = new DateTime(2024, 1, 1), 
                    Parameters = "{}", 
                    GeneratedBy = "System",
                    FilePath = "/reports/daily-income.pdf",
                    FileType = "PDF",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new Report { 
                    Id = 3, 
                    ReportName = "Haftalık Kapasite Raporu", 
                    ReportType = "Kapasite", 
                    ReportDate = new DateTime(2024, 1, 1), 
                    Parameters = "{}", 
                    GeneratedBy = "System",
                    FilePath = "/reports/weekly-capacity.pdf",
                    FileType = "PDF",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedBusAssignments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusAssignment>().HasData(
                new BusAssignment { 
                    Id = 1, 
                    BusId = 1, 
                    TourScheduleId = 1, 
                    EmployeeId = 1,
                    AssignmentDate = new DateTime(2024, 1, 1).AddDays(7), 
                    Status = "Assigned",
                    Notes = "Kapadokya turu için otobüs ataması",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new BusAssignment { 
                    Id = 2, 
                    BusId = 2, 
                    TourScheduleId = 2, 
                    EmployeeId = 2,
                    AssignmentDate = new DateTime(2024, 1, 1).AddDays(14), 
                    Status = "Assigned",
                    Notes = "İstanbul turu için otobüs ataması",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new BusAssignment { 
                    Id = 3, 
                    BusId = 3, 
                    TourScheduleId = 3, 
                    EmployeeId = 3,
                    AssignmentDate = new DateTime(2024, 1, 1).AddDays(5), 
                    Status = "Assigned",
                    Notes = "Ege turu için otobüs ataması",
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedCustomerDistributions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDistribution>().HasData(
                new CustomerDistribution { Id = 1, TourScheduleId = 1, BusId = 1, TicketId = 1, EmployeeId = 1, DistributionDate = new DateTime(2024, 1, 1), Status = "Assigned", Notes = "Müşteri dağıtımı yapıldı", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new CustomerDistribution { Id = 2, TourScheduleId = 1, BusId = 1, TicketId = 2, EmployeeId = 1, DistributionDate = new DateTime(2024, 1, 1), Status = "Assigned", Notes = "Müşteri dağıtımı yapıldı", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new CustomerDistribution { Id = 3, TourScheduleId = 2, BusId = 2, TicketId = 3, EmployeeId = 2, DistributionDate = new DateTime(2024, 1, 1), Status = "Assigned", Notes = "Müşteri dağıtımı yapıldı", IsActive = true, CreatedDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }

        private static void SeedCommissionCalculations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommissionCalculation>().HasData(
                new CommissionCalculation { 
                    Id = 1, 
                    EmployeeId = 1, 
                    TicketId = 1, 
                    TourScheduleId = 1, 
                    CommissionAmount = 150, 
                    CommissionRate = 10.0m, 
                    Currency = "TRY",
                    CommissionType = "Percentage",
                    Status = "Approved",
                    Notes = "Kapadokya turu komisyonu",
                    CalculationDate = new DateTime(2024, 1, 1), 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new CommissionCalculation { 
                    Id = 2, 
                    EmployeeId = 1, 
                    TicketId = 2, 
                    TourScheduleId = 1, 
                    CommissionAmount = 150, 
                    CommissionRate = 10.0m, 
                    Currency = "TRY",
                    CommissionType = "Percentage",
                    Status = "Approved",
                    Notes = "Kapadokya turu komisyonu",
                    CalculationDate = new DateTime(2024, 1, 1), 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new CommissionCalculation { 
                    Id = 3, 
                    EmployeeId = 2, 
                    TicketId = 3, 
                    TourScheduleId = 2, 
                    CommissionAmount = 120, 
                    CommissionRate = 8.0m, 
                    Currency = "TRY",
                    CommissionType = "Percentage",
                    Status = "Approved",
                    Notes = "İstanbul turu komisyonu",
                    CalculationDate = new DateTime(2024, 1, 1), 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedTourReports(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourReport>().HasData(
                new TourReport { 
                    Id = 1, 
                    TourScheduleId = 1, 
                    ReportDate = new DateTime(2024, 1, 1), 
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2024, 1, 1),
                    TotalIncome = 45000, 
                    TotalExpense = 6500, 
                    NetProfit = 38500, 
                    TotalCustomers = 30, 
                    FullPriceCustomers = 25,
                    HalfPriceCustomers = 5,
                    GuestCustomers = 0,
                    Currency = "TRY",
                    ReportType = "Summary",
                    ReportData = "{}",
                    Status = "Completed",
                    EmployeeId = 1,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new TourReport { 
                    Id = 2, 
                    TourScheduleId = 2, 
                    ReportDate = new DateTime(2024, 1, 1), 
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2024, 1, 1),
                    TotalIncome = 30000, 
                    TotalExpense = 5000, 
                    NetProfit = 25000, 
                    TotalCustomers = 20, 
                    FullPriceCustomers = 18,
                    HalfPriceCustomers = 2,
                    GuestCustomers = 0,
                    Currency = "TRY",
                    ReportType = "Summary",
                    ReportData = "{}",
                    Status = "Completed",
                    EmployeeId = 1,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new TourReport { 
                    Id = 3, 
                    TourScheduleId = 3, 
                    ReportDate = new DateTime(2024, 1, 1), 
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2024, 1, 1),
                    TotalIncome = 20000, 
                    TotalExpense = 2000, 
                    NetProfit = 18000, 
                    TotalCustomers = 25, 
                    FullPriceCustomers = 20,
                    HalfPriceCustomers = 5,
                    GuestCustomers = 0,
                    Currency = "TRY",
                    ReportType = "Summary",
                    ReportData = "{}",
                    Status = "Completed",
                    EmployeeId = 2,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedFinancialReports(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialReport>().HasData(
                new FinancialReport { 
                    Id = 1, 
                    ReportType = "Daily",
                    ReportDate = new DateTime(2024, 1, 1), 
                    StartDate = new DateTime(2024, 1, 1).Date,
                    EndDate = new DateTime(2024, 1, 1).Date,
                    TotalIncome = 95000, 
                    TotalExpense = 13500, 
                    NetProfit = 81500, 
                    Currency = "TRY", 
                    ReportData = "{}",
                    Status = "Final",
                    EmployeeId = 1,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new FinancialReport { 
                    Id = 2, 
                    ReportType = "Weekly",
                    ReportDate = new DateTime(2024, 1, 1).AddDays(-7), 
                    StartDate = new DateTime(2024, 1, 1).AddDays(-7).Date,
                    EndDate = new DateTime(2024, 1, 1).AddDays(-1).Date,
                    TotalIncome = 80000, 
                    TotalExpense = 12000, 
                    NetProfit = 68000, 
                    Currency = "TRY", 
                    ReportData = "{}",
                    Status = "Final",
                    EmployeeId = 1,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new FinancialReport { 
                    Id = 3, 
                    ReportType = "Monthly",
                    ReportDate = new DateTime(2024, 1, 1).AddDays(-14), 
                    StartDate = new DateTime(2024, 1, 1).AddDays(-30).Date,
                    EndDate = new DateTime(2024, 1, 1).AddDays(-15).Date,
                    TotalIncome = 70000, 
                    TotalExpense = 10000, 
                    NetProfit = 60000, 
                    Currency = "TRY", 
                    ReportData = "{}",
                    Status = "Final",
                    EmployeeId = 2,
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedSystemLogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemLog>().HasData(
                new SystemLog { 
                    Id = 1, 
                    LogLevel = "Info", 
                    Category = "System",
                    Action = "Startup",
                    Message = "Sistem başlatıldı", 
                    Details = "{}",
                    IpAddress = "::1",
                    UserAgent = "System",
                    LogDate = new DateTime(2024, 1, 1), 
                    UserId = 1, 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new SystemLog { 
                    Id = 2, 
                    LogLevel = "Info", 
                    Category = "User",
                    Action = "Create",
                    Message = "Yeni kullanıcı eklendi", 
                    Details = "{}",
                    IpAddress = "::1",
                    UserAgent = "System",
                    LogDate = new DateTime(2024, 1, 1), 
                    UserId = 1, 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                },
                new SystemLog { 
                    Id = 3, 
                    LogLevel = "Warning", 
                    Category = "Business",
                    Action = "Balance",
                    Message = "Düşük bakiye uyarısı", 
                    Details = "{}",
                    IpAddress = "::1",
                    UserAgent = "System",
                    LogDate = new DateTime(2024, 1, 1), 
                    UserId = 2, 
                    IsActive = true, 
                    CreatedDate = new DateTime(2024, 1, 1),
                    IsDeleted = false
                }
            );
        }

        private static void SeedTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { 
                    Id = 1, 
                    TicketNumber = "TKT-2024-001", 
                    TourId = 1, 
                    BranchId = 1, 
                    EmployeeId = 1, 
                    HotelId = 1, 
                    ServiceScheduleId = 1, 
                    TourScheduleId = 1, 
                    BusId = 1, 
                    PassCompanyId = 1, 
                    CustomerName = "Ahmet Yılmaz", 
                    Nationality = "TR", 
                    RoomNumber = "101",
                    RequiresService = false,
                    TourDate = new DateTime(2024, 1, 1).AddDays(7), 
                    FullCount = 2, 
                    HalfCount = 0, 
                    GuestCount = 0, 
                    TotalAmount = 3000, 
                    PaidAmount = 3000, 
                    RestAmount = 0, 
                    Currency = "TRY", 
                    Notes = "Kapadokya turu bileti",
                    IsCancelled = false,
                    IsPassTicket = false,
                    IsIncomingPass = false,
                    SaleDate = new DateTime(2024, 1, 1), 
                    CreatedDate = new DateTime(2024, 1, 1), 
                    IsDeleted = false
                },
                new Ticket { 
                    Id = 2, 
                    TicketNumber = "TKT-2024-002", 
                    TourId = 1, 
                    BranchId = 1, 
                    EmployeeId = 1, 
                    HotelId = 1, 
                    ServiceScheduleId = 1, 
                    TourScheduleId = 1, 
                    BusId = 1, 
                    PassCompanyId = 1, 
                    CustomerName = "Ayşe Demir", 
                    Nationality = "TR", 
                    RoomNumber = "102",
                    RequiresService = false,
                    TourDate = new DateTime(2024, 1, 1).AddDays(7), 
                    FullCount = 1, 
                    HalfCount = 1, 
                    GuestCount = 0, 
                    TotalAmount = 2250, 
                    PaidAmount = 2250, 
                    RestAmount = 0, 
                    Currency = "TRY", 
                    Notes = "Kapadokya turu bileti",
                    IsCancelled = false,
                    IsPassTicket = false,
                    IsIncomingPass = false,
                    SaleDate = new DateTime(2024, 1, 1), 
                    CreatedDate = new DateTime(2024, 1, 1), 
                    IsDeleted = false
                },
                new Ticket { 
                    Id = 3, 
                    TicketNumber = "TKT-2024-003", 
                    TourId = 2, 
                    BranchId = 2, 
                    EmployeeId = 2, 
                    HotelId = 2, 
                    ServiceScheduleId = 3, 
                    TourScheduleId = 3, 
                    BusId = 2, 
                    PassCompanyId = 2, 
                    CustomerName = "Mehmet Kaya", 
                    Nationality = "DE", 
                    RoomNumber = "201",
                    RequiresService = false,
                    TourDate = new DateTime(2024, 1, 1).AddDays(5), 
                    FullCount = 3, 
                    HalfCount = 0, 
                    GuestCount = 0, 
                    TotalAmount = 2400, 
                    PaidAmount = 2400, 
                    RestAmount = 0, 
                    Currency = "TRY", 
                    Notes = "İstanbul turu bileti",
                    IsCancelled = false,
                    IsPassTicket = false,
                    IsIncomingPass = false,
                    SaleDate = new DateTime(2024, 1, 1), 
                    CreatedDate = new DateTime(2024, 1, 1), 
                    IsDeleted = false
                },
                new Ticket { 
                    Id = 4, 
                    TicketNumber = "TKT-2024-004", 
                    TourId = 3, 
                    BranchId = 3, 
                    EmployeeId = 3, 
                    HotelId = 3, 
                    ServiceScheduleId = 4, 
                    TourScheduleId = 4, 
                    BusId = 3, 
                    PassCompanyId = 3, 
                    CustomerName = "Fatma Öz", 
                    Nationality = "TR", 
                    RoomNumber = "301",
                    RequiresService = false,
                    TourDate = new DateTime(2024, 1, 1).AddDays(10), 
                    FullCount = 4, 
                    HalfCount = 0, 
                    GuestCount = 0, 
                    TotalAmount = 8000, 
                    PaidAmount = 8000, 
                    RestAmount = 0, 
                    Currency = "TRY", 
                    Notes = "Ege turu bileti",
                    IsCancelled = false,
                    IsPassTicket = false,
                    IsIncomingPass = false,
                    SaleDate = new DateTime(2024, 1, 1), 
                    CreatedDate = new DateTime(2024, 1, 1), 
                    IsDeleted = false
                }
            );
        }

        public static async Task SeedUsers(SDTurDbContext context)
        {
            try
            {
                // Check if users already exist
                if (await context.Users.AnyAsync())
                {
                    return; // Users already seeded
                }

                // Create default users with secure passwords
                var users = new List<User>
                {
                    new User
                    {
                        Username = "admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                        FirstName = "Admin",
                        LastName = "User",
                        Email = "admin@sdtur.com",
                        Phone = "+90 555 123 4567",
                        Role = "Admin",
                        IsActive = true,
                        CreatedDate = new DateTime(2024, 1, 1),
                        IsDeleted = false
                    },
                    new User
                    {
                        Username = "manager",
                        Password = BCrypt.Net.BCrypt.HashPassword("Manager123!"),
                        FirstName = "Manager",
                        LastName = "User",
                        Email = "manager@sdtur.com",
                        Phone = "+90 555 234 5678",
                        Role = "Manager",
                        IsActive = true,
                        CreatedDate = new DateTime(2024, 1, 1),
                        IsDeleted = false
                    },
                    new User
                    {
                        Username = "sales",
                        Password = BCrypt.Net.BCrypt.HashPassword("Sales123!"),
                        FirstName = "Sales",
                        LastName = "User",
                        Email = "sales@sdtur.com",
                        Phone = "+90 555 345 6789",
                        Role = "Sales",
                        IsActive = true,
                        CreatedDate = new DateTime(2024, 1, 1),
                        IsDeleted = false
                    }
                };

                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }
            catch
            {
                // Log error but don't throw to prevent application startup failure
                // In a real application, you might want to use a logger here
            }
        }
    }
} 
