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
using MICRO.WMS.WEB.Services;
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

        //获取查询页面数据
        public string GetData() {
            PageResponseModel model = new PageResponseModel();
            var data = _unitOfWork.Repository<USERINFOR>().Query().Select().ToList();
            model.count = data.Count();
            model.data = data;
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertData(USERINFOR user) {
            _unitOfWork.Repository<USERINFOR>().Insert(user);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex) {
                return Json(new { Success = false, ErrMsg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = true, ErrMsg = "" }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="user">待删除的实体</param>
        /// <returns></returns>
        public ActionResult DeleteData(USERINFOR user) {
            _unitOfWork.Repository<USERINFOR>().Delete(user);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ErrMsg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = true, ErrMsg = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public ActionResult DeleteData(int id)
        {
            _unitOfWork.Repository<USERINFOR>().Delete(id);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ErrMsg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = true, ErrMsg = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="uesr"></param>
        /// <returns></returns>
        public ActionResult UpsateData(USERINFOR uesr) {
            _unitOfWork.Repository<USERINFOR>().Update(uesr);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ErrMsg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = true, ErrMsg = "" }, JsonRequestBehavior.AllowGet);
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
