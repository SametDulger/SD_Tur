using AutoMapper;
using SDTur.Application.DTOs.System.User;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.System.Interfaces;

namespace SDTur.Application.Services.System.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetActiveUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> GetActiveAsync()
        {
            var users = await _unitOfWork.Users.GetActiveUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetUserWithDetailsAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            Console.WriteLine($"UserService.GetByUsernameAsync called with username: {username}");
            try
            {
                var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
                Console.WriteLine($"UnitOfWork.Users.GetUserByUsernameAsync completed");
                
                if (user == null)
                {
                    Console.WriteLine("User entity is null");
                    return null;
                }
                
                Console.WriteLine($"User entity found: Id={user.Id}, Username={user.Username}");
                var userDto = _mapper.Map<UserDto>(user);
                Console.WriteLine($"UserDto mapped: Id={userDto.Id}, Username={userDto.Username}");
                return userDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetByUsernameAsync: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<UserDto> CreateAsync(CreateUserDto createDto)
        {
            var user = _mapper.Map<User>(createDto);
            user.IsActive = true;
            
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateAsync(UpdateUserDto updateDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(updateDto.Id);
            if (user == null)
                throw new ArgumentException("Kullanıcı bulunamadı");

            _mapper.Map(updateDto, user);
            
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<UserDto>(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Users.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetByRoleAsync(string role)
        {
            var users = await _unitOfWork.Users.GetUsersByRoleAsync(role);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
} 