using BudgetApp.Interfaces;
using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class IncomesService : IIncomesService
    {
        private IRepository _repo;
        private IBudgetsService _budService;

        public List<Income> ListIncomes()
        {
            List<Income> incomes = (from i in _repo.Query<Income>()
                                select new Income
                                {
                                    Id = i.Id,
                                    Name = i.Name,
                                    Amount = i.Amount,
                                    Budget = i.Budget
                                }).ToList();
            return incomes;
        }

        public Income GetIncome(int id)
        {
            Income income = (from i in _repo.Query<Income>()
                         where i.Id == id
                         select new Income
                         {
                             Id = i.Id,
                             Name = i.Name,
                             Amount = i.Amount,
                             Budget = i.Budget
                         }).FirstOrDefault();
            return income;
        }

        public void AddIncome(Income income)
        {
            Budget bud = _budService.GetBudgetWithoutIncomes(income.Budget.Id);
            income.Budget.Name = bud.Name;
            _repo.Add(income);
        }

        public void EditIncome(Income income)
        {
            Budget bud = _budService.GetBudgetWithoutIncomes(income.Budget.Id);
            income.Budget = bud;
            _repo.Update(income);
        }

        public void DeleteIncome(int id)
        {
            Income incomeToDelete = GetIncome(id);
            _repo.Delete(incomeToDelete);
        }

        public IncomesService(IRepository repo, IBudgetsService budService)
        {
            _repo = repo;
            _budService = budService;
        }

    }
}
