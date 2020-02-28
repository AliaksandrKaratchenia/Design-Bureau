using System.ComponentModel.DataAnnotations;

namespace Design_Bureau.Entities
{
    public class TermsOfReference: BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [UIHint("IsRegistered")]
        public bool IsRegistered { get; set; }

        public MultiStoreyHouseProject MultiStoreyHouseProject { get; set; }
    }
}
