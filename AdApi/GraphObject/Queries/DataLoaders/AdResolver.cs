﻿using System.Collections.Generic;
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
    public class AdResolver
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync(
            Ad ad,
            [ScopedService] AdDbContext dbContext,
            CategoryByIdDataLoader categoryById,
            CancellationToken cancellationToken)
        {
            int[] categoriesId = await dbContext.Categories
                .Where(s => s.Id == ad.Id)
                .Include(s => s.Ads)
                .SelectMany(s => s.Ads.Select(t => t.CategoryId))
                .ToArrayAsync(cancellationToken);


            return await categoryById.LoadAsync(categoriesId, cancellationToken);
        }
        
        public async Task<IEnumerable<Metric>> GetMetricsAsync(
            Ad ad,
            [ScopedService] AdDbContext dbContext,
            MetricByIdDataLoader metricById,
            CancellationToken cancellationToken)
        {
            int[] categoriesId = await dbContext.Metrics
                .Where(s => s.Id == ad.Id)
                .Include(s => s.Ads)
                .SelectMany(s => s.Ads.Select(t => t.MetricId))
                .ToArrayAsync(cancellationToken);
            
            return await metricById.LoadAsync(categoriesId, cancellationToken);
        }
    }
}