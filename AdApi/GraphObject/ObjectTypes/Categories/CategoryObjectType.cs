using AdApi.GraphObject.Queries.DataLoaders;
using AdApi.GraphObject.Queries.FilterTypes;
using AdApi.GraphObject.Queries.Types.Ads;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Categories;
using HotChocolate.Types;

namespace AdApi.GraphObject.Queries.Types.Metrics
{
    public class CategoryObjectType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(e => e.Uuid)
                .Type<UuidType>();
            
            descriptor.Field(e => e.Name)
                .Type<StringType>();
            
            descriptor.Field(f => f.Ads)
                .Type<ListType<AdObjectType>>()
                .ResolveWith<CategoryResolver>(t => t.GetAdsAsync(default!, default!, default!, default!))
                .UseDbContext<AdDbContext>();
        }
    }
}