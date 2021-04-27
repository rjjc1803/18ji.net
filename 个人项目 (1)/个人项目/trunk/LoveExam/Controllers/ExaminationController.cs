using LoveExam.BLL;
using LoveExam.Model;
using LoveExam.Model.Entity;
using LoveExam.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoveExam.Controllers
{
    public class ExaminationController : Controller
    {
        // GET: Examination
        public ActionResult ScoreList()
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
        public ActionResult ExamList()
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
        public ActionResult DoExam()
        {
                return View();
        }
        public JsonResult GetTestIdList(int id)
        {
            List<StuTest> list = ExamMgr.GetTestIdList(id);
            return Json(list);
        }
        public JsonResult GetTestList(UserParameter parameter, string ids)
        {
            Pager<Test> list = ExamMgr.GetTestList(parameter, ids);
            return Json(list);
        }

        public JsonResult GetQueByTestId(int id)
        {

            List<Exam> result = ExamMgr.GetQueByTestId(id);
            return Json(result);
        }
    }
}