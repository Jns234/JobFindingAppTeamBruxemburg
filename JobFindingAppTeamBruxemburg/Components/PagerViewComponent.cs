using System.Threading.Tasks;
using JobFindingAppTeamBruxemburg.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobFindingAppTeamBruxemburg.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            result.LinkTemplate = Url.Action(RouteData.Values["action"].ToString(), new { page = "{0}" });

            return await Task.FromResult(View("Default", result));
        }
    }
}