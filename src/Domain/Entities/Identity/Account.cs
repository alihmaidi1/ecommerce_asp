using ecommerce_shared.Enums;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Domain.Entities.Identity
{
    public class Account : IdentityUser<Guid>
    {

        public Account()
        {

            RefreshTokens = new HashSet<RefreshToken>();
        }

        [EncryptColumn]
        public string ? Code { get; set; }



        public string? ProviderId { get; set; }

        public ProviderAuthentication ProviderType { get; set; }

        public bool IsBlocked{ get; set; }

        [EncryptColumn]
        public string? ConfirmCode { get; set; }


        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }

    }
}
