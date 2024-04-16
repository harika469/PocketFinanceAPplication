using FinanceApp.Server.Models.TickerDetails;
using Microsoft.AspNetCore.Identity;

namespace FinanceApp.Server.Models;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        TickerWatchlist = new HashSet<TickerResults>();
    }

    public virtual ICollection<TickerResults> TickerWatchlist { get; set; }
}