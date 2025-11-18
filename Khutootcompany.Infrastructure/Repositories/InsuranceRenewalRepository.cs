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
    public class InsuranceRenewalRepository : GenericRepository<InsuranceRenewal>, IInsuranceRenewalRepository
    {
        public InsuranceRenewalRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<InsuranceRenewal>> GetRenewalsByTruckAsync(int truckId)
        {
            return await _dbSet
                .Where(i => i.TruckId == truckId)
                .OrderByDescending(i => i.RenewalDate)
                .ToListAsync();
        }

        public async Task<InsuranceRenewal?> GetLatestRenewalForTruckAsync(int truckId)
        {
            return await _dbSet
                .Where(i => i.TruckId == truckId)
                .OrderByDescending(i => i.RenewalDate)
                .FirstOrDefaultAsync();
        }
=======
    internal class InsuranceRenewalRepository
    {
>>>>>>> f665a7ad4fe8f29d70fc7dd3bcbd1b099de57b42
    }
}
