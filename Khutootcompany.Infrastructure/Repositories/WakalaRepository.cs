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
    public class WakalaRepository : GenericRepository<Wakala>, IWakalaRepository
    {
        public WakalaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Wakala>> GetExpiredWakalatAsync()
        {
            var today = DateTime.Today;
            return await _dbSet
                .Where(w => w.ExpiryDate < today)
                .Include(w => w.Employee)
                .Include(w => w.Truck)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wakala>> GetExpiringSoonWakalatAsync(int daysThreshold = 30)
        {
            var today = DateTime.Today;
            var futureDate = today.AddDays(daysThreshold);
            return await _dbSet
                .Where(w => w.ExpiryDate >= today && w.ExpiryDate <= futureDate)
                .Include(w => w.Employee)
                .Include(w => w.Truck)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wakala>> GetGeneralWakalatAsync()
        {
            return await _dbSet
                .Where(w => w.IsGeneral && w.TruckId == null)
                .Include(w => w.Employee)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wakala>> GetWakalatByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Where(w => w.EmployeeId == employeeId)
                .Include(w => w.Truck)
                .OrderByDescending(w => w.IssueDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wakala>> GetWakalatByTruckAsync(int truckId)
        {
            return await _dbSet
                .Where(w => w.TruckId == truckId)
                .Include(w => w.Employee)
                .OrderByDescending(w => w.IssueDate)
                .ToListAsync();
        }
=======
    internal class WakalaRepository
    {
>>>>>>> f665a7ad4fe8f29d70fc7dd3bcbd1b099de57b42
    }
}
