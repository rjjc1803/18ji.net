using LoveExam.BLL;
using LoveExam.MVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoveExam.MVC.Controllers
{
    public class InformationController : BaseController
    {
        // GET: Information
        public ActionResult MyInformation()
        {
            try
            {
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

        public ActionResult OtherInformation()
        {
            return View();
        }
    }
}