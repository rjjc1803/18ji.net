using LoveExam.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model;
using LoveExam.Model.Parameter;

namespace LoveExam.DAL
{
    public class WarehouseDAO
    {
        public static bool AddExam(string[] ids,int tid)
        {

            using (ExamContext db = new ExamContext())
            {
                for (int i = 0; i < ids.Length; i++)
                {
                Exam entiy = new Exam();
                entiy.QuestionID = int.Parse(ids[i]);
                entiy.TestID = tid;
                db.Exam.Add(entiy);
                db.SaveChanges();              
                }
                return true;
            }
        }

        public static bool DeleteExamById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var list = db.Exam.Where(t => t.TestID==id).ToList();
                foreach (var i in list)
                {
                    db.Exam.Remove(i);
                }
                db.SaveChanges();              
                return true;
            }
        }

        public static Test UpdateStatById(int tid)
        {
            using (ExamContext db = new ExamContext())
            {
                var dbEntity = db.Test.Find(tid);
                if (null == dbEntity)
                {
                    return null;
                }
                else
                {
                    dbEntity.TestStatus = "已发布";
                    db.SaveChanges();
                    return dbEntity;
                }
            }
        }

        public static bool DeleteQueIDById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.Exam.Find(id);
                 db.Exam.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        public static Pager<Exam> GetMoListByPage(UserParameter parameter, int tid)
        {
            Pager<Exam> result = new Pager<Exam>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.Exam.Where(t => t.TestID == tid)
                    .AsQueryable();
                //if (!string.IsNullOrEmpty(parameter.Name))
                //{
                //    query = query.Where(t => t.QuestionID.Contains(parameter.Name));
                //}

                result.Total = query.Count();
                result.Rows = query.OrderBy(t => t.ExamID)
                    .Skip(parameter.Skip)
                    .Take(parameter.PageSize)
                    .ToList();
                return result;
            }
        }

        public static Test GetTestById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                return db.Test.Find(id);

            }
        }

        public static bool AddStuTest(int tid, int cid, string[] uid)
        {
            using (ExamContext db = new ExamContext())
            {
                for (int i = 0; i < uid.Length; i++)
                {
                    StuTest entiy = new StuTest();
                    entiy.StuID = int.Parse(uid[i]);
                    entiy.TestID = tid;
                    entiy.ClassID = cid;
                    db.StuTest.Add(entiy);
                    db.SaveChanges();
                }
                return true;
            }
        }

        public static bool BatchDeleteTestById(string[] ids)
        {
            using (ExamContext db = new ExamContext())
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    var entity = db.Test.Find(int.Parse(ids[i]));
                    if (null != entity)
                    {
                        db.Test.Remove(entity);
                        db.SaveChanges(); 
                    }                   
                }
                return true;
            }
        }
    }
}
