using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mercurynorth_netcore.Pages
{
    public class IndexModel : PageModel
    {
        Random _random = new Random();
        public void OnGet()
        {
            ViewData["FoundingYear"] = _random.Next(1940, 1991);
        }
    }
}
