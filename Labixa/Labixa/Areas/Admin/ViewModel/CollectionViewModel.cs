using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labixa.Areas.Admin.ViewModel
{
    public class CollectionViewModel
    {
        public CollectionViewModel()
        {
            //ListCollections = new List<Collection>();
            ListRecipes = new List<Recipe>();
            active = "";
        }

        public int ID { get; set; }
        public string nameCollection { get; set; }
        public string active { get; set; }
        //public IEnumerable<Collection> ListCollections { get; set; }
        public IEnumerable<Recipe> ListRecipes { get; set; }


    }
}