using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam1.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StudentID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        // One Student can have many Subjects
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}