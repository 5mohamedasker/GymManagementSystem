using GymManagementSystem.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class PlansController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using GymManagementSystemDbContext context = new GymManagementSystemDbContext();

            var plans = await context.Plans.ToListAsync();

            return View(plans);
        }
    }
}