using AdApplication.Models.Ad;
using HotChocolate.Data.Filters;

namespace AdApi.GraphObject.Queries.FilterTypes
{
    public class AdFilterType : FilterInputType<Ad>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Ad> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Categories)
                .Type<ListFilterInputType<CategoryFilterType>>()
                .Description("Ad categories");

            descriptor.Field(f => f.Metrics)
                .Type<ListFilterInputType<MetricFilterType>>()
                .Description("Ad metrics");
        }
    }
}