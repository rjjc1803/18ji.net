using LoveExam.BLL;
using LoveExam.Model;
using LoveExam.Model.Entity;
using LoveExam.MVC.Base;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace LoveExam.MVC.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
            ViewBag.CurUserPro = ContextObject.CurrentUser.Profession;
            ViewBag.Pro = (ViewBag.CurUserPro == 202 ? "教师":"学生");
            return View();
            }
            catch (System.Exception)
            {

                return RedirectToAction("Login");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult about()
        {
                return View();
        }
        public ActionResult SignIn(int uid, int pwd,int inf)
        {
            User result = UserMgr.Login(uid, pwd);
            
            StateModel state = new StateModel();
            if (null != result)
            {
                state.Status = true;
                // 当前用户对象赋值给session
                // Session["uname"] = result;
                ContextObject.CurrentUser = result;
                state.Message = "登录成功";
                //返回前端判断身份，实现不同页面
                Response.Cookies.Add(new HttpCookie("userpro", result.Profession.ToString()));
            }
            else
            {
                state.Status = false;
                state.Message = "用户名或密码错误！";
            }

            return inf==1? Json(result): Json(state);//用于数据的更新展示          
        }
        public ActionResult AddUser(User user)
        {
            bool isAdd = UserMgr.AddUser(user);
            StateModel state = new StateModel(isAdd);
            if (!state.Status)
            {
                state.Message = "注册发生异常，请联系管理员！";
            }
            return Json(state);
        }
        public ActionResult UpdateClassId(int userid, int classid)
        {
            bool success = UserMgr.UpdateClassId(userid, classid);
            StateModel state = new StateModel(success);
            if (!state.Status)
            {
                state.Message = "申请加入班级失败，请联系管理员！";
            }
            return Json(state);
        }
        public ActionResult UpdateById(User user)
        {
            bool success = UserMgr.UpdateById(user);
            StateModel state = new StateModel(success);
            if (!state.Status)
            {
                state.Message = "修改失败，请联系管理员！";
            }
            return Json(state);
        }
        public ActionResult BatchUpdate(string ids)
        {
            StateModel state = new StateModel();
            state.Status = UserMgr.BatchUpdate(ids);
            return Json(state);
        }
        public ActionResult Logout(User user)
        {
            // session 销毁
            Session.Abandon();

            // 主动注销则删除所有cookie，并不再进行自动登录
            RemoveAllCookie();

            return RedirectToAction("Login");
        }

        public JsonResult GetUserByClassId(int id)
        {

            List<User> result = UserMgr.GetUserByClassId(id);
            return Json(result);
        }
    }
}