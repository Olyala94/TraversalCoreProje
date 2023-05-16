using DocumentFormat.OpenXml.Office2013.Word;

namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {
        public RemoveDestinationCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
