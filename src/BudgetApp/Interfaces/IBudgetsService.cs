using System.Collections.Generic;
using BudgetApp.Models;

namespace BudgetApp.Interfaces
{
    public interface IBudgetsService
    {
        void AddBudget(Budget bud);
        void DeleteBudget(int id);
        Budget GetBudget(int Id);
        Budget GetBudgetWithoutIncomes(int Id);
        List<Budget> ListBudgets();
        void UpdateBudget(Budget bud);
    }
}