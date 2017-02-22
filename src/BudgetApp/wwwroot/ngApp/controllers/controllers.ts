namespace BudgetApp.Controllers {

    export class HomeController {
        public budgets;

        constructor(private $http: ng.IHttpService) {
            this.$http.get(`api/budgets`).then((response) => {
                this.budgets = response.data;
            })
        }
    }

    export class DetailsController {
        public budget;

        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService) {
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

        public editIncome() {
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

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class AboutController {
        public message = 'about page here';
    }
}
