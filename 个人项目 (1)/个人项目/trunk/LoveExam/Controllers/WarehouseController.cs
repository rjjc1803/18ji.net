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
    public class WarehouseController : Controller
    {
        // GET: Warehouse

        public ActionResult AddQuestion()
        {
            return View();
        }

        public JsonResult AddExam (string ids,int tid)
        {

            StateModel state = new StateModel();
            state.Status = WarehouseMgr.AddExam(ids,tid);
            return Json(state);
        }
        public JsonResult BatchDeleteTestById(string ids)
        {

            StateModel state = new StateModel();
            state.Status = WarehouseMgr.BatchDeleteTestById(ids);
            return Json(state);
        }
        public JsonResult DeleteExamById(int id)
        {

            StateModel state = new StateModel();
            state.Status = WarehouseMgr.DeleteExamById(id);
            return Json(state);
        }
        public JsonResult AddStuTest( int tid,int cid,string uid)
        {

            StateModel state = new StateModel();
            state.Status = WarehouseMgr.AddStuTest(tid,cid,uid);
            return Json(state);
        }
        public JsonResult GetTestById(int id)
        {
            Test test = WarehouseMgr.GetTestById(id);
            return Json(test);
        }
        public ActionResult UpdateStatById(int tid)
        {
            Test test = WarehouseMgr.UpdateStatById(tid);
            return Json(test);
        }
        public JsonResult GetExamById(UserParameter parameter, int tid)
        {
            Pager<Exam> list = WarehouseMgr.GetMoListByPage(parameter, tid);
            return Json(list);
        }
        public JsonResult DeleteQueIDById(int id)
        {

            StateModel state = new StateModel();
            state.Status = WarehouseMgr.DeleteQueIDById(id);
            return Json(state);
        }

    }
}