using HRIS.Domain.Entities.Common;
using HRIS.Domain.Entities.Domain.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities.Domain.Lookup
{
    public class IdentificationType : BaseAuditableEntity
    {
        public int IdentificationTypeID { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        // Navigation Properties
        public ICollection<EmployeeIdentification> EmployeeIdentifications{ get; set; } = new List<EmployeeIdentification>();
    }
}
