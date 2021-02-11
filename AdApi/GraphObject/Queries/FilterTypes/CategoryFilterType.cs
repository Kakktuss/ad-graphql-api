using AdApplication.Models.Ad;
using AdApplication.Models.Categories;
using HotChocolate.Data.Filters;

namespace AdApi.GraphObject.Queries.FilterTypes
{
    public class CategoryFilterType : FilterInputType<Category>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Category> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.Ads).Ignore();
        }
    }
}