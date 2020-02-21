namespace Design_Bureau.Entities
{
    public class PriceDetails: BaseEntity
    {
        public double DesignCost { get; set; }

        public double ConstructionCost { get; set; }

        public int MultiStoreyHouseProjectId { get; set; }

        public MultiStoreyHouseProject MultiStoreyHouseProject { get; set; }
    }
}
