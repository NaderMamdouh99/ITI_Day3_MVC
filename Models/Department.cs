namespace Labs_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dept_Id { get; set; }

        [StringLength(50)]
        public string Dept_Name { get; set; }

        [StringLength(100)]
        public string Dept_Desc { get; set; }

        [StringLength(50)]
        public string Dept_Location { get; set; }

        public int? Dept_Manager { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Hiredate { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
