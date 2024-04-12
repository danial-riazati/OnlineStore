using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public sealed class User : BaseEntity
    {

        public string Name { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}

