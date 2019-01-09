using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Exam1.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceID { get; set; }
        public DateTime AttendanceDate { get; set; }
        [ForeignKey("AssociatedSubject")]
        public int SubjectID { get; set; }
        [ForeignKey("AssociatedStudent")]
        public string StudentID { get; set; }
        public bool Present { get; set; }
        // One Attendance can have one Student
        public virtual Student AssociatedStudent { get; set; }
        // One Attendance can have one Subject
        public virtual Subject AssociatedSubject { get; set; }
    }
}