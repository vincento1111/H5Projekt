using AspNetCoreH5Examples.Codes;
using AspNetCoreH5Examples.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreH5Examples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHashingExamples _hashingExamples;
        private readonly IDataProtector _protector;

        public HomeController(
            ILogger<HomeController> logger, 
            IHashingExamples hashingExamples, 
            IDataProtectionProvider protector
        )
        {
            _logger = logger;
            _hashingExamples = hashingExamples;
            _protector = 
                protector.CreateProtector("AspNetCoreH5Examples.HomeController.NielsOlesen");
        }

        public IActionResult Index(string myPassword, string myEncryptedText)
        {
            // Running Hashing....
            IndexModel? indexModel = null;
            string? hashedValueAsString = null;

            if (myPassword != null)
            {
                hashedValueAsString = _hashingExamples.BcryptHash(myPassword);
                indexModel = new IndexModel() { HashedValueAsString = hashedValueAsString, OriginalText = myPassword };
            }

            // Running Encrypting....
            if(myEncryptedText != null)
            {
                string protectedPayload = _protector.Protect(myEncryptedText);
                

                string unprotectedPayload = _protector.Unprotect(protectedPayload);


                indexModel = new IndexModel() { OriginalEncryptionText = unprotectedPayload, EncryptedValueAsString = protectedPayload };
            }
            
            return View(model: indexModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}