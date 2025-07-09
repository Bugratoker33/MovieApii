using MediatR;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Commands.TagCommand
{
    public class RemoveTagCommand:IRequest
    {
        public int TagId { get; set; }

        public RemoveTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}
