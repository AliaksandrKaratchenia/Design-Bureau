namespace Design_Bureau.Entities
{
    public class Designer: BaseEntity
    {
        public string Name { get; set; }

        public int MultiStoreyHouseProjectId { get; set; }

        public MultiStoreyHouseProject MultiStoreyHouseProject { get; set; }
    }
}
