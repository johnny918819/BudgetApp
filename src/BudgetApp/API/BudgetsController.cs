using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models;
using BudgetApp.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.API
{
    [Route("api/[controller]")]
    public class BudgetsController : Controller
    {
        private IBudgetsService _budService;

        [HttpGet]
        public List<Budget> Get()
        {
            return _budService.ListBudgets();
        }

        [HttpGet("{id}")]
        public Budget Get(int id)
        {
            return _budService.GetBudget(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Budget budget)
        {
            if (budget == null)
            {
                return BadRequest();
            }
            else if (budget.Id == 0)
            {
                _budService.AddBudget(budget);
                return Ok();
            }
            else
            {
                _budService.UpdateBudget(budget);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _budService.DeleteBudget(id);
            return Ok();
        }

        public BudgetsController(IBudgetsService budService)
        {
            _budService = budService;
        }
    }
}
