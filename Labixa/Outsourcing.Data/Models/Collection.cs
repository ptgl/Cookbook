using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outsourcing.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class Collection : BaseEntity
    {

        public Collection(){
            DateCreated = LastEdit = DateTime.Now;
            isDelete  = false;
        }

        public int AccountId { get; set; }
        [DisplayName(@"Collection Name:")]
        [Required(ErrorMessage="Please enter your collection's name")]
        public string Name { get; set; }

        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastEdit { get; set; }
        public bool isDelete { get; set; }
       
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual Account Account { get; set; }
    }
}
