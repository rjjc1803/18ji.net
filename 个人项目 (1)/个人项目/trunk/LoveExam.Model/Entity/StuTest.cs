using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveExam.Model.Entity
{

    [Table("StuTest")]
    public class StuTest
    {
        [Key]
        public int StuTestID { get; set; }
        public int TestID { get; set; }
        public int ClassID { get; set; }
        public int StuID { get; set; }

    }
}
