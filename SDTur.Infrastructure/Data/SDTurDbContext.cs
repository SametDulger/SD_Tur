using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Entities.Master;
using SDTur.Core.Entities.System;
using SDTur.Core.Entities.Tour;
using SDTur.Infrastructure.SeedData;

namespace SDTur.Infrastructure.Data
{
    public class SDTurDbContext : DbContext
    {
        public SDTurDbContext(DbContextOptions<SDTurDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            // Suppress PendingModelChangesWarning for seed data
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TourSchedule> TourSchedules { get; set; }
        public DbSet<ServiceSchedule> ServiceSchedules { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<TourExpense> TourExpenses { get; set; }
        public DbSet<TourIncome> TourIncomes { get; set; }
        public DbSet<PassCompany> PassCompanies { get; set; }
        public DbSet<PassAgreement> PassAgreements { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Cash> Cash { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TourOperation> TourOperations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<BusAssignment> BusAssignments { get; set; }
        public DbSet<CustomerDistribution> CustomerDistributions { get; set; }
        public DbSet<CommissionCalculation> CommissionCalculations { get; set; }
        public DbSet<TourReport> TourReports { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Branch)
                .WithMany(b => b.Employees)
                .HasForeignKey(e => e.BranchId);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Region)
                .WithMany(r => r.Hotels)
                .HasForeignKey(h => h.RegionId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Tour)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TourId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Branch)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.SoldTickets)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Hotel)
                .WithMany(h => h.Tickets)
                .HasForeignKey(t => t.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.ServiceSchedule)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.ServiceScheduleId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TourSchedule)
                .WithMany(ts => ts.Tickets)
                .HasForeignKey(t => t.TourScheduleId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Bus)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BusId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.PassCompany)
                .WithMany(pc => pc.Tickets)
                .HasForeignKey(t => t.PassCompanyId);

            modelBuilder.Entity<TourSchedule>()
                .HasOne(ts => ts.Tour)
                .WithMany(t => t.TourSchedules)
                .HasForeignKey(ts => ts.TourId);

            modelBuilder.Entity<ServiceSchedule>()
                .HasOne(ss => ss.Tour)
                .WithMany(t => t.ServiceSchedules)
                .HasForeignKey(ss => ss.TourId);

            modelBuilder.Entity<ServiceSchedule>()
                .HasOne(ss => ss.Region)
                .WithMany(r => r.ServiceSchedules)
                .HasForeignKey(ss => ss.RegionId);

            modelBuilder.Entity<TourExpense>()
                .HasOne(te => te.TourSchedule)
                .WithMany(ts => ts.TourExpenses)
                .HasForeignKey(te => te.TourScheduleId);

            modelBuilder.Entity<TourIncome>()
                .HasOne(ti => ti.TourSchedule)
                .WithMany(ts => ts.TourIncomes)
                .HasForeignKey(ti => ti.TourScheduleId);

            modelBuilder.Entity<PassAgreement>()
                .HasOne(pa => pa.PassCompany)
                .WithMany(pc => pc.PassAgreements)
                .HasForeignKey(pa => pa.PassCompanyId);

            modelBuilder.Entity<PassAgreement>()
                .HasOne(pa => pa.Tour)
                .WithMany()
                .HasForeignKey(pa => pa.TourId);

            modelBuilder.Entity<AccountTransaction>()
                .HasOne(at => at.PassCompany)
                .WithMany(pc => pc.AccountTransactions)
                .HasForeignKey(at => at.PassCompanyId);

            modelBuilder.Entity<AccountTransaction>()
                .HasOne(at => at.TourSchedule)
                .WithMany()
                .HasForeignKey(at => at.TourScheduleId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithMany()
                .HasForeignKey(u => u.EmployeeId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Branch)
                .WithMany()
                .HasForeignKey(u => u.BranchId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.PassCompany)
                .WithMany(pc => pc.Invoices)
                .HasForeignKey(i => i.PassCompanyId);

            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(id => id.Invoice)
                .WithMany(i => i.InvoiceDetails)
                .HasForeignKey(id => id.InvoiceId);

            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(id => id.TourSchedule)
                .WithMany()
                .HasForeignKey(id => id.TourScheduleId);

            modelBuilder.Entity<CustomerDistribution>()
                .HasOne(cd => cd.TourSchedule)
                .WithMany()
                .HasForeignKey(cd => cd.TourScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerDistribution>()
                .HasOne(cd => cd.Bus)
                .WithMany()
                .HasForeignKey(cd => cd.BusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerDistribution>()
                .HasOne(cd => cd.Ticket)
                .WithMany()
                .HasForeignKey(cd => cd.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerDistribution>()
                .HasOne(cd => cd.Employee)
                .WithMany()
                .HasForeignKey(cd => cd.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tour>()
                .HasOne(t => t.TourType)
                .WithMany(tt => tt.Tours)
                .HasForeignKey(t => t.TourTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure indexes
            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.TicketNumber)
                .IsUnique();

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.TourDate);

            modelBuilder.Entity<TourSchedule>()
                .HasIndex(ts => ts.TourDate);

            modelBuilder.Entity<ExchangeRate>()
                .HasIndex(er => new { er.FromCurrency, er.ToCurrency, er.Date });

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.InvoiceNumber)
                .IsUnique();

            // Configure soft delete filter
            modelBuilder.Entity<Tour>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<TourType>().HasQueryFilter(tt => !tt.IsDeleted);
            modelBuilder.Entity<Branch>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Region>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<Hotel>().HasQueryFilter(h => !h.IsDeleted);
            modelBuilder.Entity<Ticket>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<TourSchedule>().HasQueryFilter(ts => !ts.IsDeleted);
            modelBuilder.Entity<ServiceSchedule>().HasQueryFilter(ss => !ss.IsDeleted);
            modelBuilder.Entity<Bus>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<TourExpense>().HasQueryFilter(te => !te.IsDeleted);
            modelBuilder.Entity<TourIncome>().HasQueryFilter(ti => !ti.IsDeleted);
            modelBuilder.Entity<PassCompany>().HasQueryFilter(pc => !pc.IsDeleted);
            modelBuilder.Entity<PassAgreement>().HasQueryFilter(pa => !pa.IsDeleted);
            modelBuilder.Entity<AccountTransaction>().HasQueryFilter(at => !at.IsDeleted);
            modelBuilder.Entity<ExchangeRate>().HasQueryFilter(er => !er.IsDeleted);
            modelBuilder.Entity<Nationality>().HasQueryFilter(n => !n.IsDeleted);
            modelBuilder.Entity<Currency>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Invoice>().HasQueryFilter(i => !i.IsDeleted);
            modelBuilder.Entity<InvoiceDetail>().HasQueryFilter(id => !id.IsDeleted);
            modelBuilder.Entity<Cash>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Account>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<TourOperation>().HasQueryFilter(to => !to.IsDeleted);
            modelBuilder.Entity<Report>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<BusAssignment>().HasQueryFilter(ba => !ba.IsDeleted);
            modelBuilder.Entity<CustomerDistribution>().HasQueryFilter(cd => !cd.IsDeleted);
            modelBuilder.Entity<CommissionCalculation>().HasQueryFilter(cc => !cc.IsDeleted);
            modelBuilder.Entity<TourReport>().HasQueryFilter(tr => !tr.IsDeleted);
            modelBuilder.Entity<FinancialReport>().HasQueryFilter(fr => !fr.IsDeleted);
            modelBuilder.Entity<SystemLog>().HasQueryFilter(sl => !sl.IsDeleted);
            modelBuilder.Entity<RefreshToken>().HasQueryFilter(rt => !rt.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<Permission>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<CommissionCalculation>()
                .HasOne(cc => cc.Employee)
                .WithMany(e => e.CommissionCalculations)
                .HasForeignKey(cc => cc.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommissionCalculation>()
                .HasOne(cc => cc.Ticket)
                .WithMany(t => t.CommissionCalculations)
                .HasForeignKey(cc => cc.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommissionCalculation>()
                .HasOne(cc => cc.TourSchedule)
                .WithMany(ts => ts.CommissionCalculations)
                .HasForeignKey(cc => cc.TourScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            // RefreshToken relationships
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany()
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Role-Permission many-to-many relationship
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity(j => j.ToTable("RolePermissions"));

            // User-Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // User-RefreshToken relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            SDTur.Infrastructure.SeedData.SeedData.Seed(modelBuilder);
        }
    }
} 