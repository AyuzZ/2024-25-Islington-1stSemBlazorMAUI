using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWatch.DTOs
{
    public class BalanceDTO
    {
        public double TotalInflow {  get; set; }
        public double InflowsCount { get; set; }
        public double TotalOutflow { get; set; }
        public double OutflowsCount { get; set; }
        public double PendingDebt { get; set; }
        public double PendingDebtsCount { get; set; }
        public double ClearedDebt { get; set; }
        public double ClearedDebtsCount { get; set; }
        public double CurrentBalance { get; set; }
        public BalanceDTO() { }
    }
}
