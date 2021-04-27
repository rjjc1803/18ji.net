using LoveExam.BLL;
using LoveExam.Model;
using LoveExam.Model.Entity;
using LoveExam.MVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoveExam.MVC.Controllers
{
    public class SecurityController : BaseController
    {
        // GET: Security
        public ActionResult SecuritySet()
        {
            try
            {
                ViewBag.CurUserPwd = ContextObject.CurrentUser.PassWord;
                ViewBag.CurUserPro = ContextObject.CurrentUser.Profession;
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                ViewBag.CurUserSch = ContextObject.CurrentUser.SchName;
                ViewBag.CurUserName = ContextObject.CurrentUser.Name;
                ViewBag.CurUserSex = ContextObject.CurrentUser.Gender;
                ViewBag.CurUserEmail = ContextObject.CurrentUser.EMail;
                ViewBag.CurUserStuID = ContextObject.CurrentUser.WorkID;
                ViewBag.CurUserPwd = ContextObject.CurrentUser.PassWord;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public ActionResult UpdatePwdById(int uid,int pwd,int rpwd)
        {
            bool success = UserMgr.UpdatePwdById(uid,pwd,rpwd);
            StateModel state = new StateModel(success);
            if (!state.Status)
            {
                state.Message = "修改失败，旧密码不正确或与新密码相同！";
            }
            return Json(state);
        }
    }
}