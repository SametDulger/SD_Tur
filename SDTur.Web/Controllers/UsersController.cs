using Microsoft.AspNetCore.Mvc;
using SDTur.Web.Models.System.Users;
using SDTur.Web.Services;

namespace SDTur.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IApiService _apiService;

        public UsersController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _apiService.GetAsync<List<UserViewModel>>("api/users");
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _apiService.GetAsync<UserViewModel>($"api/users/{id}");
            if (user == null)
                return NotFound();

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,FirstName,LastName,Email,Phone,EmployeeId,BranchId,Role,IsActive")] UserCreateViewModel UserCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<UserCreateViewModel, UserViewModel>("api/users", UserCreateViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(UserCreateViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _apiService.GetAsync<UserViewModel>($"api/users/{id}");
            if (user == null)
                return NotFound();

            var updateDto = new UserEditViewModel
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                IsActive = user.IsActive,
                EmployeeId = user.EmployeeId,
                BranchId = user.BranchId
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserEditViewModel updateDto)
        {
            if (id != updateDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _apiService.PutAsync<UserEditViewModel, UserViewModel>($"api/users/{id}", updateDto);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _apiService.GetAsync<UserViewModel>($"api/users/{id}");
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiService.DeleteAsync($"api/users/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
} 
