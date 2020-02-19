using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Bureau.Entities
{
    public class ChiefDesigner: BaseEntity
    {
        public string Name { get; set; }

        public ICollection<MultiStoreyHouseProject> MultiStoreyHouseProjects { get; set; }
    }
}
