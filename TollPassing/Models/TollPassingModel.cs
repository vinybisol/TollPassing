namespace TollPassing.Models
{
    public class TollPassingModel
    {
        public int Id { get; set; }
        public string? Vehicle { get; set; }
        public string? LicensePlate { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime DateTimeModification { get; set; }

        public static implicit operator TollPassingModel(InputModel.InputTollPassingModel inputTollPassingModel)
        {
            return new TollPassingModel()
            {
                Vehicle = inputTollPassingModel.Vehicle,
                LicensePlate = inputTollPassingModel?.LicensePlate,
                DateTime = DateTime.UtcNow
            };
        }
    }
}
