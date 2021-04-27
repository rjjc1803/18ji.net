using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveExam.Model.Entity
{


    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }
        public int TestID { get; set; }
        public int QuestionID { get; set; }

    }
}
