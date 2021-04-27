using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;
using LoveExam.DAL;

namespace LoveExam.BLL
{
    public class ClassMgr
    {
        public static List<Class> GetClassList(int TeaID)
        {
            return ClassDAO.GetClassList(TeaID);
        }

        public static Class GetClassById(int iD)
        {
            return ClassDAO.GetClassById(iD);
        }

        public static bool AddClassByName(Class obj)
        {
            return ClassDAO.AddClassByName(obj);
        }

        public static bool DeleteClassById(int id)
        {
            return ClassDAO.DeleteClassById(id);
        }
    }
}
