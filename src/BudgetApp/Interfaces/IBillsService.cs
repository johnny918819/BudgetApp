using System.Collections.Generic;
using BudgetApp.Models;

namespace BudgetApp.Interfaces
{
    public interface IBillsService
    {
        void AddBill(Bill bill);
        void DeleteBill(int id);
        void EditBill(Bill bill);
        Bill GetBill(int id);
        List<Bill> ListBills();
    }
}