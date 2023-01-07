using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL06.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PL06.Controllers
{
    public class StudentsController : Controller
    {
        private readonly PL06Context _context;

        public StudentsController(PL06Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var pl06Context = _context.Students.Include(c => c.Course);
            return View(await pl06Context.ToListAsync());
        }
        public async Task<IActionResult> Index2(string letter)
        {
            if(string.IsNullOrEmpty(letter) == false)
                return View(await _context.Students.Where(x => x.Name.StartsWith(letter)).Include(c => c.Course).ToListAsync());
            else
                return View(await _context.Students.Include(c => c.Course).ToListAsync());
        }
    }
}
