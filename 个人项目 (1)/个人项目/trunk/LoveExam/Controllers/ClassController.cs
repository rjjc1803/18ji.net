using LoveExam.BLL;
using LoveExam.Model;
using LoveExam.Model.Entity;
using LoveExam.Model.Parameter;
using LoveExam.MVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoveExam.MVC.Controllers
{
    public class ClassController : BaseController
    {
        // GET: Class
        public ActionResult ClassList()
        {
            try
            {
            ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
            ViewBag.CurUserSch = ContextObject.CurrentUser.SchName;
            return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }

        }
        public ActionResult AddClass()
        {
            try
            {
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                ViewBag.CurUserSch = ContextObject.CurrentUser.SchName;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public ActionResult MyClass()
        {
            try
            {
          
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                ViewBag.CurUserSch = ContextObject.CurrentUser.SchName;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public ActionResult JoinClass()
        {
            try
            {
     
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                ViewBag.CurUserSch = ContextObject.CurrentUser.SchName;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public JsonResult GetListByPage(UserParameter parameter,int classid)
        {

            Pager<User> list = UserMgr.GetListByPage(parameter, classid);
            return Json(list);
        }
        public JsonResult GetClassById(int ID)
        {
            Class result = ClassMgr.GetClassById(ID);
            return Json(result);
        }
        public JsonResult GetClassList(int TeaID)
        {
            List<Class> list = ClassMgr.GetClassList(TeaID);
            return Json(list);
        }
        public JsonResult AddClassByName(Class obj)
        {

            bool isAdd = ClassMgr.AddClassByName(obj);
            StateModel state = new StateModel(isAdd);
            if (!state.Status)
            {
                state.Message = "创建班级失败，请联系管理员！";
            }
            return Json(state);
          }
        public JsonResult DeleteClassById(int id)
        {
            bool success = ClassMgr.DeleteClassById(id);
            StateModel state = new StateModel(success);
            return Json(state, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpadteClass(int id)
        {
            bool success = UserMgr.UpadteClass(id);
            StateModel state = new StateModel(success);
            if (!state.Status)
            {
                state.Message = "申请加入班级失败，请联系管理员！";
            }
            return Json(state);
        }

    }
}