using System;
using System.Linq;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Ad;
using AdApplication.Models.Categories;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace AdApi.GraphObject.Queries
{
    public class Query
    {
        [UseDbContext(typeof(AdDbContext))]
        public IQueryable<Ad> GetAds([ScopedService] AdDbContext context)
        {
            return context.Ads
                .AsNoTracking();
        }
        
        [UseDbContext(typeof(AdDbContext))]
        [UseFirstOrDefault]
        public IQueryable<Ad> GetAd(Guid uuid, [ScopedService] AdDbContext context)
        {
            return context.Ads
                .AsNoTracking()
                .Where(e => e.Uuid == uuid);
        }
        
        [UseDbContext(typeof(AdDbContext))]
        public IQueryable<Category> GetCategories([ScopedService] AdDbContext context)
        {
            return context.Categories
                .AsNoTracking();
        }
    }
}