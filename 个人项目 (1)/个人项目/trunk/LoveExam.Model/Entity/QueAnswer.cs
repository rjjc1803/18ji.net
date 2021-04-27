using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveExam.Model.Entity
{
    [Table("QueAnswer")]
   public class QueAnswer
    {
        [Key]
        public int QueAnswerID { get; set; }
        public string Name { get; set; }
        public int Fraction { get; set; }
        public string Answer { get; set; }
        public int Topic { get; set; }
    }
}
