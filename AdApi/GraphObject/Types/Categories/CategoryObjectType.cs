using AdApi.GraphObject.Queries.DataLoaders;
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
            descriptor.BindFieldsExplicitly();
            
            descriptor.Field(e => e.Uuid)
                .Type<UuidType>()
                .UseFiltering();
            
            descriptor.Field(e => e.Name)
                .Type<StringType>()
                .UseFiltering();

            descriptor.Field(e => e.Ads).Ignore();
            /**
             * descriptor.Field(f => f.Ads)
                .ResolveWith<CategoryResolver>(t => t.GetAdsAsync(default!, default!, default!, default!))
                .Type<AdObjectType>()
                .UseDbContext<AdDbContext>()
                .UseFiltering();
             */
        }
    }
}