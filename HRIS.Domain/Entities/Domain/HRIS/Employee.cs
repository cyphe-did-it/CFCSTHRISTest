using HRIS.Domain.Entities.Common;
using HRIS.Domain.Entities.Domain.Lookup;
using HRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities.Domain.HRIS
{
    public class Employee : BaseAuditableEntity
    {
        public Guid EmployeeID { get; set; }
        public string EmploymentID { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public ExtensionName? ExtensionName { get; set; }

        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public char SexAtBirth { get; set; }

        public int CivilStatusID { get; set; }      // FK
        public bool IsFilipino { get; set; }
        public bool IsDualCitizen { get; set; }
        public string? ImageSource { get; set; }


        // Navigation Properties
        public CivilStatus? CivilStatus { get; set; }
        public ICollection<EmployeeIdentification> EmployeeIdentifications { get; set; } = new List<EmployeeIdentification>();

    }
}
