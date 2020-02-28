using System.ComponentModel.DataAnnotations;

namespace Design_Bureau.Entities
{
    public class PriceDetails: BaseEntity
    {
        [Required]
        public double DesignCost { get; set; }

        [Required]
        public double ConstructionCost { get; set; }

        public MultiStoreyHouseProject MultiStoreyHouseProject { get; set; }
    }
}
