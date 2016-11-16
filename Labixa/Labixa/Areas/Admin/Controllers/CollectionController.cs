using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Outsourcing.Data.Models;
using Outsourcing.Service;


namespace Labixa.Areas.Admin.Controllers
{
    public class CollectionController : Controller
    {

         #region [Field]
        public readonly ICollectionService _collectionService;
        public readonly IAccountService _accountService;
        #endregion
        #region [ctor]
        public CollectionController(IAccountService _accountService, ICollectionService _collectionService)
        {
           this._collectionService = _collectionService;
           this._accountService = _accountService;
        }
        #endregion
      

        //
        // GET: /Admin/Cookbook/
    
        public ActionResult Create()
        {
            Collection obj = new Collection();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(string collection, string id)
        {
            if(ModelState.IsValid)
            {
           
                int idUser = int.Parse(Session["idUser"].ToString());

                var item = _collectionService.GetAllCollections().Where(p => p.Name.ToLower().Equals(collection.ToLower()) && p.AccountId == idUser).FirstOrDefault();
                if (item != null)
                {
                    return Json(new { result = "*This collection name already exists" });
                }
                else
                {

                    Collection obj = new Collection();
                    obj.AccountId = idUser;
                    obj.Name = collection;
                    _collectionService.AddCollection(obj);
                    return Json(new { result = "ok" });
                }
           
            }
            else return Json(new { result = "failed" });
        }

        public ActionResult Edit(int id)
        {
            Collection obj = _collectionService.GetCollectionById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(string collection, string id)
        {
            #region[edit]
            if (ModelState.IsValid)
            {
                int idUser = int.Parse(Session["idUser"].ToString());
                var obj = _collectionService.GetAllCollections().Where(p => p.Name.ToLower().Equals(collection.ToLower()) && p.AccountId == idUser).FirstOrDefault();
                if (obj != null)
                {
                    
                    return Json(new { result = "*This collection name already exists" });
                }
                else
                {

                    var item = _collectionService.GetCollectionById(int.Parse(id));
                    item.Name = collection;
                    _collectionService.EditCollection(item);
                    //return "ok";
                    return Json(new { result = "ok" });
                }
            }
            else return Json(new { result = "failed edit" });
            #endregion
        }

        public ActionResult Delete(int id)
        {
            var obj = _collectionService.GetCollectionById(id);
            _collectionService.DeleteCollection(obj);
            return Redirect("/Dashboard/Homepage");
        }

        #region[Draft]
        //public ActionResult Index()
        //{
        //    var list = _collectionService.GetAllCollections();
        //    return View(list);
        //}
        #endregion

	}
}