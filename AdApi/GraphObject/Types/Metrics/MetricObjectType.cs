using AdApi.GraphObject.Queries.DataLoaders;
using AdApi.GraphObject.Queries.Types.Ads;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Metric;
using HotChocolate.Types;

namespace AdApi.GraphObject.Queries.Types.Metrics
{
    public class MetricObjectType : ObjectType<Metric>
    {
        protected override void Configure(IObjectTypeDescriptor<Metric> descriptor)
        {
            // Ignore ads and domain events
            descriptor.Field(e => e.Uuid)
                .Type<UuidType>()
                .UseFiltering();
            
            descriptor.Field(e => e.Name)
                .Type<StringType>()
                .UseFiltering();
            
            descriptor.Field(f => f.Ads)
                .ResolveWith<MetricResolver>(t => t.GetAdsAsync(default!, default!, default!, default!))
                .Type<AdObjectType>()
                .UseDbContext<AdDbContext>()
                .UseFiltering();
        }
    }
}