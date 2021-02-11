﻿using AdApi.GraphObject.Queries.Types.Ads;
using AdApi.GraphObject.Queries.Types.Metrics;
using HotChocolate.Types;

namespace AdApi.GraphObject.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
/**
 *             descriptor.Field(e => e.GetAds(default))
                .Type<ListType<AdObjectType>>()
                .UseProjection()
                .UseFiltering();

            descriptor.Field(e => e.GetAd(default, default))
                .Type<AdObjectType>()
                .UseProjection()
                .UseFiltering();
 */
            
            descriptor.Field(e => e.GetCategories(default))
                .Type<ListType<CategoryObjectType>>()
                .UseFiltering();
        }
    }
}