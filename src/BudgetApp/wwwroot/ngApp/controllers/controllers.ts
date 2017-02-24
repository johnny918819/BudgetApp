namespace BudgetApp.Controllers {

    export class HomeController {
        public budgets;

        public deleteBudget(id: number) {
            this.$http.delete(`/api/budgets/` + id).then((response) => {
                this.$state.reload();
            });
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`api/budgets`).then((response) => {
                this.budgets = response.data;
            })
        }
    }

    export class DetailsController {
        public budget;

        public deleteIncome(id: number) {
            this.$http.delete(`/api/incomes/` + id).then((response) => {
                this.$state.reload();
            });
        }
        public deleteBill(id: number) {
            this.$http.delete(`/api/bills/` + id).then((response) => {
                this.$state.reload();
            });
        }
        public deleteGoal(id: number) {
            this.$http.delete(`/api/goals/` + id).then((response) => {
                this.$state.reload();
            });
        }

        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            let budId = this.$stateParams[`id`];

            this.$http.get(`/api/budgets/` + budId).then((response) => {
                this.budget = response.data;
            })
        }
    }

    export class AddBudgetController {
        public budget;

        public addBudget() {
            this.$http.post(`/api/budgets`, this.budget).then((response) => {
                this.$state.go(`home`);
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

        }
    }
    
    export class EditBudgetController {
        public budget;
        public budId;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.budId = this.$stateParams[`id`];
            this.$http.get('/api/budgets/' + this.budId).then((response) => {
                this.budget = response.data;
            })
        }

        public editBudget() {
            this.$http.post(`/api/budgets`, this.budget).then((response) => {
                this.$state.go(`home`);
            })
        };

    }

    export class AddBillController {
        public bill;
        public budgets;

        public addBill() {
            this.$http.post(`/api/bills`, this.bill).then((response) => {
                this.$state.go(`home`);
            })
        };

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/budgets`).then((response) => {
                this.budgets = response.data;
            })
        }

    }

    export class EditBillController {
        public bill;
        public budgets;
        public billId;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.billId = this.$stateParams[`id`];
            this.$http.get(`/api/budgets`).then((response) => {
                this.budgets = response.data;
            })
            this.$http.get('/api/bills/' + this.billId).then((response) => {
                this.bill = response.data;
            })
        }

        public editBill() {
            this.$http.post(`/api/bills`, this.bill).then((response) => {
                this.$state.go(`home`);
            })
        }

    }

    export class AddIncomeController {
        public income;
        public budgets;

        public addIncome() {
            this.$http.post(`/api/incomes`, this.income).then((response) => {
                this.$state.go(`home`);
            })
        };

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/budgets`).then((response) => {
                this.budgets = response.data;
            })
        }

    }
    
    export class EditIncomeController {
        public income;
        public budgets;
        public incId;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.incId = this.$stateParams[`id`];
            this.$http.get(`/api/budgets`).then((response) => {
                this.budgets = response.data;
            })
            this.$http.get('/api/incomes/' + this.incId).then((response) => {
                this.income = response.data;
            })
        }

        public editIncome() {
            this.$http.post(`/api/incomes`, this.income).then((response) => {
                this.$state.go(`home`);
            })
        }

    }

    export class AddGoalController {
        public goal;
        public budgets;

        public addGoal() {
            this.$http.post(`/api/goals`, this.goal).then((response) => {
                this.$state.go(`home`);
            })
        };

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/budgets`).then((response) => {
                this.budgets = response.data;
            })
        }

    }

    export class EditGoalController {
        public goal;
        public budgets;
        public goalId;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.goalId = this.$stateParams[`id`];
            this.$http.get(`/api/budgets`).then((response) => {
                this.budgets = response.data;
            })
            this.$http.get('/api/goals/' + this.goalId).then((response) => {
                this.goal = response.data;
            })
        }

        public editGoal() {
            this.$http.post(`/api/goals`, this.goal).then((response) => {
                this.$state.go(`home`);
            })
        }

    }

    export class AdminController {
        public thing = `this`;
        public message;

        constructor($http: ng.IHttpService) {
            $http.get('/api/admin').then((results) => {
                this.message = results.data;
            });
        }
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }
}
