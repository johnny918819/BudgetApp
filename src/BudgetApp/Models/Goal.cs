using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Budget Budget { get; set; }
    }
}
