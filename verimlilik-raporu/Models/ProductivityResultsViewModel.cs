namespace verimlilik_raporu.Models
{


    public class ProductivityResultsViewModel
    {

        public object Results { get; set; }

        public int DepartmentId { get; set; }
        public int Id { get; set; }
        public bool IsExistP { get; set; }
        public string MachineCode { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public string MachineType { get; set; }
        public string MudurlukAdi { get; set; }
        public int Oee { get; set; }
        public int PerfA { get; set; }
        public int PerfP { get; set; }
        public int PerfQ { get; set; }
        public string ProcessEndDate { get; set; }
        public string ProcessStartDate { get; set; }
        public string ProductivityCalculationMethod { get; set; }
        public int ShiftId { get; set; }
        public string SignalType { get; set; }
        public int TotalA { get; set; }
        public bool TotalApprove { get; set; }
        public int TotalP { get; set; }

        public int TotalPD { get; set; }
        public int TotalShiftTime { get; set; }
        public int Type { get; set; }
        public string WhichShift { get; set; }

    }

}
