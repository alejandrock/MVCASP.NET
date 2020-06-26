//using System;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web; 
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;

namespace MVCCrud.Controllers{
    public class UserTableController : Controller{ 
        // GET: UserTable
        public ActionResult Index(){


            List<ListUserTablaViewModel> lst;  

            using (CrudEntitie db = new CrudEntitie()) {

                lst = (from d in db.userTables
                           select new ListUserTablaViewModel{
                               Id = d.id, 
                               userName = d.userName,
                               email = d.email
                           }).ToList();
                
            }
                return View(lst);
        }

        public ActionResult Nuevo() {
             
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(UserTablaViewModel model)
        {
            try {
                if (ModelState.IsValid) {

                    using (CrudEntitie db = new CrudEntitie()) {

                        var oTabla = new userTable();
                        oTabla.userName = model.userName;
                        oTabla.email = model.email;
                        oTabla.birthDate = model.birthDate;
                        db.userTables.Add(oTabla);
                        db.SaveChanges();  

                    }
                    return Redirect("~/UserTable");  
                }
                return View(model); 
            } 
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }

        public ActionResult Editar( int Id){

            UserTablaViewModel model = new UserTablaViewModel(); 
                using (CrudEntitie db = new  CrudEntitie()) {

                var oTabla = db.userTables.Find(Id);
                model.userName = oTabla.userName;
                model.email = oTabla.email;
                model.birthDate = (DateTime)oTabla.birthDate;
                model.Id = oTabla.id;
            } 
                return View(model);
        }

        [HttpPost] 
        public ActionResult Editar(UserTablaViewModel model) 
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (CrudEntitie db = new CrudEntitie())
                    {

                        var oTabla = db.userTables.Find(model.Id);
                        oTabla.userName = model.userName;
                        oTabla.email = model.email;
                        oTabla.birthDate = model.birthDate;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                    }
                    return Redirect("~/UserTable");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        [HttpGet] 
        public ActionResult Eliminar(int Id)
        {

            UserTablaViewModel model = new UserTablaViewModel();
            using (CrudEntitie db = new CrudEntitie())
            {
                var oTabla = db.userTables.Find(Id);
                db.userTables.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("~/UserTable/");
        }


    }
}