using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;
using LoveExam.Model.Parameter;
using LoveExam.DAL;
using LoveExam.Model;

namespace LoveExam.BLL
{
    public class ExamMgr
    {
        public static List<StuTest> GetTestIdList(int id)
        {
            return ExamDAO.GetTestIdList(id);
        }

        public static Pager<Test> GetTestList(UserParameter parameter, string ids)
        {
            string[] array = ids.Split(',');
            return ExamDAO.GetTestList(parameter,array);
        }

        public static List<Exam> GetQueByTestId(int id)
        {
            return ExamDAO.GetQueByTestId(id);
        }
    }
}
