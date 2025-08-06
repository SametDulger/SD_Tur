using FluentValidation;
using SDTur.Application.DTOs.System.User;

namespace SDTur.Application.Validators
{
    public class UserCreateDtoValidator : AbstractValidator<CreateUserDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
                .Length(3, 50).WithMessage("Kullanıcı adı 3-50 karakter arasında olmalıdır")
                .Matches("^[a-zA-Z0-9_]+$").WithMessage("Kullanıcı adı sadece harf, rakam ve alt çizgi içerebilir");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz")
                .Length(2, 50).WithMessage("Ad 2-50 karakter arasında olmalıdır")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Ad sadece harf içerebilir");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz")
                .Length(2, 50).WithMessage("Soyad 2-50 karakter arasında olmalıdır")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Soyad sadece harf içerebilir");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz")
                .MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Telefon en fazla 20 karakter olabilir")
                .Matches("^[0-9+\\-\\s()]+$").When(x => !string.IsNullOrEmpty(x.Phone))
                .WithMessage("Geçerli bir telefon numarası giriniz");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("Geçerli bir rol seçilmelidir");

            RuleFor(x => x.BranchId)
                .GreaterThan(0).When(x => x.BranchId.HasValue)
                .WithMessage("Geçerli bir şube seçilmelidir");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).When(x => x.EmployeeId.HasValue)
                .WithMessage("Geçerli bir çalışan seçilmelidir");
        }
    }
} 