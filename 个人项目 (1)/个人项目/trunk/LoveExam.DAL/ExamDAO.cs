using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model;
using LoveExam.Model.Entity;
using LoveExam.Model.Parameter;

namespace LoveExam.DAL
{
    public class ExamDAO
    {
        public static List<StuTest> GetTestIdList(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                 return db.StuTest
                    .Where(t=>t.StuID==id)
                    .ToList();     
            }
        }

        public static Pager<Test> GetTestList(UserParameter parameter, string[] ids)
        {
            int[] arr =new int[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                arr[i] = int.Parse(ids[i]);
            }
            Pager<Test> result = new Pager<Test>();
            using (ExamContext db = new ExamContext())
            {
                  var query = db.Test.Where(t => t.TestID == 7033)
                                    .AsQueryable();
                if (!string.IsNullOrEmpty(parameter.Name))
                {
                    query = query.Where(t => t.Name.Contains(parameter.Name));
                }

                result.Total = query.Count();
                result.Rows = query.OrderBy(t => t.TestID)
                    .Skip(parameter.Skip)
                    .Take(parameter.PageSize)
                    .ToList();
                return result;
            }
        }

        public static List<Exam> GetQueByTestId(int id)
        {
            List<Exam> result = new List<Exam>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.Exam.Where(t => t.TestID == id );
                result = query.ToList();
                return result;
            }
        }
    }
}
