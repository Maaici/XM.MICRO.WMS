using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;
using MICRO.WMS.WEB.Models;
using MICRO.WMS.WEB.Services.UserInforService;
using Repository.Pattern.UnitOfWork;

namespace MICRO.WMS.WEB.Controllers
{
    public class USERINFORController : Controller
    {
        //private WebDbContext db = new WebDbContext();
        private IUnitOfWorkAsync _unitOfWork;
        private IUserInforService _userInforService;
        public USERINFORController(IUnitOfWorkAsync unitOfWork, IUserInforService userInforService) {
            _userInforService = userInforService;
            _unitOfWork = unitOfWork;
        }

        // GET: USERINFOR
        public ActionResult Index()
        {
            return View();
        }

        public string GetData() {
            PageResponseModel model = new PageResponseModel();
            var data = _unitOfWork.Repository<USERINFOR>().Query().Select().ToList();
            model.count = data.Count();
            model.data = data;
            return JsonConvert.SerializeObject(model);
        }

        // GET: USERINFOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINFOR USERINFOR = _unitOfWork.Repository<USERINFOR>().Find(id);
            if (USERINFOR == null)
            {
                return HttpNotFound();
            }
            return View(USERINFOR);
        }

        // GET: USERINFOR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USERINFOR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USERNAME,USERCODE,USERROLE,REMARK,ADDWHO,ADDID,ADDTS,EDITWHO,EDITID,EDITTS")] USERINFOR USERINFOR)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<USERINFOR>().Insert(USERINFOR);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(USERINFOR);
        }

        // GET: USERINFOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINFOR USERINFOR = _unitOfWork.Repository<USERINFOR>().Find(id);
            if (USERINFOR == null)
            {
                return HttpNotFound();
            }
            return View(USERINFOR);
        }

        // POST: USERINFOR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USERNAME,USERCODE,USERROLE,REMARK,ADDWHO,ADDID,ADDTS,EDITWHO,EDITID,EDITTS")] USERINFOR USERINFOR)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<USERINFOR>().Update(USERINFOR);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(USERINFOR);
        }

        // GET: USERINFOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINFOR USERINFOR = _unitOfWork.Repository<USERINFOR>().Find(id);
            if (USERINFOR == null)
            {
                return HttpNotFound();
            }
            return View(USERINFOR);
        }

        // POST: USERINFOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERINFOR USERINFOR = _unitOfWork.Repository<USERINFOR>().Find(id);
            _unitOfWork.Repository<USERINFOR>().Delete(USERINFOR);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
