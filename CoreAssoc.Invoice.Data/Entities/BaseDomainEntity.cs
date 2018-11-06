using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAssoc.Invoice.Data.Entities
{
    public abstract class BaseDomainEntity : BaseIdEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
