using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;
using LoveExam.DAL;
using LoveExam.Model;
using LoveExam.Model.Parameter;

namespace LoveExam.BLL
{
    public class UserMgr
    {
        public static Pager<User> GetListByPage(UserParameter parameter,int classid)
        {
            return UserDAO.GetListByPage(parameter, classid);
        }

        public static User Login(int uid, int pwd)
        {
            return UserDAO.Login(uid, pwd);
        }

        public static bool AddUser(User user)
        {
            return UserDAO.AddUser(user);
        }

        public static bool UpdateClassId(int userid, int classid)
        {
            return UserDAO.UpdateClassId(userid, classid);
        }

        public static bool UpdateById(User user)
        {
            return UserDAO.UpdateById(user);
        }

        public static bool UpdatePwdById(int uid, int pwd, int rpwd)
        {
            return UserDAO.UpdatePwdById(uid,pwd,rpwd);
        }

        public static bool BatchUpdate(string ids)
        {
            string[] array = ids.Split(',');
            return UserDAO.BatchUpdate(array);
        }

        public static List<User> GetUserByClassId(int id)
        {
            return UserDAO.GetUserByClassId(id);
        }

        public static bool UpadteClass(int id)
        {
            return UserDAO.UpadteClass(id);
        }
    }
}
