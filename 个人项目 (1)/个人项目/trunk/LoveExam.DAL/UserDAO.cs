using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;
using LoveExam.Model.Parameter;
using LoveExam.Model;

namespace LoveExam.DAL
{
    public class UserDAO
    {
        public static Pager<User> GetListByPage(UserParameter parameter,int classid)
        {
            Pager<User> result = new Pager<User>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.T_User.Where(t => t.Profession == 101)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(parameter.Name))
                {
                    query = query.Where(t => t.Name.Contains(parameter.Name));
                }

                result.Total = query.Count();
                result.Rows = query.OrderBy(t => t.UserID)
                    .Skip(parameter.Skip)
                    .Take(parameter.PageSize)
                    .ToList();
                return result;
            }
        }

        public static bool UpdateById(User user)
        {
            using (ExamContext db = new ExamContext())
            {
                var dbEntity = db.T_User.Find(user.UserID);
                if (null == dbEntity)
                {
                    return false;
                }
                else
                {
                    dbEntity.WorkID = user.WorkID;
                    dbEntity.Name = user.Name;
                    dbEntity.Gender = user.Gender;
                    dbEntity.SchName = user.SchName;
                    dbEntity.EMail = user.EMail;
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public static bool UpadteClass(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var dbEntity = db.T_User
                    .Where(t => t.UserID == id)
                    .FirstOrDefault();
                if (null == dbEntity)
                {
                    return false;
                }
                else
                {
                   
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public static List<User> GetUserByClassId(int id)
        {
            List<User> result = new List<User>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.T_User.Where(t => t.Profession==101);
                    result=query.ToList();
                return result;
            }
        }

        public static bool BatchUpdate(string[] array)
        {
            using (ExamContext db = new ExamContext())
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var dbEntity = db.T_User.Find(int.Parse(array[i]));
                    
                }
                db.SaveChanges();
                return true;
            }
        }

        public static bool UpdatePwdById(int uid, int pwd, int rpwd)
        {
            using (ExamContext db = new ExamContext())
            {
                var dbEntity = db.T_User
                    .Where(t => t.UserID == uid && t.PassWord == pwd)
                    .FirstOrDefault();
                if (null == dbEntity || dbEntity.PassWord==rpwd)
                {
                    return false;
                }
                else
                {
                    dbEntity.PassWord = rpwd;
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public static bool UpdateClassId(int userid, int classid)
        {
            using (ExamContext db = new ExamContext())
            {
                var dbEntity = db.T_User.Find(userid);
                if (null == dbEntity)
                {

                    return false;
                }
                else
                {
                    
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public static User Login(int uid, int pwd)
        {
            using (ExamContext db = new ExamContext())
            {
                var res = db.T_User
                    .Where(t =>t.UserID == uid && t.PassWord == pwd)
                    .FirstOrDefault();
                return res;
            }
        }

        public static bool AddUser(User user)
        {
            using (ExamContext db = new ExamContext())
            {
                db.T_User.Add(user);
                
                try
                {
                  db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    var msg = string.Empty;
                    var errors = (from u in ex.EntityValidationErrors select u.ValidationErrors).ToList();
                    foreach (var item in errors)
                        msg += item.FirstOrDefault().ErrorMessage;
                    return msg==null;
                }
                return true;
            }
        }
    }
}
