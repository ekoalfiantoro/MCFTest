namespace Backend.Models
{
    public class TransactionModel
    {
        public string AgreementNumber { get; set; }
        public string? BranchID { get; set; }
        public string? NoBPKB { get; set; }
        public DateTime? TanggalBPKBIn { get; set; }
        public DateTime? TanggalBPKB { get; set; }
        public string? NoFaktur { get; set; }
        public DateTime? TanggalFaktur { get; set; }
        public string? NomorPolisi { get; set; }
        public string? LokasiPenyimpanan { get; set; }
        public string? User { get; set; }
    }

}

