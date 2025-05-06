using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditsController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditsController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAuditLogs()
        {
            var auditLogs = await _auditLogService.GetAllAuditLogsAsync();
            return Ok(auditLogs);
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAuditLogsByUser(int userId)
        {
            var auditLogs = await _auditLogService.GetAuditLogsByUserIdAsync(userId);
            return Ok(auditLogs);
        }

        [Authorize]
        [HttpGet("entity/{entityName}")]
        public async Task<IActionResult> GetAuditLogsByEntity(string entityName)
        {
            var auditLogs = await _auditLogService.GetAuditLogsByEntityAsync(entityName);
            return Ok(auditLogs);
        }
    }
}