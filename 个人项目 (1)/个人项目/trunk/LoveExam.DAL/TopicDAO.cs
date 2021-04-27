using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;

namespace LoveExam.DAL
{
    public class TopicDAO
    {
        public static List<Topic> GetTopicList(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                return db.Topic
                    .Where(t => t.UserID == id)
                    .ToList();
            }
        }

        public static bool AddTopicByName(Topic obj)
        {
            using (ExamContext db = new ExamContext())
            {
                db.Topic.Add(obj);

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

        public static bool DeleteSeById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.Choice.Find(id);
                if (null != entity)
                {
                    db.Choice.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool DeleteMoreById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.MoreChoice.Find(id);
                if (null != entity)
                {
                    db.MoreChoice.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool DeleteJudById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.Judge.Find(id);
                if (null != entity)
                {
                    db.Judge.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool DeleteQueById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.QueAnswer.Find(id);
                if (null != entity)
                {
                    db.QueAnswer.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
