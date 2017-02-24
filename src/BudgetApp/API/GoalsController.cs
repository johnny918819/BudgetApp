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
    public class GoalsController : Controller
    {
        public IGoalsService _goalsService;

        [HttpGet]
        public List<Goal> Get()
        {
            return _goalsService.ListGoals();
        }

        [HttpGet("{id}")]
        public Goal Get(int id)
        {
            return _goalsService.GetGoal(id);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Goal goal)
        {
            if (goal == null)
            {
                return BadRequest();
            }
            else if (goal.Id == 0)
            {
                _goalsService.AddGoal(goal);
                return Ok();
            }
            else
            {
                _goalsService.EditGoal(goal);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _goalsService.DeleteGoal(id);
            return Ok();
        }

        public GoalsController(IGoalsService goalsService)
        {
            _goalsService = goalsService;
        }
    }
}
