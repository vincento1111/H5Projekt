using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreH5Examples.Areas.Database.Models;
using AspNetCoreH5Examples.Codes;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreH5Examples.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("[controller]/[action]")]
    [Authorize("RequireAuthenticatedUser")]

    public class LoginsController : Controller
    {
        private readonly TestContext _context;
        private readonly IHashingExamples _hashingExamples;

        public LoginsController(TestContext context, IHashingExamples hashingExamples)
        {
            _context = context;
            _hashingExamples = hashingExamples;
        }


        // GET: Database/Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Database/Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Password,Salt")] Login login)
        {
            if (ModelState.IsValid)
            {
                login.Password = _hashingExamples.BcryptHash(login.Password);

                _context.Add(login);
                await _context.SaveChangesAsync();
                return View("Views/Home/Index.cshtml");
            }
            return View(login);
        }

        private bool LoginExists(int id)
        {
            return _context.Logins.Any(e => e.Id == id);
        }
    }
}
