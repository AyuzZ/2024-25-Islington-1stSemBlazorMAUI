using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredWatch.Models;
using CredWatch.DTOs;

namespace CredWatch.Services
{
    public class AuthStateService
    {

        public User LoggedInUser { get; set; }

        public BalanceDTO Balances { get; set; }
        public List<Transaction> UserTransactions { get; set; } = new List<Transaction>();
        public List<Transaction> CreditTransactions { get; set; } = new List<Transaction>();
        public List<Transaction> DebitTransactions { get; set; } = new List<Transaction>();
        public List<Transaction> DebtTransactions { get; set; } = new List<Transaction>();
        public List<Transaction> CreditDebitTransactions { get; set; } = new List<Transaction>();
        public List<Debt> Debts { get; set; } = new List<Debt>();
        public List<DebtDetailsDTO> DebtDetails { get; set; } = new List<DebtDetailsDTO>();
        public List<DebtDetailsDTO> PendingDebtDetails { get; set; } = new List<DebtDetailsDTO>();
        public List<DebtDetailsDTO> ClearedDebtDetails { get; set; } = new List<DebtDetailsDTO>();

        public event Action? OnAuthStateChanged;

        public bool IsDataLoaded { get;  set; } = false;

        public User? GetLoggedInUser()
        {
            return LoggedInUser;
        }

        public BalanceDTO? GetBalances()
        {
            return Balances;
        }

        public void SetLoggedInUser(User user)
        {
            LoggedInUser = user;
            NotifyAuthStateChanged();
        }

        public void SetUserData(BalanceDTO balances,
                            List<Transaction> userTransactions, List<Transaction> creditTransactions,
                            List<Transaction> debitTransactions, List<Transaction> debtTransactions, List<Transaction> creditDebitTransactions,
                            List<Debt> debts, List<DebtDetailsDTO> debtDetails,
                            List<DebtDetailsDTO> pendingDebtDetails, List<DebtDetailsDTO> clearedDebtDetails)
        {
            Balances = balances;
            UserTransactions = userTransactions;
            CreditTransactions = creditTransactions;
            DebitTransactions = debitTransactions;
            DebtTransactions = debtTransactions;
            CreditDebitTransactions = creditDebitTransactions;
            Debts = debts;
            DebtDetails = debtDetails;
            PendingDebtDetails = pendingDebtDetails;
            ClearedDebtDetails = clearedDebtDetails;

            IsDataLoaded = true;
        }

        public bool IsLoggedIn()
        {
            if (LoggedInUser != null)
            {
                return true;
            }
            return false;
        }

        public void Signout()
        {
            LoggedInUser = null;
            NotifyAuthStateChanged();
        }

        private void NotifyAuthStateChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}
