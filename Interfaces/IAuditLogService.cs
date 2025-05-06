using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;

namespace ApiRest.Interfaces
{
     public interface IAuditLogService
    {
        Task<IEnumerable<AuditLog>> GetAllAuditLogsAsync();
        Task<IEnumerable<AuditLog>> GetAuditLogsByUserIdAsync(int userId);
        Task<IEnumerable<AuditLog>> GetAuditLogsByEntityAsync(string entityName);
    }
}