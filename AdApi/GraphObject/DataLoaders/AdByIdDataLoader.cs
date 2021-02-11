using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Ad;
using AdApplication.Models.Categories;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace AdApi.GraphObject.Queries.DataLoaders
{
    public class AdByIdDataLoader : BatchDataLoader<int, Ad> 
    {
        private readonly IDbContextFactory<AdDbContext> _dbContextFactory;

        public AdByIdDataLoader(
            IBatchScheduler batchScheduler, 
            IDbContextFactory<AdDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? 
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Ad>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using AdDbContext dbContext = _dbContextFactory.CreateDbContext();
            
            return await dbContext.Ads
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}