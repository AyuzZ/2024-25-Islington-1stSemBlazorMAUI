using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWatch.Models;
using CredWatch.DTOs;

namespace CredWatch.Services
{
    public interface IBalanceService
    {
        (List<Transaction> creditTransactions, List<Transaction> debitTransactions, List<Transaction> debtTransactions, List<Transaction> creditDebitTransactions)
            SeparateTransactions(List<Transaction> userTransactions);

        Task<(List<DebtDetailsDTO> debtDetails, List<Debt> debts)>
            GetDebtDetailsAsync(List<Transaction> debtTransactions);

        (List<DebtDetailsDTO> pendingDebtDetails, List<DebtDetailsDTO> clearedDebtDetails)
            SeparateDebtDetails(List<DebtDetailsDTO> debtDetails);

        BalanceDTO CalculateBalances(List<Transaction> creditTransactions, List<Transaction> debitTransactions,
            List<DebtDetailsDTO> pendingDebtDetails, List<DebtDetailsDTO> clearedDebtDetails);
    }
}
