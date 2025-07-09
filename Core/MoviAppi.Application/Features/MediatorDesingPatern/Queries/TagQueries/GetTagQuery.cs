using MediatR;
using MoviAppi.Application.Features.MediatorDesingPatern.Result.TagResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Queries.TagQueries
{
    public class GetTagQuery:IRequest<List<GetTagQuertResult>>
    {

    }
}
