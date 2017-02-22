using BudgetApp.Interfaces;
using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class GoalsService : IGoalsService
    {
        private IRepository _repo;
        private IBudgetsService _budService;

        public List<Goal> ListGoals()
        {
            List<Goal> goals = (from g in _repo.Query<Goal>()
                                select new Goal
                                {
                                    Id = g.Id,
                                    Name = g.Name,
                                    Amount = g.Amount,
                                    Budget = g.Budget
                                }).ToList();
            return goals;
        }

        public Goal GetGoal(int id)
        {
            Goal goal = (from g in _repo.Query<Goal>()
                         where g.Id == id
                         select new Goal
                         {
                             Id = g.Id,
                             Name = g.Name,
                             Amount = g.Amount,
                             Budget = g.Budget
                         }).FirstOrDefault();
            return goal;
        }

        public void AddGoal(Goal goal)
        {
            Budget bud = _budService.GetBudgetWithoutIncomes(goal.Budget.Id);
            goal.Budget.Name = bud.Name;
            _repo.Add(goal);
        }

        public void EditGoal(Goal goal)
        {
            Budget bud = _budService.GetBudgetWithoutIncomes(goal.Budget.Id);
            goal.Budget = bud;
            _repo.Update(goal);
        }

        public void DeleteGoal(int id)
        {
            Goal goalToDelete = GetGoal(id);
            _repo.Delete(goalToDelete);
        }

        public GoalsService(IRepository repo, IBudgetsService budService)
        {
            _repo = repo;
            _budService = budService;
        }
    }
}
