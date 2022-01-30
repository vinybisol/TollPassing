namespace TollPassing.Models
{
    public class TollPassingModel
    {
        public int Id { get; set; }
        public string? Vehicle { get; set; }
        public string LicensePlate { get; set; }
        public decimal Price { get; private set; }
        public DateTime DateTime { get; set; }
        public DateTime DateTimeModification { get; set; }

        public static implicit operator TollPassingModel(InputModel.InputTollPassingModel inputTollPassingModel)
        {
            return new TollPassingModel()
            {
                Vehicle = inputTollPassingModel.Vehicle,
                LicensePlate = inputTollPassingModel.LicensePlate,
                DateTime = DateTime.UtcNow
            };
        }

        public void UpdatePrice(int count, out decimal discountLevel)
        {
            decimal price = 7.90M;
            discountLevel = 0;
            
            if(count > 10)
            {
                discountLevel = count - 10;
                if(discountLevel >= 16)
                    discountLevel = 16;

                discountLevel *= 0.05M;
                decimal discount = price * discountLevel;
                price -= discount;
            }
            discountLevel *= 100;
            Price = Math.Round(price, 2);
        }
    }
}
