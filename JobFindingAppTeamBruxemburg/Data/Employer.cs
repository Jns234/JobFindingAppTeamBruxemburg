using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Tags { get; set; }
        public string Location { get; set; }

        public IList<Employer> EmployerModels { get; set; }

        //    public Employer()
        //    {
        //        EmployerModels = new List<Employer>();
        //    }
        //}
    }
}
