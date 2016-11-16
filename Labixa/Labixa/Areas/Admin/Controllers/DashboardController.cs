using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Outsourcing.Data;
using Outsourcing.Service;
using Labixa.Areas.Admin.ViewModel;
using Outsourcing.Core.Extensions;
using System.Globalization;
using Labixa.Models;
using System.Net;
using System.Security.Principal;
using Outsourcing.Data.Models;
namespace Labixa.Areas.Admin.Controllers
{
    //[Authorize]
    public class DashboardController : BaseController
    {
        #region [Field]
        public readonly IAccountService _accountService;
        public readonly ICollectionService _collectionService;
        public readonly IRecipeService _recipeService;
        #endregion
        #region [ctor]
        public DashboardController( IAccountService _accountService, ICollectionService _collectionService,IRecipeService _recipeService)
        {
            this._accountService = _accountService;
            this._collectionService = _collectionService;
            this._recipeService = _recipeService;
        }
        #endregion
        // GET: /Dashboard/
        public ActionResult Index()
        {
            
                LoginFormModel obj = new LoginFormModel();
                return View(obj);
           
        }
        [HttpPost]
        public ActionResult Register(LoginFormModel item)
        {
            if (ModelState.IsValid)
            {
                string email = item.email;
                var obj = _accountService.GetAllAccounts().Where(p => p.Email.Equals(email)).FirstOrDefault();
                if (obj != null)
                {
                   
                    Session["user"] = null;
                    return Json(new { result = "Your email has been used by an existing user." });
                  
                }

                Account user = new Account();
                user.Email = email;
                user.Password = item.pass;
                user.Username = item.name;
                _accountService.AddAccount(user);
                Session["user"] = item.name;
                Session["idUser"] = _accountService.GetAllAccounts().LastOrDefault().Id;

                return Json(new { result = "ok" });
              
            }
            else return View("Index", item);
        }

        [HttpPost]
        public ActionResult Login(LoginFormModel item)
        {
            
                var obj = _accountService.GetAllAccounts().Where(p => p.Email.Equals(item.email) && p.Password.Equals(item.pass)).FirstOrDefault();
                if (obj != null)
                {
                    Session["user"] = obj.Username;
                    Session["idUser"] = obj.Id;
                    return Json(new { result = "ok" });
                   
                }
            
                Session["user"] = null;
                return Json(new { result = "The email or password you entered is incorrect. " });
        }

        public ActionResult Logout()
        {
            Session["user"] = Session["idUser"] = Session["error"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Homepage()
        {
            
            List<CollectionViewModel> list = new List<CollectionViewModel>();
            int idCollection = -1;
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Index");
            } 
            
            
            var id = int.Parse(Session["idUser"].ToString());
            var collections = _collectionService.GetAllCollections().Where(p => p.AccountId == id).Distinct();
            if (collections.FirstOrDefault() != null )
            {
                idCollection = collections.FirstOrDefault().Id;
            }
            foreach(var item in collections){
                CollectionViewModel obj = new CollectionViewModel();
                obj.ID = item.Id;
                if(obj.ID == idCollection)
                {
                    obj.active = "";
                }
                obj.nameCollection = item.Name;
               
                var recipes = _recipeService.GetAllRecipes().Where(p => p.CollectionId == item.Id).Distinct();
                obj.ListRecipes = recipes;
                list.Add(obj);
                
            }

            Session["error"] = null;

            return View(list);
        }




    }
}