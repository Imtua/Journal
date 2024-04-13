using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Domain.Entities
{
    public class UserToken
    {
        public Guid Id { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }
    }
}
