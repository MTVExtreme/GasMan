using GasMan.Data;
using GasMan.Models;

namespace GasMan.Services
{
    class GasService
    {
        public bool GasCreate(CreateGas model)
        {
            var entity =
                new RetailPrice
                {
                    Date = model.Date,
                    US_Average = model.US_Average,
                    Speedway_Average = model.Speedway_Average,
                    BP_Average = model.BP_Average,
                    Shell_Average = model.Shell_Average
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GasPrices.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
