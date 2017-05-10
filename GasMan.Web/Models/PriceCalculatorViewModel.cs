using System;

namespace GasMan.Web.Models
{
    public class PriceCalculatorViewModel
    {
        public DateTime Date { get; set; }

        public double Midwest_Average { get; set; }
        public double US_Average { get; set; }
        public double GasMileage { get; set; }
        public double MilesDriven { get; set; }
        public double TankSize { get; set; }

        public double PriceUS
        {
            get
            {
                return (MilesDriven / GasMileage ) * US_Average;
            }
        }

        public double PriceMidwest
        {
            get
            {
                return (MilesDriven / GasMileage) * Midwest_Average;
            }
        }

        public double GasTrips
        {
            get
            {
                return Math.Round((MilesDriven / TankSize));
            }
        }
    }
}