using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Data;
using BudgetApp.Models;
using BudgetApp.Interfaces;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.API

{
    [Route("api/[controller]")]
    public class BillsController : Controller
    {
        public IBillsService _billsService;

        [HttpGet]
        public List<Bill> Get()
        {
            return _billsService.ListBills(); 
        }

        [HttpGet("{id}")]
        public Bill Get(int id)
        {
            return _billsService.GetBill(id); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] Bill bill)
        {
            if (bill == null)
            {
                return BadRequest();
            }
            else if (bill.Id == 0)
            {
                _billsService.AddBill(bill);
                return Ok();
            }
            else
            {
                _billsService.EditBill(bill);
                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            _billsService.DeleteBill(id);
            return Ok();
        }

        public BillsController(IBillsService billsService)
        {
            _billsService = billsService;
        }
    }
}
