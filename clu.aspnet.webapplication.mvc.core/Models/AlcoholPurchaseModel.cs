using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clu.aspnet.webapplication.mvc.core.Models
{
    [Authorize(Policy = "AtLeast21")]
    public class AlcoholPurchaseModel : PageModel
    {

    }
}