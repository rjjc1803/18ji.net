using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveExam.Model.Entity
{

    [Table("Judge")]
    public class Judge
    {
        [Key]
        public int JudgeID { get; set; }
        public string Name { get; set; }
        public int Fraction { get; set; }
        public string Answer { get; set; }
        public int Topic { get; set; }


    }
}
