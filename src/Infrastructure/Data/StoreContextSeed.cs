using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LonShop.Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext storeContext, ILogger logger, int retry = 0)
    {
        var retryForAvailability = retry;

        try
        {
            if (storeContext.Database.IsSqlServer())
            {
                storeContext.Database.Migrate();
            }

        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(storeContext, logger, retryForAvailability);
            throw;
        }
    }
}