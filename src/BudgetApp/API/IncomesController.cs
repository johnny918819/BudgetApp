using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models;
using BudgetApp.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.API
{
    [Route("api/[controller]")]
    public class IncomesController : Controller
    {
        public IIncomesService _incomesService;

        [HttpGet]
        public List<Income> Get()
        {
            return _incomesService.ListIncomes();
        }

        [HttpGet("{id}")]
        public Income Get(int id)
        {
            return _incomesService.GetIncome(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Income income)
        {
            if (income == null)
            {
                return BadRequest();
            }
            else if (income.Id == 0)
            {
                _incomesService.AddIncome(income);
                return Ok();
            }
            else
            {
                _incomesService.EditIncome(income);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _incomesService.DeleteIncome(id);
            return Ok();
        }

        public IncomesController(IIncomesService incomesService)
        {
            _incomesService = incomesService;
        }
    }
}

