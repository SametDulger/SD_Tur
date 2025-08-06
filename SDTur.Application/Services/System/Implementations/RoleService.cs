using SDTur.Application.DTOs.System.User;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Core.Interfaces.Core;
using SDTur.Core.Interfaces.System;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace SDTur.Application.Services.System.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RoleService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            try
            {
                _logger.LogDebug("Getting all roles");

                var roles = await _unitOfWork.Roles.GetAllAsync();
                var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);

                _logger.LogDebug("Retrieved {Count} roles", roleDtos.Count());
                return roleDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting all roles");
                return Enumerable.Empty<RoleDto>();
            }
        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogDebug("Getting role by ID: {RoleId}", id);

                if (id <= 0)
                {
                    _logger.LogWarning("GetByIdAsync called with invalid ID: {RoleId}", id);
                    return null;
                }

                var role = await _unitOfWork.Roles.GetByIdAsync(id);
                
                if (role == null)
                {
                    _logger.LogDebug("Role not found for ID: {RoleId}", id);
                    return null;
                }

                var roleDto = _mapper.Map<RoleDto>(role);
                _logger.LogDebug("Role found: {Name}, Id: {RoleId}", roleDto.Name, roleDto.Id);
                
                return roleDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting role by ID: {RoleId}", id);
                return null;
            }
        }

        public async Task<RoleDto?> CreateAsync(CreateRoleDto createRoleDto)
        {
            try
            {
                _logger.LogInformation("Creating new role: {Name}", createRoleDto.Name);

                if (createRoleDto == null)
                {
                    _logger.LogWarning("CreateAsync called with null role data");
                    return null;
                }

                var entity = _mapper.Map<SDTur.Core.Entities.System.Role>(createRoleDto);
                var created = await _unitOfWork.Roles.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var roleDto = _mapper.Map<RoleDto>(created);
                _logger.LogInformation("Role created successfully: {Name}, Id: {RoleId}", roleDto.Name, roleDto.Id);
                
                return roleDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while creating role: {Name}", createRoleDto?.Name);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(RoleDto roleDto)
        {
            try
            {
                _logger.LogInformation("Updating role: {Name}, Id: {RoleId}", roleDto.Name, roleDto.Id);

                if (roleDto == null || roleDto.Id <= 0)
                {
                    _logger.LogWarning("UpdateAsync called with invalid role data");
                    return false;
                }

                var entity = _mapper.Map<SDTur.Core.Entities.System.Role>(roleDto);
                var updated = await _unitOfWork.Roles.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Role updated successfully: {Name}, Id: {RoleId}", roleDto.Name, roleDto.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while updating role: {Name}, Id: {RoleId}", roleDto.Name, roleDto.Id);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting role with ID: {RoleId}", id);

                if (id <= 0)
                {
                    _logger.LogWarning("DeleteAsync called with invalid ID: {RoleId}", id);
                    return false;
                }

                await _unitOfWork.Roles.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Role deleted successfully: {RoleId}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while deleting role: {RoleId}", id);
                return false;
            }
        }
    }
} 