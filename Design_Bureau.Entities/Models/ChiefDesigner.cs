using System.Collections.Generic;

namespace Design_Bureau.Entities
{
    public class ChiefDesigner: BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MultiStoreyHouseProject> MultiStoreyHouseProjects { get; set; }
    }
}
