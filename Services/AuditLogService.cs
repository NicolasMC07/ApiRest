using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Interfaces;
using ApiRest.Models;

namespace ApiRest.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<IEnumerable<AuditLog>> GetAllAuditLogsAsync()
        {
            return await _auditLogRepository.GetAllAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetAuditLogsByEntityAsync(string entityName)
        {
            return await _auditLogRepository.GetByEntityAsync(entityName);
        }

        public async Task<IEnumerable<AuditLog>> GetAuditLogsByUserIdAsync(int userId)
        {
            return await _auditLogRepository.GetByUserIdAsync(userId);
        }
    }
}