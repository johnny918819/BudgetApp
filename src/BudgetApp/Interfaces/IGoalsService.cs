using System.Collections.Generic;
using BudgetApp.Models;

namespace BudgetApp.Interfaces
{
    public interface IGoalsService
    {
        void AddGoal(Goal goal);
        void DeleteGoal(int id);
        void EditGoal(Goal goal);
        Goal GetGoal(int id);
        List<Goal> ListGoals();
    }
}