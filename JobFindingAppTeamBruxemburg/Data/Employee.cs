using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    public class Employee
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public object Tags { get; set; }
    }
}
