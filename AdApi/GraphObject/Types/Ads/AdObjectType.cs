using AdApi.GraphObject.Queries.DataLoaders;
using AdApi.GraphObject.Queries.Types.Metrics;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Ad;
using HotChocolate.Types;

namespace AdApi.GraphObject.Queries.Types.Ads
{
    public class AdObjectType : ObjectType<Ad>
    {
        protected override void Configure(IObjectTypeDescriptor<Ad> descriptor)
        {
            // Ignore domain events
            descriptor.Field(f => f.Uuid)
                .Type<UuidType>()
                .UseFiltering();
            
            descriptor.Field(f => f.Title)
                .Type<StringType>()
                .UseFiltering();
            
            descriptor.Field(f => f.Description)
                .Type<StringType>()
                .UseFiltering();

            descriptor.Field(f => f.Categories)
                .ResolveWith<AdResolver>(t => t.GetCategoriesAsync(default!, default!, default!, default!))
                .Type<CategoryObjectType>()
                .UseDbContext<AdDbContext>();

            descriptor.Field(f => f.Metrics)
                .ResolveWith<AdResolver>(t => t.GetMetricsAsync(default!, default!, default!, default!))
                .Type<MetricObjectType>()
                .UseDbContext<AdDbContext>();
        }
    }
}