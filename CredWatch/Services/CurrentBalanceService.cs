//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CredWatch.Models;
//using Microsoft.AspNetCore.Components;

//namespace CredWatch.Services
//{
//    public class CurrentBalanceService
//    {
//        private readonly AuthStateService AuthStateService;
//        private readonly TransactionService TransactionService;
//        private readonly DebtService DebtService;

//        private double CurrentBalance;

//        private List<Transaction> userTransactions = new List<Transaction>();
//        private List<Transaction> debtTransactions = new List<Transaction>();
//        private List<Transaction> creditDebitTransactions = new List<Transaction>();

//        public CurrentBalanceService(AuthStateService authStateService, TransactionService transactionService, DebtService debtService)
//        {
//            AuthStateService = authStateService;
//            TransactionService = transactionService;
//            DebtService = debtService;
//        }

//        public async Task<double> CalculateCurrentBalance()
//        {
            

//            try
//            {
//                User user = AuthStateService.GetLoggedInUser();
//                if (user != null) {
//                   await GetLoggedInUsersTransactionsAsync(user.UserId);
//                }
//            }catch (Exception ex)
//            {

//            }

//            return CurrentBalance;

//        }

//        private async Task GetLoggedInUserDetailAsync()
//        {
//            loggedInUser = authStateService.GetLoggedInUser();
//            if (loggedInUser == null)
//            {
//                navigationManager.NavigateTo("/");
//            }
//        }

//        private async Task GetLoggedInUsersTransactionsAsync()
//        {
//            // all transactions belonging to the logged in user
//            userTransactions = await transactionService.GetUsersTransactionsAsync(loggedInUser.UserId);
//        }

//        private async Task SeparateDebtsFromOtherTransactions()
//        {
//            debtTransactions = userTransactions.Where(t => t.CategoryId == "Debt").ToList();

//            creditDebitTransactions = userTransactions.Where(t => t.CategoryId != "Debt").ToList();
//        }

//        private async Task GetDebtRecords()
//        {
//            foreach (Transaction debtTransaction in debtTransactions)
//            {
//                // setting attributes already present in transaction obj
//                DisplayDebtModel displayDebtModel = new DisplayDebtModel(debtTransaction.TransactionId, debtTransaction.Title, debtTransaction.Amount,
//                    debtTransaction.CreatedDate, debtTransaction.Note, debtTransaction.TagId, debtTransaction.UserId, debtTransaction.CategoryId);

//                Debt debt = await DebtService.GetDebtByTransactionIdAsync(debtTransaction.TransactionId);

//                //setting the rest of the attributes
//                displayDebtModel.DebtId = debt.DebtId;
//                displayDebtModel.Source = debt.Source;
//                displayDebtModel.DueDate = debt.DueDate;
//                displayDebtModel.Status = debt.Status;

//                // adding to the list
//                debts.Add(displayDebtModel);
//            }
//        }
//    }
//}
