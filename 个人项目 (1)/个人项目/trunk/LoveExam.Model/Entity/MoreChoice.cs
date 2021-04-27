using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveExam.Model.Entity
{
    [Table("MoreChoice")]
    public class MoreChoice
    {

        [Key]
        public int MoreChoiceID { get; set; }
        public string Name { get; set; }
        public int Fraction { get; set; }
        public string Answer { get; set; }
        public string Content { get; set; }
        public int Topic { get; set; }


    }
}
