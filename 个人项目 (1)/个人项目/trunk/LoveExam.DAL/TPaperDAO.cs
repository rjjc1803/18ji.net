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
    public class TPaperDAO
    {


        public static Pager<Choice> GetSelectListByPage(UserParameter parameter, int topicid)
        {
            Pager<Choice> result = new Pager<Choice>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.Choice.Where(t => t.Topic == topicid)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(parameter.Name))
                {
                    query = query.Where(t => t.Name.Contains(parameter.Name));
                }

                result.Total = query.Count();
                result.Rows = query.OrderBy(t => t.ChoiceID)
                    .Skip(parameter.Skip)
                    .Take(parameter.PageSize)
                    .ToList();
                return result;
            }
        }

        public static Pager<Judge> GetJudListByPage(UserParameter parameter, int topicid)
        {
            Pager<Judge> result = new Pager<Judge>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.Judge.Where(t => t.Topic == topicid)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(parameter.Name))
                {
                    query = query.Where(t => t.Name.Contains(parameter.Name));
                }

                result.Total = query.Count();
                result.Rows = query.OrderBy(t => t.JudgeID)
                    .Skip(parameter.Skip)
                    .Take(parameter.PageSize)
                    .ToList();
                return result;
            }
        }

        public static bool DeleteTestById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.Test.Find(id);
                if (null != entity)
                {
                    db.Test.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Choice GetChoiceById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                Choice test = db.Choice.Find(id);
                return test;
            }
        }

        public static bool DeleteTopicById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                var entity = db.Topic.Find(id);
                if (null != entity)
                {
                    db.Topic.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<Judge> GetJudgeList(string[] array)
        {
            using (ExamContext db = new ExamContext())
            {

                IEnumerable<int> idList = array.Select(t => int.Parse(t));

                List<Judge> result = db.Judge.Where(t => idList.Contains(t.JudgeID)).ToList();
                return result;
            }
        }

        public static List<QueAnswer> GetNarrativeList(string[] array)
        {
            using (ExamContext db = new ExamContext())
            {

                IEnumerable<int> idList = array.Select(t => int.Parse(t));

                List<QueAnswer> result = db.QueAnswer.Where(t => idList.Contains(t.QueAnswerID)).ToList();
                return result;
            }
        }

        public static List<MoreChoice> GetMoreChoiceList(string[] array)
        {
            using (ExamContext db = new ExamContext())
            {

                IEnumerable<int> idList = array.Select(t => int.Parse(t));

                List<MoreChoice> result = db.MoreChoice.Where(t => idList.Contains(t.MoreChoiceID)).ToList();
                return result;
            }
        }

        public static List<Choice> GetChoiceList(string[] array)
        {
           
            using (ExamContext db = new ExamContext())
            {
                //List<Choice> result = db.Choice.Where(t => array.ToList().IndexOf(t.ChoiceID.ToString()) > -1).ToList();  
                IEnumerable<int> idList = array.Select(t=>int.Parse(t));

                List<Choice> result = db.Choice.Where(t=>idList.Contains(t.ChoiceID)).ToList();                     
                return result;
            }
        }

        public static QueAnswer GetNarrativeById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                QueAnswer test = db.QueAnswer.Find(id);
                return test;
            }
        }

        public static Judge GetJudgeById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                Judge test = db.Judge.Find(id);
                return test;
            }
        }

        public static MoreChoice GetMoreChioceById(int id)
        {
            using (ExamContext db = new ExamContext())
            {
                 MoreChoice test= db.MoreChoice.Find(id);
                return test;
            }
        }

        public static Pager<Test> GetTestList(UserParameter parameter,int id)
        {
            Pager<Test> result = new Pager<Test>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.Test.Where(t => t.UserID == id)
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

        public static Test AddTest(Test obj,int id)
        {
            if (id!=0)
            {
                using (ExamContext db = new ExamContext())
                {
                    var dbEntity = db.Test.Find(id);
                    if (null == dbEntity)
                    {
                        return null;
                    }
                    else
                    {
                        dbEntity.ObjNumber = obj.ObjNumber;
                        dbEntity.SubNumber = obj.SubNumber;
                        dbEntity.Score = obj.Score;
                        db.SaveChanges();
                        return dbEntity;
                    }
                }
            }
            using (ExamContext db = new ExamContext())
            {
                Test test=db.Test.Add(obj);
                db.SaveChanges();
                return test;    
            }
        }

        public static Pager<QueAnswer> GetQueListByPage(UserParameter parameter, int topicid)
        {
            Pager<QueAnswer> result = new Pager<QueAnswer>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.QueAnswer.Where(t => t.Topic == topicid)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(parameter.Name))
                {
                    query = query.Where(t => t.Name.Contains(parameter.Name));
                }

                result.Total = query.Count();
                result.Rows = query.OrderBy(t => t.QueAnswerID)
                    .Skip(parameter.Skip)
                    .Take(parameter.PageSize)
                    .ToList();
                return result;
            }
        }

        public static Pager<MoreChoice> GetMoListByPage(UserParameter parameter, int topicid)
        {
            Pager<MoreChoice> result = new Pager<MoreChoice>();
            using (ExamContext db = new ExamContext())
            {
                var query = db.MoreChoice.Where(t => t.Topic ==topicid)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(parameter.Name))
                {
                    query = query.Where(t => t.Name.Contains(parameter.Name));
                }

                result.Total = query.Count();
                result.Rows = query.OrderBy(t => t.MoreChoiceID)
                    .Skip(parameter.Skip)
                    .Take(parameter.PageSize)
                    .ToList();
                return result;
            }
        }





        public static bool AddSelect(Choice obj,int id)
        {
            if (id!=0)
          {
                using (ExamContext db = new ExamContext())
                {
                    var dbEntity = db.Choice.Find(id);
                    if (null == dbEntity)
                    {
                        return false;
                    }
                    else
                    {
                        dbEntity.Answer = obj.Answer;
                        dbEntity.Name = obj.Name;
                        dbEntity.Fraction = obj.Fraction;
                        dbEntity.Content = obj.Content;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            else
            {
                using (ExamContext db = new ExamContext())
                {
                    db.Choice.Add(obj);

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
        public static bool AddMoreSelect(MoreChoice obj)
        {
            using (ExamContext db = new ExamContext())
            {
                db.MoreChoice.Add(obj);

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
        public static bool AddNarrative(QueAnswer obj)
        {
            using (ExamContext db = new ExamContext())
            {
                db.QueAnswer.Add(obj);

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
        public static bool AddJudge(Judge obj)
        {
            using (ExamContext db = new ExamContext())
            {
                db.Judge.Add(obj);

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
