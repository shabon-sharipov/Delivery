using System.Text.Json.Serialization;

namespace Delivery.Domain.Model
{
    public abstract class EntityBase
    {
        [JsonIgnore]
        public ulong Id { get; set; }
    }
}
