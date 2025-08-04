namespace SDTur.Web.Models.Auth
{
    public class LoginResponseViewModel
    {
        public bool Success { get; set; }
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public UserInfoViewModel User { get; set; } = new UserInfoViewModel();
        public string Message { get; set; } = string.Empty;
    }

    public class UserInfoViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 