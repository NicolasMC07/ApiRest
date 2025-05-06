using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Interfaces;
using ApiRest.Models;

namespace ApiRest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public UserService(IUserRepository userRepository, IAuditLogRepository auditLogRepository)
        {
            _userRepository = userRepository;
            _auditLogRepository = auditLogRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> RegisterAsync(User user)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already in use");
            }

            var createdUser = await _userRepository.CreateAsync(user);


            await _auditLogRepository.CreateAsync(new AuditLog
            {
                UserId = createdUser.Id,
                EntityName = "User",
                EntityId = createdUser.Id,
                Action = AuditAction.Create,
                NewValues = $"User created with email: {createdUser.Email}"
            });

            return createdUser;
        }
    }
}