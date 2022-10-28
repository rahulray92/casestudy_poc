using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMT_DAL.Models
{
    [Table("Members", Schema = "dbo")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "TeamMemberName")]
        public string TeamMemberName { get; set; }
        [Required]
        [Display(Name = "MemberId")]
        
        public Int64 MemberId { get; set; }
        [Required]
        [Display(Name = "YearOfExp")]
        public int YearOfExp { get; set; }
        [Required]
        [Display(Name = "SkillSet")]
        public string SkillSet { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "ProjectstartDate")]
        public string ProjectstartDate { get; set; }
        [Required]
        [Display(Name = "ProjectendDate")]
        public string ProjectendDate { get; set; }
        [Required]
        [Display(Name = "AllocationPercentage")]
        public string AllocationPercentage { get; set; }
        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
