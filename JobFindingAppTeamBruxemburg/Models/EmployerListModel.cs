using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Models
{
    public class EmployerListModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Tags")]
        public List<TagModel> Tag { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}
