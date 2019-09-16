using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group4LMS.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            string directory = Environment.CurrentDirectory;
            Message = String.Format("Your directory is {0}.", directory);
        }
    }
}
