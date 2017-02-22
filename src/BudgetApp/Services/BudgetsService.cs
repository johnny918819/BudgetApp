using BudgetApp.Interfaces;
using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class BudgetsService : IBudgetsService
    {
        private IRepository _repo;

        private IBudgetsService _budService;

        public List<Budget> ListBudgets()
        {
            List<Budget> buds = (from b in _repo.Query<Budget>()
                                 select new Budget
                                 {
                                     Id = b.Id,
                                     Name = b.Name,
                                     Bills = b.Bills,
                                     Incomes = b.Incomes,
                                     Goals = b.Goals,
                                 }).ToList();
            return buds;
        }

        public Budget GetBudget(int Id)
        {
            Budget bud = (from b in _repo.Query<Budget>()
                          where b.Id == Id
                          select new Budget
                          {
                              Id = b.Id,
                              Name = b.Name,
                              Bills = b.Bills,
                              Incomes = b.Incomes,
                              Goals = b.Goals,
                          }).FirstOrDefault();
            return bud;
        }

        public Budget GetBudgetWithoutIncomes(int Id)
        {
            Budget bud = (from b in _repo.Query<Budget>()
                          where b.Id == Id
                          select b).FirstOrDefault();
            return bud;
        }

        public void AddBudget(Budget bud)
        {
            _repo.Add(bud);
        }

        public void UpdateBudget(Budget bud)
        {
            _repo.Update(bud);
        }

        public void DeleteBudget(int id)
        {
            Budget budToDelete = GetBudget(id);
            _repo.Delete(budToDelete);
        }

        public BudgetsService(IRepository repo)
        {
            _repo = repo;
        }
    }
}
