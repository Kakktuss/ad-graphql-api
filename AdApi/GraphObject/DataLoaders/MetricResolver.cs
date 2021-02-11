using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Ad;
using AdApplication.Models.Categories;
using AdApplication.Models.Metric;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace AdApi.GraphObject.Queries.DataLoaders
{
    public class MetricResolver
    {
        public async Task<IEnumerable<Ad>> GetAdsAsync(Metric metric,
            [Service] AdDbContext dbContext,
            AdByIdDataLoader adById,
            CancellationToken cancellationToken)
        {
            int[] adsId = await dbContext.Ads
                .Where(s => s.Id == metric.Id)
                .Include(s => s.Metrics)
                .SelectMany(s => s.Metrics.Select(t => t.MetricId))
                .ToArrayAsync(cancellationToken);

            return await adById.LoadAsync(adsId, cancellationToken);
        }
    }
}