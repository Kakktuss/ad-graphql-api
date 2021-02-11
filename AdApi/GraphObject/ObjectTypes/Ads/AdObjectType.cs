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
            descriptor.Field(f => f.Uuid)
                .Type<UuidType>();
            
            descriptor.Field(f => f.Title)
                .Type<StringType>();
            
            descriptor.Field(f => f.Description)
                .Type<StringType>();

            descriptor.Field(f => f.Categories)
                .Type<ListType<CategoryObjectType>>()
                .ResolveWith<AdResolver>(t => t.GetCategoriesAsync(default!, default!, default!, default!))
                .UseDbContext<AdDbContext>();

            descriptor.Field(f => f.Metrics)
                .Type<ListType<MetricObjectType>>()
                .ResolveWith<AdResolver>(t => t.GetMetricsAsync(default!, default!, default!, default!))
                .UseDbContext<AdDbContext>();
        }
    }
}