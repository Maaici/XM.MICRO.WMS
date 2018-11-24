using MICRO.WMS.WEB.Models;
using MICRO.WMS.WEB.Services;
using Newtonsoft.Json;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MICRO.WMS.WEB.Controllers
{
    public class MemuInforController : Controller
    {
        //private WebDbContext db = new WebDbContext();
        private IUnitOfWorkAsync _unitOfWork;
        public MemuInforController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: MemuInfor
        public ActionResult Index()
        {
            return View();
        }

        //获取查询页面数据
        public string GetData()
        {
            PageResponseModel model = new PageResponseModel();
            var data = _unitOfWork.Repository<MemuInfor>().Query().Select().ToList();
            model.count = data.Count();
            model.data = data;
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertData(MemuInfor user)
        {
            _unitOfWork.Repository<MemuInfor>().Insert(user);
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
        /// <param name="user">待删除的实体</param>
        /// <returns></returns>
        public ActionResult DeleteData(MemuInfor user)
        {
            _unitOfWork.Repository<MemuInfor>().Delete(user);
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
            _unitOfWork.Repository<MemuInfor>().Delete(id);
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
        public ActionResult UpsateData(MemuInfor uesr)
        {
            _unitOfWork.Repository<MemuInfor>().Update(uesr);
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

    }
}