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
    public class TPaperMgr
    {
        public static bool AddSelect(Choice obj,int id)
        {
            return TPaperDAO.AddSelect(obj,id);
        }

        public static bool AddJudge(Judge obj)
        {
            return TPaperDAO.AddJudge(obj);
        }

        public static bool AddNarrative(QueAnswer obj)
        {
            return TPaperDAO.AddNarrative(obj);
        }

        public static bool AddMoreSelect(MoreChoice obj)
        {
            return TPaperDAO.AddMoreSelect(obj);
        }

        public static Pager<Choice> GetSelectListByPage(UserParameter parameter, int topicid)
        {
            return TPaperDAO.GetSelectListByPage(parameter,topicid);
        }

        public static Pager<MoreChoice> GetMoListByPage(UserParameter parameter, int topicid)
        {
            return TPaperDAO.GetMoListByPage(parameter,topicid);
        }

        public static Pager<Judge> GetJudListByPage(UserParameter parameter, int topicid)
        {
            return TPaperDAO.GetJudListByPage(parameter, topicid);
        }

        public static Pager<QueAnswer> GetQueListByPage(UserParameter parameter, int topicid)
        {
            return TPaperDAO.GetQueListByPage(parameter,topicid);
        }

        public static Test AddTest(Test obj,int id)
        {
            return TPaperDAO.AddTest(obj,id);
        }

        public static Pager<Test> GetTestList(UserParameter parameter,int id)
        {
            return TPaperDAO.GetTestList(parameter,id);
        }

        public static bool DeleteTestById(int id)
        {
            return TPaperDAO.DeleteTestById(id);
        }

        public static MoreChoice GetMoreChioceById(int id)
        {
            return TPaperDAO.GetMoreChioceById(id);
        }

        public static Judge GetJudgeById(int id)
        {
            return TPaperDAO.GetJudgeById(id);
        }

        public static Choice GetChoiceById(int id)
        {
            return TPaperDAO.GetChoiceById(id);
        }

        public static QueAnswer GetNarrativeById(int id)
        {
            return TPaperDAO.GetNarrativeById(id);
        }

        public static bool DeleteTopicById(int id)
        {
            return TPaperDAO.DeleteTopicById(id);
        }

        public static List<Choice> GetChoiceList(string ids)
        {
            string[] array = ids.Split(',');
            return TPaperDAO.GetChoiceList(array);
        }

        public static List<MoreChoice> GetMoreChoiceList(string ids)
        {
            string[] array = ids.Split(',');
            return TPaperDAO.GetMoreChoiceList(array);
        }

        public static List<Judge> GetJudgeList(string ids)
        {
            string[] array = ids.Split(',');
            return TPaperDAO.GetJudgeList(array);
        }

        public static List<QueAnswer> GetNarrativeList(string ids)
        {
            string[] array = ids.Split(',');
            return TPaperDAO.GetNarrativeList(array);
        }
    }
}
