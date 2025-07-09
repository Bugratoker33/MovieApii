using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Queries.TagQueries
{
    public class GetTagByIdQueryResult:IRequest<GetTagByIdQueryResult>
    {
        public int TagId { get; set; }

        public GetTagByIdQueryResult(int tagId)
        {
            TagId = tagId;
        }
    }
}
