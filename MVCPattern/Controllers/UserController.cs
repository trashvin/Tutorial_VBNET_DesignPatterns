using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProviderService;
using MVCPattern.Models;

namespace MVCPattern.Controllers
{
    public class UserController : Controller
    {

        static UserDBProvider db = new UserDBProvider();
        //
        // GET: /User/


        public ActionResult Index()
        {
            List<Models.UserModel> users = new List<Models.UserModel>();

            foreach(MyUser rawUser in db.GetUsers())
            {
                users.Add(new Models.UserModel(rawUser));
            }

            return View(users);
        }

        public ActionResult Edit(int id)
        {

            Models.UserModel user = new Models.UserModel(db.FindUserByID(id));

            if (user == null) return HttpNotFound();

            return View(user);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditUser(UserModel model)
        {
            
            if ( db.EditUser(model.ToMyUser()) )
            {
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }

        
        }

        public ActionResult Delete(int id)
        {
            Models.UserModel user = new Models.UserModel(db.FindUserByID(id));

            if (user == null) return HttpNotFound();
            
            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteUser(int id)
        {
            db.DeleteUser(id);

            return RedirectToAction("index");
        }
            
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(UserModel model)
        {
            if ( db.AddUser(model.ToMyUser()))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
