using System.Text.Json.Serialization;

namespace Delivery.Domain.Model
{
    public class EntityBase
    {
        [JsonIgnore]
        public ulong Id { get; set; }
    }
}
