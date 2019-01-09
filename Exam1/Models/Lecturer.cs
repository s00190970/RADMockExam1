using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Exam1.Models
{
    [Table("Lecturer")]
    public class Lecturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LecturerID { get; set; }
        public string LecturerName { get; set; }
        // One Lecturer can have many Subjects
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}