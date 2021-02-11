using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Ad;
using AdApplication.Models.Categories;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace AdApi.GraphObject.Queries.DataLoaders
{
    public class CategoryResolver
    {
        public async Task<IEnumerable<Ad>> GetAdsAsync(Category category,
            [Service] AdDbContext dbContext,
            AdByIdDataLoader adById,
            CancellationToken cancellationToken)
        {
            int[] adsId = await dbContext.Ads
                .Where(s => s.Id == category.Id)
                .Include(s => s.Categories)
                .SelectMany(s => s.Categories.Select(t => t.CategoryId))
                .ToArrayAsync(cancellationToken);

            return await adById.LoadAsync(adsId, cancellationToken);
        }
    }
}