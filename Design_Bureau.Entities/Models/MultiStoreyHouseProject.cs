using System.Collections.Generic;

namespace Design_Bureau.Entities
{
    public class MultiStoreyHouseProject: BaseEntity
    {
        public string Name { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public TermsOfReference TermsOfReference { get; set; }

        public PriceDetails PriceDetails { get; set; }

        public int ChiefDesignerId { get; set; }

        public ChiefDesigner ChiefDesigner { get; set; }

        public ICollection<Designer> Designers { get; set; }
    }
}
