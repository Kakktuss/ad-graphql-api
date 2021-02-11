using AdApplication.Models.Ad;

namespace AdApi.GraphObject.Mutations.Payloads
{
    public record AddAdPayload
    {
        public AddAdPayload(Ad ad)
        {
            Ad = ad;
        }
        
        public Ad Ad { get; }
    }
}