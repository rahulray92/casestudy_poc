using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMT_DAL.Models
{
    [Table("Tasks", Schema = "dbo")]
    public class PMTTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "MemberName")]
        public string MemberName { get; set; }
        [Required]
        [Display(Name = "MemberId")]
        public Int64 MemberId { get; set; }
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
