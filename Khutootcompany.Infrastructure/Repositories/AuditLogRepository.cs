<<<<<<< HEAD
﻿using Khutootcompany.Domain.Entities;
using Khutootcompany.Domain.Interfaces;
using Khutootcompany.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
=======
﻿using System;
>>>>>>> f665a7ad4fe8f29d70fc7dd3bcbd1b099de57b42
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khutootcompany.Infrastructure.Repositories
{
<<<<<<< HEAD
    public class AuditLogRepository : GenericRepository<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<AuditLog>> GetLogsByEntityAsync(string entityName, int entityId)
        {
            return await _dbSet
                .Where(a => a.EntityName == entityName && a.EntityId == entityId)
                .OrderByDescending(a => a.PerformedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByUserAsync(string username)
        {
            return await _dbSet
                .Where(a => a.PerformedBy == username)
                .OrderByDescending(a => a.PerformedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(a => a.PerformedAt >= startDate && a.PerformedAt <= endDate)
                .OrderByDescending(a => a.PerformedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 100)
        {
            return await _dbSet
                .OrderByDescending(a => a.PerformedAt)
                .Take(count)
                .ToListAsync();
        }
=======
    internal class AuditLogRepository
    {
>>>>>>> f665a7ad4fe8f29d70fc7dd3bcbd1b099de57b42
    }
}
