using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveExam.Model.Entity
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }
        public string Name { get; set; }
        public int ObjNumber { get; set; }
        public int SubNumber { get; set; }
        public string TestStatus { get; set; }
        public int Score { get; set; }
        public int UserID { get; set; }

    }
}
