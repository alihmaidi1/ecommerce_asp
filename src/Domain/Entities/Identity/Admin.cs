using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Identity
{
    public class Admin : BaseEntity
    {

        public Guid Id { get; set; }
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; }

        public bool IsBlocked { get; set; }

    }


}