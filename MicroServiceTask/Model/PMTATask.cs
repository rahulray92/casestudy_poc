using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.Model
{
    [Table("Tasks", Schema = "dbo")]
    public class PMTATask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required]
        [Display(Name = "MemberName")]
        public string MemberName { get; set; }
        [Required]
        [Display(Name = "Member")]      
        public Int64 MemberId { get; set; }
       
        public virtual Member members { get; set; }
        [Required]
        [Display(Name = "TaskName")]
        public string TaskName { get; set; }
        [Required]
        [Display(Name = "Deliverables")]
        public string Deliverables { get; set; }

        [Required]
        [Display(Name = "TaskstartDate")]
        public string TaskstartDate { get; set; }
        [Required]
        [Display(Name = "TaskendDate")]
        public string TaskendDate { get; set; }
    }
}
