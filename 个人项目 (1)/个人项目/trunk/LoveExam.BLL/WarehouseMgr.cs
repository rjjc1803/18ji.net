using LoveExam.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;
using LoveExam.Model;
using LoveExam.Model.Parameter;

namespace LoveExam.BLL
{
    public class WarehouseMgr
    {
        public static bool AddExam(string ids,int tid)
        {
            string[] array = ids.Split(',');
            return WarehouseDAO.AddExam(array,tid);
        }

        public static bool BatchDeleteTestById(string ids)
        {
            string[] array = ids.Split(',');
            return WarehouseDAO.BatchDeleteTestById(array);
        }

        public static bool DeleteExamById(int id)
        {
            return WarehouseDAO.DeleteExamById(id);
        }

        public static bool AddStuTest(int tid, int cid, string uid)
        {
            string[] array = uid.Split(',');
            return WarehouseDAO.AddStuTest(tid,cid,array);
        }

        public static Test GetTestById(int id)
        {
            return WarehouseDAO.GetTestById(id);
        }

        public static Test UpdateStatById(int tid)
        {
            return WarehouseDAO.UpdateStatById(tid);
        }

        public static Pager<Exam> GetMoListByPage(UserParameter parameter, int tid)
        {
            return WarehouseDAO.GetMoListByPage(parameter,tid);
        }

        public static bool DeleteQueIDById(int id)
        {
            return WarehouseDAO.DeleteQueIDById(id);
        }
    }
}
