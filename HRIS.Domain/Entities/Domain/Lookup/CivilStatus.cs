using HRIS.Domain.Entities.Domain.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities.Domain.Lookup
{
    public class CivilStatus
    {
        public int CivilStatusID { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public char StatusCode { get; set; }


        // Navigation Properties
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
