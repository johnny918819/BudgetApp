using BudgetApp.Interfaces;
using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class BillsService : IBillsService
    {
        private IRepository _repo;
        private IBudgetsService _budservice;

        public List<Bill> ListBills()
        {
            List<Bill> bills = (from b in _repo.Query<Bill>()
                                select new Bill
                                {
                                    Id = b.Id,
                                    Name = b.Name,
                                    Amount = b.Amount,
                                    Budget = b.Budget
                                }).ToList();
            return bills;
        }

        public Bill GetBill(int id)
        {
            Bill bill = (from b in _repo.Query<Bill>()
                         where b.Id == id
                         select new Bill
                         {
                             Id = b.Id,
                             Name = b.Name,
                             Amount = b.Amount,
                             Budget = b.Budget
                         }).FirstOrDefault();
            return bill;
        }

        public void AddBill(Bill bill)
        {
            Budget bud = _budservice.GetBudgetWithoutIncomes(bill.Budget.Id);
            bill.Budget.Name = bud.Name;
            _repo.Add(bill);
        }

        public void EditBill(Bill bill)
        {
            Budget bud = _budservice.GetBudgetWithoutIncomes(bill.Budget.Id);
            bill.Budget = bud;
            _repo.Update(bill);
        }

        public void DeleteBill(int id)
        {
            Bill billToDelete = GetBill(id);
            _repo.Delete(billToDelete);
        }

        public BillsService(IRepository repo, IBudgetsService budservice)
        {
            _repo = repo;
            _budservice = budservice;
        }
    }
}
