using Outsourcing.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labixa.Areas.Admin.ViewModel;
using Outsourcing.Data.Models;
using AutoMapper;
using Outsourcing.Core.Extensions;
using System.IO;

namespace Labixa.Areas.Admin.Controllers
{
    public class RecipeController : Controller
    {
          #region [Field]
        public readonly ICollectionService _collectionService;
        public readonly IAccountService _accountService;
        public readonly IRecipeService _recipeService;
       
        #endregion
        #region [ctor]
        public RecipeController( IRecipeService _recipeService, IAccountService _accountService, ICollectionService _collectionService)
        {
           this._collectionService = _collectionService;
           this._accountService = _accountService;
           this._recipeService = _recipeService;
          
        }
        #endregion


        //
        // GET: /Admin/Recipe/
     


        public ActionResult ViewDetail(int id)
        {
            Recipe rep = _recipeService.GetRecipeById(id);
            RecipeViewModel item = Mapper.Map<Recipe, RecipeViewModel>(rep);
           
            return View(item);
        }

        public ActionResult Create()
        {
            
            
            RecipeViewModel obj = new RecipeViewModel();
            if (Session["idUser"] == null)
            {
                return Redirect("/Dashboard/Index");
              
            } 
              
            int idUser = int.Parse(Session["idUser"].ToString());
           
            var listCollection = _collectionService.GetAllCollections().Where(p => p.AccountId == idUser);
            obj.ListCollections = listCollection;
            Session["error"] = null;
           
            return View(obj);
        }
        [HttpPost]
        public ActionResult Create(RecipeViewModel obj)
        {
            

            int idUser = int.Parse(Session["idUser"].ToString());
            var listCollection = _collectionService.GetAllCollections().Where(p => p.AccountId == idUser);//.ToSelectListItems(-1);
            obj.ListCollections = listCollection;
            
            if (obj.Name == null)
            {
                Session["error"] = "*You must input recipe name";
                return View(obj);
            }
            else if(obj.idCollection <= 0 || obj.idCollection == null){
                Session["error"] = "*You must select a collection.";
                return View(obj);
                }
            else
            {
                var r = _recipeService.GetAllRecipes().Where(p=>p.CollectionId == obj.idCollection && p.Name.ToLower().Equals(obj.Name.ToLower())).FirstOrDefault();
                if (r != null)
                {
                    Session["error"] = "*This recipe name already exists";
                    return View(obj);
                }
            }


                Recipe rep = Mapper.Map<RecipeViewModel, Recipe>(obj);
                rep.CollectionId = obj.idCollection;
                rep.DateCreated = rep.LastEdit = DateTime.Now;
                _recipeService.AddRecipe(rep);
                rep = _recipeService.GetAllRecipes().LastOrDefault();
                var id = rep.Id;

                //=============Upload===================
                if (obj.image != null)
                {
                    HttpPostedFileBase file = obj.image; // Get uploaded file
                    string fileName = Path.GetFileName(file.FileName); // Get file name
                    string dir = "~/Images/Upload/Recipe" + id.ToString();
                    String phyDir = Server.MapPath(dir);
                    if (!Directory.Exists(phyDir))
                        Directory.CreateDirectory(phyDir);
                    var path = Path.Combine(Server.MapPath(dir), fileName);
                    file.SaveAs(path);

                    rep.URL = "/Images/Upload/Recipe" + id.ToString() + "/" + fileName;
                }
                else rep.URL = "/Content/Cookbook/images/no-image.jpg";

                _recipeService.EditRecipe(rep);

                Session["error"] = null;

                return Redirect("ViewDetail?id=" + id);

        }

        public ActionResult Search(string srch_term )
        {
            if (Session["idUser"] == null)
            {
                return Redirect("/Dashboard/Index");
               
            } 


            var id = int.Parse(Session["idUser"].ToString());
            List<Recipe> recipes = new List<Recipe>();
            var listCollection = _collectionService.GetAllCollections().Where(p=>p.AccountId == id);
            foreach (var obj in listCollection)
            {
                var list1 = _recipeService.GetAllRecipes().Where(p=>p.CollectionId == obj.Id).Distinct();
                recipes.AddRange(list1);
            
            }
            var list = recipes.Where(p => p.Name.ToString().ToLower().Contains(srch_term.ToLower()));
            
            return View(list); //return "Search" view to the user
        }


