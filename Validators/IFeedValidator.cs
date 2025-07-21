using FeedManagerApp.Models;
using FeedManagerApp.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Validators
{
    public interface IFeedValidator<T> where T : TradeFeed
    {
        ValidateResult Validate(T feed);
    }
}
