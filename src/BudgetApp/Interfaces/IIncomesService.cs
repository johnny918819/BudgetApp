using System.Collections.Generic;
using BudgetApp.Models;

namespace BudgetApp.Interfaces
{
    public interface IIncomesService
    {
        void AddIncome(Income income);
        void DeleteIncome(int id);
        void EditIncome(Income income);
        Income GetIncome(int id);
        List<Income> ListIncomes();
    }
}