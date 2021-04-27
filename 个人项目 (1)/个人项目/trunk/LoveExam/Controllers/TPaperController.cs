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
    public class TPaperController : BaseController
    {
        // GET: TPaper
        public ActionResult AddTest()
        {
            try
            {
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public ActionResult TestList()
        {
            try
            {
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public ActionResult Talk()
        {
            return View();
        }
        public ActionResult AddTopic()
        {
            try
            {
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public ActionResult TopicList()
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
        public ActionResult AddQuestion()
        {
            try
            {
                ViewBag.CurUserID = ContextObject.CurrentUser.UserID;
                return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public JsonResult AddSelect(Choice obj,int id)
        {

            bool isAdd = TPaperMgr.AddSelect(obj,id);
            StateModel state = new StateModel(isAdd);
            if (!state.Status)
            {
                state.Message = "添加选择题失败，请联系管理员！";
            }
            return Json(state);
        }
        public JsonResult AddMoreSelect(MoreChoice obj)
        {

            bool isAdd = TPaperMgr.AddMoreSelect(obj);
            StateModel state = new StateModel(isAdd);
            if (!state.Status)
            {
                state.Message = "添加多选题失败，请联系管理员！";
            }
            return Json(state);
        }
        public JsonResult AddJudge(Judge obj)
        {

            bool isAdd = TPaperMgr.AddJudge(obj);
            StateModel state = new StateModel(isAdd);
            if (!state.Status)
            {
                state.Message = "添加选择题失败，请联系管理员！";
            }
            return Json(state);
        }
        public JsonResult AddNarrative(QueAnswer obj)
        {

            bool isAdd = TPaperMgr.AddNarrative(obj);
            StateModel state = new StateModel(isAdd);
            if (!state.Status)
            {
                state.Message = "添加选择题失败，请联系管理员！";
            }
            return Json(state);
        }
        public JsonResult GetSelectListByPage(UserParameter parameter, int topicid)
        {
            Pager<Choice> list = TPaperMgr.GetSelectListByPage(parameter,topicid);
            return Json(list);
        }
        public JsonResult GetMoListByPage(UserParameter parameter, int topicid)
        {
            Pager<MoreChoice> list = TPaperMgr.GetMoListByPage(parameter,topicid);
            return Json(list);
        }
        public JsonResult GetJudListByPage(UserParameter parameter, int topicid)
        {
            Pager<Judge> list = TPaperMgr.GetJudListByPage(parameter,topicid);
            return Json(list);
        }
        public JsonResult GetQueListByPage(UserParameter parameter, int topicid)
        {
            Pager<QueAnswer> list = TPaperMgr.GetQueListByPage(parameter,topicid);
            return Json(list);
        }
        public JsonResult GetTopicList(int id)
        {
            List<Topic> list = TopicMgr.GetTopicList(id);
            return Json(list);
        }
        public JsonResult GetQueByPage(UserParameter parameter,int topicid,int queid)
        {
            if (queid - topicid == 1000)
            {
                return GetSelectListByPage(parameter,topicid);
            }
            else if (queid-topicid==2000)
            {
                return GetMoListByPage(parameter,topicid);
            }
            else if (queid - topicid == 3000)
            {
                return GetJudListByPage(parameter,topicid);
            }
            else
            {
                return GetQueListByPage( parameter,topicid);  
            }
          
        }
        public JsonResult AddTopicByName(Topic obj)
        {

            bool isAdd = TopicMgr.AddTopicByName(obj);
            StateModel state = new StateModel(isAdd);
            if (!state.Status)
            {
                state.Message = "创建题库失败，请联系管理员！";
            }
            return Json(state);
        }
        public JsonResult DeleteQueById(int id)
        {
            bool success = true;
            if (id<5000)
            {
               success= id%2==0? TopicMgr.DeleteJudById(id) : TopicMgr.DeleteQueById(id);
            }
            else
            {
                success = id % 2 == 0 ? TopicMgr.DeleteMoreById(id) : TopicMgr.DeleteSeById(id);
            }
            StateModel state = new StateModel(success);
            return Json(state, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddExamTest(Test obj,int id)
        {
            Test test = TPaperMgr.AddTest(obj,id);
            return Json(test);
        }
        public JsonResult GetTestList(UserParameter parameter, int id)
        {
            Pager<Test> list = TPaperMgr.GetTestList(parameter,id);
            return Json(list);
        }
        public JsonResult DeleteTestById(int id)
        {
            bool success = TPaperMgr.DeleteTestById(id);
            StateModel state = new StateModel(success);
            return Json(state, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMoreChioceById(int id)
        {
            MoreChoice test = TPaperMgr.GetMoreChioceById(id);
            return Json(test);
        }
        public JsonResult GetJudgeById(int id)
        {
            Judge test = TPaperMgr.GetJudgeById(id);
            return Json(test);
        }
        public JsonResult GetChoiceById(int id)
        {
            Choice test = TPaperMgr.GetChoiceById(id);
            return Json(test);
        }
        public JsonResult GetNarrativeById(int id)
        {
            QueAnswer test = TPaperMgr.GetNarrativeById(id);
            return Json(test);
        }
        public JsonResult DeleteTopicById(int id)
        {
            bool success = TPaperMgr.DeleteTopicById(id);
            StateModel state = new StateModel(success);
            return Json(state, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetChoiceList(string ids)
        {
            List<Choice> test = TPaperMgr.GetChoiceList(ids);
            return Json(test);
        }
        public JsonResult GetMoreChoiceList(string ids)
        {
            List<MoreChoice> test = TPaperMgr.GetMoreChoiceList(ids);
            return Json(test);
        }
        public JsonResult GetJudgeList(string ids)
        {
            List<Judge> test = TPaperMgr.GetJudgeList(ids);
            return Json(test);
        }
        public JsonResult GetNarrativeList(string ids)
        {
            List<QueAnswer> test = TPaperMgr.GetNarrativeList(ids);
            return Json(test);
        }
    }
}