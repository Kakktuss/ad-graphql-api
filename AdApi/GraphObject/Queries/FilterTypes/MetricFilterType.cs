using AdApplication.Models.Ad;
using AdApplication.Models.Categories;
using AdApplication.Models.Metric;
using HotChocolate.Data.Filters;

namespace AdApi.GraphObject.Queries.FilterTypes
{
    public class MetricFilterType : FilterInputType<Metric>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Metric> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.Ads).Ignore();
        }
    }
}