using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outsourcing.Data.Models;

namespace Outsourcing.Data.Models
{
    public class Account : BaseEntity
    {
        public Account()
    {
        DateCreated = DateTime.Now;
        isDelete = false;
    }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Note { get; set; }
        public bool isDelete { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }

    }
}
