using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Categories;
using AdApplication.Models.Metric;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace AdApi.GraphObject.Queries.DataLoaders
{
    public class MetricByIdDataLoader : BatchDataLoader<int, Metric> 
    {
        private readonly IDbContextFactory<AdDbContext> _dbContextFactory;

        public MetricByIdDataLoader(
            IBatchScheduler batchScheduler, 
            IDbContextFactory<AdDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? 
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Metric>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using AdDbContext dbContext = _dbContextFactory.CreateDbContext();
            
            return await dbContext.Metrics
                .Include(s => s.Ads)
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}