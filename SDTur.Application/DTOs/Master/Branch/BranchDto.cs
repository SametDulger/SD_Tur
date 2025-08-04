namespace SDTur.Application.DTOs.Master.Branch
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string? BranchCode { get; set; }
        public string? Name { get; set; }
        public string? BranchName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ManagerName { get; set; }
        public string? Manager { get; set; }
        public string? Description { get; set; }
        public bool IsMainBranch { get; set; }
        public string? RegionName { get; set; }
        public int EmployeeCount { get; set; }
        public bool IsActive { get; set; }
    }
} 