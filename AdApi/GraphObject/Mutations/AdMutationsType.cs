using AdApi.GraphObject.Queries.Types.Ads;
using HotChocolate.Types;

namespace AdApi.GraphObject.Mutations
{
    public class AdMutationsType : ObjectType<AdMutations>
    {
        protected override void Configure(IObjectTypeDescriptor<AdMutations> descriptor)
        {
            descriptor.Field(e => e.Ad(default, default))
                .Type<AdObjectType>();
        }
    }
}