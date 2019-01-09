using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Exam1.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }
        // One Subject can have many Students
        public virtual ICollection<Student> Students { get; set; }
        // One Subject can have many Lecturers
        public virtual ICollection<Lecturer> Lecturers { get; set; }
    }
}