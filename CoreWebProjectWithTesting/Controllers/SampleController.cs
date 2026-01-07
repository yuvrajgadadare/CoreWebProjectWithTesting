using CoreWebProjectWithTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebProjectWithTesting.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            List<State> lst = new List<State>();
            lst.Add(new State() { StateId = 1, StateName = "Maharashtra" });
            lst.Add(new State() { StateId = 2, StateName = "Goa" });
            lst.Add(new State() { StateId = 3, StateName = "Gujrat" });
            lst.Add(new State() { StateId = 4, StateName = "Rajasthan" });
            lst.Add(new State() { StateId = 5, StateName = "Panjab" });
            lst.Add(new State() { StateId = 6, StateName = "Kerala" });
            lst.Add(new State() { StateId = 7, StateName = "Karnataka" });
            return View(lst);
        }
    }
}
