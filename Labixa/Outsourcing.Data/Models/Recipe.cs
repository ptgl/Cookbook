using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
            DateCreated = LastEdit = DateTime.Now;
            isDelete  = false;
            URL = "/Content/Cookbook/images/no-image.jpg";
            
        }

        public int CollectionId { get; set; }
        public string Instruction { get; set; }
        public string Ingredient { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        
        public DateTime LastEdit { get; set; }
        public DateTime DateCreated { get; set; }
        public bool isDelete { get; set; }
        public string Note { get; set; }
       
       
        public virtual Collection Collection { get; set; }
        
      
    }
}
