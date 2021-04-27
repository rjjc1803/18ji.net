using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;

namespace LoveExam.DAL
{
    public class ClassDAO
    {
        public static List<Class> GetClassList(int TeaID)
        {
              using (ExamContext db = new ExamContext())
            {
                return db.Class
                    .Where(t => t.TeacherID==TeaID)
                    .ToList();
            }
        }

        public static Class GetClassById(int iD)
        {
            using (ExamContext db = new ExamContext())
            {
                return db.Class.Find(iD);
                    
            }
        }

        public static bool DeleteClassById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.Class.Find(id);
                if (null != entity)
                {
                    db.Class.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool AddClassByName(Class obj)
        {
            using (ExamContext db = new ExamContext())
            {
                db.Class.Add(obj);

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
                    return msg == null;
                }
                return true;
            }
        }
    }
}
