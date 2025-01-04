using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CredWatch.Models;

namespace CredWatch.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly string transactionsFilePath = Path.Combine(AppContext.BaseDirectory, "Transactions.json");
        private async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            try
            {
                if (!File.Exists(transactionsFilePath))
                {
                    return new List<Transaction>();
                }

                var json = await File.ReadAllTextAsync(transactionsFilePath);
                return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                return new List<Transaction>();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading transactions: {ioEx.Message}");
                return new List<Transaction>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while loading transactions: {ex.Message}");
                return new List<Transaction>();
            }
        }

        public async Task<List<Transaction>> GetUsersTransactionsAsync(int userId)
        {
            try
            {
                var transactions = await GetAllTransactionsAsync();
                // Return transactions filtered by userId or an empty list if tasks is null
                return (transactions ?? new List<Transaction>()).Where(t => t.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving tasks for user {userId}: {ex.Message}");
                return new List<Transaction>(); // Return an empty list in case of an exception
            }
        }

        public async Task<int> SaveTransactionAsync(Transaction transaction)
        {
            try
            {
                var transactions = await GetAllTransactionsAsync();

                // transaction id
                int transactionsCount = transactions.Count();
                transaction.TransactionId = transactionsCount + 1;

                //transaction date
                //// Get the current date
                //DateTime currentDate = DateTime.Now.Date;
                //// Format the date to string format (yyyy-MM-dd)
                //string formattedDate = currentDate.ToString("yyyy-MM-dd");

                transaction.CreatedDate = DateTime.Now.Date;

                transactions.Add(transaction);
                await WriteTransactionsToJson(transactions);

                return transaction.TransactionId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
                throw;
            }
        }

        private async Task WriteTransactionsToJson(List<Transaction> transactions)
        {
            try
            {
                var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(transactionsFilePath, json);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading transactions: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while saving transactions: {ex.Message}");
            }
        }

     
    }
}
