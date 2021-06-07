using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Models
{
    public class EmployeeModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public object Tags { get; set; }
    }
}
