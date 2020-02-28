using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Design_Bureau.Entities
{
    public class MultiStoreyHouseProject: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int TermsOfReferenceId { get; set; }

        public TermsOfReference TermsOfReference { get; set; }

        public int PriceDetailsId { get; set; }

        public PriceDetails PriceDetails { get; set; }

        public int ChiefDesignerId { get; set; }

        public ChiefDesigner ChiefDesigner { get; set; }

        public ICollection<Designer> Designers { get; set; }
    }
}
