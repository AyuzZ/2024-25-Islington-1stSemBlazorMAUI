using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using CredWatch.Models;
using CredWatch.DTOs;

namespace CredWatch.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IDebtService DebtService;

        public BalanceService(IDebtService debtService)
        {
            DebtService = debtService;
        }

        public (List<Transaction> creditTransactions, List<Transaction> debitTransactions, List<Transaction> debtTransactions, List<Transaction> creditDebitTransactions)
            SeparateTransactions(List<Transaction> userTransactions)
        {
            List<Transaction> creditTransactions = userTransactions.Where(t => t.Category == "Credit").ToList();
            List<Transaction> debitTransactions = userTransactions.Where(t => t.Category == "Debit").ToList();
            List<Transaction> debtTransactions = userTransactions.Where(t => t.Category == "Debt").ToList();
            List<Transaction> creditDebitTransactions = userTransactions.Where(t => t.Category != "Debt").ToList();

            return (creditTransactions, debitTransactions, debtTransactions, creditDebitTransactions);
        }

        public async Task<(List<DebtDetailsDTO> debtDetails, List<Debt> debts)>
            GetDebtDetailsAsync(List<Transaction> debtTransactions)
        {
            List<DebtDetailsDTO> debtDetails = new List<DebtDetailsDTO>();
            List<Debt> debts = new List<Debt>();

            foreach (Transaction debtTransaction in debtTransactions)
            {
                // setting attributes already present in transaction obj
                DebtDetailsDTO debtDetail = new DebtDetailsDTO(debtTransaction.TransactionId, debtTransaction.Title, debtTransaction.Amount,
                    debtTransaction.CreatedDate, debtTransaction.Note, debtTransaction.Tag, debtTransaction.UserId, debtTransaction.Category);

                Debt debt = await DebtService.GetDebtByTransactionIdAsync(debtDetail.TransactionId);

                //setting the rest of the attributes
                debtDetail.DebtId = debt.DebtId;
                debtDetail.Source = debt.Source;
                debtDetail.DueDate = debt.DueDate;
                debtDetail.IsCleared = debt.IsCleared;

                // adding to the list
                debtDetails.Add(debtDetail);
                debts.Add(debt);
            }

            return (debtDetails, debts);
        }

        public (List<DebtDetailsDTO> pendingDebtDetails, List<DebtDetailsDTO> clearedDebtDetails)
            SeparateDebtDetails(List<DebtDetailsDTO> debtDetails)
        {
            List<DebtDetailsDTO> pendingDebtDetails = debtDetails.Where(t => t.IsCleared == false).ToList();
            List<DebtDetailsDTO> clearedDebtDetails = debtDetails.Where(t => t.IsCleared == true).ToList();

            return (pendingDebtDetails, clearedDebtDetails);
        }
        public BalanceDTO CalculateBalances(List<Transaction> creditTransactions, List<Transaction> debitTransactions,
            List<DebtDetailsDTO> pendingDebtDetails, List<DebtDetailsDTO> clearedDebtDetails)
        {
            BalanceDTO balances = new BalanceDTO();
            balances.TotalInflow = creditTransactions.Sum(t => t.Amount);
            balances.TotalOutflow = debitTransactions.Sum(t => t.Amount);
            balances.PendingDebt = pendingDebtDetails.Sum(d => d.Amount);
            balances.ClearedDebt = clearedDebtDetails.Sum(d => d.Amount);

            balances.InflowsCount = creditTransactions.Count();
            balances.OutflowsCount = debitTransactions.Count();
            balances.PendingDebtsCount = pendingDebtDetails.Count();
            balances.ClearedDebtsCount = clearedDebtDetails.Count();

            balances.CurrentBalance = balances.TotalInflow + balances.PendingDebt - balances.TotalOutflow;

            return balances;
        }
    }
}