        #region[Draft]

        //[HttpPost]
        //public ActionResult Create(RecipeViewModel obj)
        //{
        //    Recipe item = Mapper.Map<RecipeViewModel, Recipe>(obj);

        //    item.idCollection = obj.idCollection;
        //    item.isPublic = false;
        //    _recipeService.AddRecipe(item);

        //    var id = _recipeService.GetAllRecipes().LastOrDefault().Id;
        //    List<Ingredient> listIngr = (List<Ingredient>)Session["listIngr"];
        //    if(listIngr != null)
        //    {
        //        foreach (var it in listIngr) {
        //            it.idRecipe = id;
        //            _ingredientService.AddIngredient(it);
        //        }
        //    }
        //    Session["listIngr"] = null;
        //    return Redirect("Recipe/ViewDetail?id="+id);
        //}
      
  //[HttpPost]
  //      public ActionResult CreateAjaxIngredient(string IngrName, string Quantity)
  //      {
  //          if (Session["listIngr"] == null)
  //          {
  //              List<Ingredient> list = new List<Ingredient>();
  //              Session["listIngr"] = list;
  //          }
  //          List<Ingredient> listIngr = (List<Ingredient>)Session["listIngr"];
            
  //          Ingredient item = new Ingredient();
  //          item.Quantity = Quantity;
  //          item.Name = IngrName;
  //          listIngr.Add(item);
  //          return PartialView("_PartialIngrs", Session["listIngr"]);

        //      }

        //public ActionResult ViewMyRecipe(int userId)
        //{
        //    var list = _recipeService.GetAllRecipes().Where(p => p.Collection.Account.Id == userId);
        //    return View("Index", list);
        //}

        #endregion 

        public ActionResult Edit(int id)
        {
            Recipe rep = _recipeService.GetRecipeById(id);
            RecipeViewModel obj = Mapper.Map<Recipe, RecipeViewModel>(rep);
            var user = int.Parse(Session["idUser"].ToString());
            Session["error"] = null;

            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(RecipeViewModel obj)
        {
            Recipe rep = _recipeService.GetRecipeById(obj.Id);
           

            int idUser = int.Parse(Session["idUser"].ToString());

            if (obj.Name == null)
            {
                Session["error"] = "*You must input recipe name";
                return View(obj);
            }
            else if(!rep.Name.Equals(obj.Name))
            {
                var r = _recipeService.GetAllRecipes().Where(p => p.CollectionId == obj.idCollection && p.Name.ToLower().Equals(obj.Name.ToLower())).FirstOrDefault();
                if (r != null)
                {
                    Session["error"] = "*This recipe name already exists";
                    return View(obj);
                }
            }

            if(obj.image != null)
            {
                HttpPostedFileBase file = obj.image; // Get uploaded file
                string fileName = Path.GetFileName(file.FileName); // Get file name
                string dir = "~/Images/Upload/Recipe" + obj.Id.ToString();
                String phyDir = Server.MapPath(dir);
                if (!Directory.Exists(phyDir))
                    Directory.CreateDirectory(phyDir);
                var path = Path.Combine(Server.MapPath(dir), fileName);
                file.SaveAs(path);
                rep.URL = "/Images/Upload/Recipe" + obj.Id.ToString() + "/" + fileName;
            }

            rep.Name = obj.Name;
            rep.Ingredient = obj.Ingredient;
            rep.Instruction = obj.Instruction;


            _recipeService.EditRecipe(rep);
            Session["error"] = null;
            return Redirect("ViewDetail?id=" + rep.Id);
            
        }


        public ActionResult Delete(int id)
        {
            Recipe rep = _recipeService.GetRecipeById(id);
            _recipeService.DeleteRecipe(rep);
            int idCollection = rep.CollectionId;
            return Redirect("/Dashboard/Homepage");
        }

        #region[Draft]
        //public ActionResult Index()
        //{
        //    var list = _recipeService.GetAllRecipes();
        //    return View(list);
        //}
        #endregion


	}
}