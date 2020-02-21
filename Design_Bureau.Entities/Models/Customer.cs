using System.Collections.Generic;

namespace Design_Bureau.Entities
{
    public class Customer: BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MultiStoreyHouseProject> MultiStoreyHouseProjects { get; set; }
    }
}
