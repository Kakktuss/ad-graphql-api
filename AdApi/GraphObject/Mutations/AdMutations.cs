using System.Linq;
using System.Threading.Tasks;
using AdApi.GraphObject.Mutations.Payloads;
using AdApplication.EntityFrameworkDataAccess;
using AdApplication.Models.Ad;
using HotChocolate;

namespace AdApi.GraphObject.Mutations
{
    public class AdMutations
    {
        public async Task<Ad> Ad(AddAdPayload input, [Service] AdDbContext context)
        {
            context.Ads.Add(input.Ad);

            var result = await context.SaveEntitiesAsync();

            if (!result)
            {
                return null;
            }

            return input.Ad;
        }
    }
}