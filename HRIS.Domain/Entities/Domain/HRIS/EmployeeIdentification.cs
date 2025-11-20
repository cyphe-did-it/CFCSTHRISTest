using HRIS.Domain.Entities.Common;
using HRIS.Domain.Entities.Domain.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities.Domain.HRIS
{
    public class EmployeeIdentification : BaseAuditableEntity
    {
        public Guid EmployeeIdentificationID { get; set; }
        public Guid EmployeeID { get; set; }      // FK
        public int IdentificationTypeID { get; set; } // FK

        public string IdentificationNumber { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string IssuedPlace { get; set; } = string.Empty;


        // Navigation Properties
        public Employee Employee { get; set; } = null!;
        public IdentificationType IdentificationType{ get; set; } = null!;

    }
}
