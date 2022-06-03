using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleProject.Entity.Entity
{
    public class TeacherModel
    {
        public TeacherModel()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TeacherId { get; set; }

        [Required]
        public string TeacherName { get; set; }

        [Required]
        public string Skills { get; set; }

        [Range(5,50)]
        public int TotalStudents { get; set; }

        [Required]
        public float Salary { get; set; }

        [Required]
        public DateTime AddedOn { get; set; }
    }
}
