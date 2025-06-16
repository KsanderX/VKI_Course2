namespace Wedding_Agency.ViewModels
{
    internal class ContractDisplayModel
    {
        public int IdContract { get; set; }
        public string? ClientName { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? WeddingDate { get; set; }
        public int? TotalBudget { get; set; }
        public string? Description { get; set; }

        public string? LocationName { get; set; }
        public string? MenuName { get; set; }
        public string? DesignStyle { get; set; }
    }
}
