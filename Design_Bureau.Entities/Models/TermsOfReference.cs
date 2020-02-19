using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Bureau.Entities
{
    public class TermsOfReference: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsRegistered { get; set; }

        public int MultiStoreyHouseProjectId { get; set; }

        public MultiStoreyHouseProject MultiStoreyHouseProject { get; set; }
    }
}
