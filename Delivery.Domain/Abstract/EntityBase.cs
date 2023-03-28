using System.Text.Json.Serialization;

namespace Delivery.Domain.Abstract
{
    public abstract class EntityBase
    {
        public ulong Id { get; set; }
    }
}
