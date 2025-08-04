using SDTur.Application.DTOs.System.User;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Core.Interfaces.Core;
using SDTur.Core.Interfaces.System;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace SDTur.Application.Services.System.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto?> GetByUsernameAsync(string username)
        {
            try
            {
                _logger.LogDebug("Getting user by username: {Username}", username);

                if (string.IsNullOrWhiteSpace(username))
                {
                    _logger.LogWarning("GetByUsernameAsync called with empty username");
                    return null;
                }

                var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
                
                if (user == null)
                {
                    _logger.LogDebug("User not found for username: {Username}", username);
                    return null;
                }

                var userDto = _mapper.Map<UserDto>(user);
                _logger.LogDebug("User found: {Username}, Id: {UserId}", userDto.Username, userDto.Id);
                
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting user by username: {Username}", username);
                return null;
            }
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogDebug("Getting user by ID: {UserId}", id);

                if (id <= 0)
                {
                    _logger.LogWarning("GetByIdAsync called with invalid ID: {UserId}", id);
                    return null;
                }

                var user = await _unitOfWork.Users.GetByIdAsync(id);
                
                if (user == null)
                {
                    _logger.LogDebug("User not found for ID: {UserId}", id);
                    return null;
                }

                var userDto = _mapper.Map<UserDto>(user);
                _logger.LogDebug("User found: {Username}, Id: {UserId}", userDto.Username, userDto.Id);
                
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting user by ID: {UserId}", id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(UserDto userDto)
        {
            try
            {
                _logger.LogInformation("Updating user: {Username}, Id: {UserId}", userDto.Username, userDto.Id);

                if (userDto == null || userDto.Id <= 0)
                {
                    _logger.LogWarning("UpdateAsync called with invalid user data");
                    return false;
                }

                var entity = _mapper.Map<SDTur.Core.Entities.System.User>(userDto);
                var updated = await _unitOfWork.Users.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User updated successfully: {Username}, Id: {UserId}", userDto.Username, userDto.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while updating user: {Username}, Id: {UserId}", userDto.Username, userDto.Id);
                return false;
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            try
            {
                _logger.LogDebug("Getting all users");

                var users = await _unitOfWork.Users.GetAllAsync();
                var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

                _logger.LogDebug("Retrieved {Count} users", userDtos.Count());
                return userDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting all users");
                return Enumerable.Empty<UserDto>();
            }
        }

        public async Task<UserDto?> CreateAsync(CreateUserDto createUserDto)
        {
            try
            {
                _logger.LogInformation("Creating new user: {Username}", createUserDto.Username);

                if (createUserDto == null)
                {
                    _logger.LogWarning("CreateAsync called with null user data");
                    return null;
                }

                var entity = _mapper.Map<SDTur.Core.Entities.System.User>(createUserDto);
                var created = await _unitOfWork.Users.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var userDto = _mapper.Map<UserDto>(created);
                _logger.LogInformation("User created successfully: {Username}, Id: {UserId}", userDto.Username, userDto.Id);
                
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while creating user: {Username}", createUserDto?.Username);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user with ID: {UserId}", id);

                if (id <= 0)
                {
                    _logger.LogWarning("DeleteAsync called with invalid ID: {UserId}", id);
                    return false;
                }

                await _unitOfWork.Users.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User deleted successfully: {UserId}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while deleting user: {UserId}", id);
                return false;
            }
        }
    }
} 