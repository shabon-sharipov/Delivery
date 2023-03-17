using System.Text.Json.Serialization;

namespace Delivery.Domain.Model
{
    public abstract class EntityBase
    {
        public ulong Id { get; set; }
    }
}
