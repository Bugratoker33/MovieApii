using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Results.CategoryResult
{
    public class GetCategoryQueryResults
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
