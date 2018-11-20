using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MICRO.WMS.WEB.Models;
using MICRO.WMS.WEB.Services.UserInforService;
using Repository.Pattern.UnitOfWork;

namespace MICRO.WMS.WEB.Controllers
{
    public class USERINORController : Controller
    {
        //private WebDbContext db = new WebDbContext();
        private IUnitOfWork _unitOfWork;
        private IUserInforService _userInforService;
        public USERINORController(IUnitOfWork unitOfWork) {//,IUserInforService userInforService
            //_userInforService = userInforService;
            _unitOfWork = unitOfWork;
        }

        // GET: USERINOR
        public ActionResult Index()
        {
            var unofworkQuery = _unitOfWork.Repository<USERINOR>().Query(x => x.ID < 100).Select().ToList();
            //var serviceQuery = _userInforService.Query(x => x.ID < 100).Select().ToList();
            return View(unofworkQuery);
        }

        // GET: USERINOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINOR uSERINOR = _unitOfWork.Repository<USERINOR>().Find(id);
            if (uSERINOR == null)
            {
                return HttpNotFound();
            }
            return View(uSERINOR);
        }

        // GET: USERINOR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USERINOR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USERNAME,USERCODE,USERROLE,REMARK,ADDWHO,ADDID,ADDTS,EDITWHO,EDITID,EDITTS")] USERINOR uSERINOR)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<USERINOR>().Insert(uSERINOR);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSERINOR);
        }

        // GET: USERINOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINOR uSERINOR = _unitOfWork.Repository<USERINOR>().Find(id);
            if (uSERINOR == null)
            {
                return HttpNotFound();
            }
            return View(uSERINOR);
        }

        // POST: USERINOR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USERNAME,USERCODE,USERROLE,REMARK,ADDWHO,ADDID,ADDTS,EDITWHO,EDITID,EDITTS")] USERINOR uSERINOR)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<USERINOR>().Update(uSERINOR);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSERINOR);
        }

        // GET: USERINOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINOR uSERINOR = _unitOfWork.Repository<USERINOR>().Find(id);
            if (uSERINOR == null)
            {
                return HttpNotFound();
            }
            return View(uSERINOR);
        }

        // POST: USERINOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERINOR uSERINOR = _unitOfWork.Repository<USERINOR>().Find(id);
            _unitOfWork.Repository<USERINOR>().Delete(uSERINOR);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
