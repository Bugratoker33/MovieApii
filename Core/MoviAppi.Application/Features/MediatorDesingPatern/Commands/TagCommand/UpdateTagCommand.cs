using MediatR;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Commands.TagCommand
{
    public class UpdateTagCommand:IRequest
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
