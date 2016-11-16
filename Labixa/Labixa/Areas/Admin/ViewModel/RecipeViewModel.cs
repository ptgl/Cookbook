using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Outsourcing.Data.Models;
using System.Web.Mvc;
namespace Labixa.Areas.Admin.ViewModel
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
           //ListCollections = new List<SelectListItem>();
            ListCollections = new List<Collection>();
           
        }
        public int Id { get; set; }
        public int idCollection { get; set; }
        [AllowHtml]
        public string Instruction { get; set; }
        [Required(ErrorMessage="Please enter your recipe's name")]
        public string Name { get; set; }

        public DateTime LastEdit { get; set; }
        public DateTime DateCreated { get; set; }
        public bool isPublic { get; set; }
        public bool isDelete { get; set; }
        public string Note { get; set; }
        public string URL { get; set; }
        public HttpPostedFileBase image { get; set; }

        [DisplayName("Ingredient")]
        [AllowHtml]
        public string Ingredient { get; set; }
        
        public virtual Collection Collection { get; set; }
        

        
         [DisplayName("List of Collections")]
       //public IEnumerable<SelectListItem> ListCollections { get; set; }
        public IEnumerable<Collection> ListCollections { get; set; }

    }
}