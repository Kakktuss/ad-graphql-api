using AdApplication.Models.Ad;
using HotChocolate.Data.Filters;

namespace AdApi.GraphObject.Queries.FilterTypes
{
    public class AdFilterType : FilterInputType<Ad>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Ad> descriptor)
        {
            descriptor.BindFieldsExplicitly();
        }
    }
}