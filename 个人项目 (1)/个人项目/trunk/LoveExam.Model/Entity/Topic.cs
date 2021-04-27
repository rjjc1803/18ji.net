using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveExam.Model.Entity
{

    [Table("Topic")]
    public class Topic
    {
        [Key]
        public int TopicID  { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int UserID { get; set; }


    }
}
