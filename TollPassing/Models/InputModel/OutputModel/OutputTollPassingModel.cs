namespace TollPassing.Models.InputModel.OutputModel
{
    public class OutputTollPassingModel
    {
        public int Id { get; set; }
        public string? Vehicle { get; set; }
        public string? LicensePlate { get; set; }
        public decimal Price { get; set; }
        public int CountOfPassedInMonth { get; set; }
        public decimal DiscountLevel { get; set; }
        public DateTime DateTime { get; set; }
    }
}
