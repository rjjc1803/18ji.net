using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveExam.Model.Entity;
using LoveExam.DAL;

namespace LoveExam.BLL
{
    public class TopicMgr
    {
        public static List<Topic> GetTopicList(int id)
        {
            return TopicDAO.GetTopicList(id);
        }

        public static bool AddTopicByName(Topic obj)
        {
            return TopicDAO.AddTopicByName(obj);
        }

        public static bool DeleteQueById(int id)
        {
            return TopicDAO.DeleteQueById(id);
        }

        public static bool DeleteJudById(int id)
        {
            return TopicDAO.DeleteJudById(id);
        }

        public static bool DeleteMoreById(int id)
        {
            return TopicDAO.DeleteMoreById(id);
        }

        public static bool DeleteSeById(int id)
        {
            return TopicDAO.DeleteSeById(id);
        }
    }
}
