using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.API
{
    [Route("api/[controller]")]
    public class SecretsController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<string> Get()
        {
            var user = this.User;
            return new string[] { "Page under Construction - this will view will soon allow Administrators to view and edit current User Accounts." };
        }


    }
}
