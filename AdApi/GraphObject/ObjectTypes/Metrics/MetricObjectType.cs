using System.Collections.Generic;
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
                .Type<UuidType>();
            
            descriptor.Field(e => e.Name)
                .Type<StringType>();
            
            descriptor.Field(f => f.Ads)
                .Type<ListType<AdObjectType>>()
                .ResolveWith<MetricResolver>(t => t.GetAdsAsync(default!, default!, default!, default!))
                .UseDbContext<AdDbContext>();
        }
    }
}