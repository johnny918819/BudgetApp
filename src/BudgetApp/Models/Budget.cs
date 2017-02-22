using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Goal> Goals { get; set; }
    }
}
