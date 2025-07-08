using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Commands.CategoryCommand
{
    public class CreteCategoryCommand
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
