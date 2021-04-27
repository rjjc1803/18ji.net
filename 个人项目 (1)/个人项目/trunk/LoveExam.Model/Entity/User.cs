namespace LoveExam.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("T_User")]
    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int PassWord { get; set; }

        public int WorkID { get; set; }

        [Required]
        [StringLength(2)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string SchName { get; set; }

        [Required]
        [StringLength(20)]
        public string EMail { get; set; }

        public int Profession { get; set; }

    }
}
