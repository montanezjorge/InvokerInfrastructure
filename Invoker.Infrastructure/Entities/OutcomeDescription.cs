namespace Invoker.Infrastructure
{
    using System;

    public class OutcomeDescription
    {
        public OutcomeDescription()
        {

        }

        public OutcomeDescription(Guid id, string displayMessage, string verboseMessage = "")
        {
            this.OutcomeId = id;
            this.DisplayMessage = displayMessage;
            this.VerboseMessage = verboseMessage;
        }

        public OutcomeDescription(string stringId, string displayMessage, string verboseMessage = "")
        {
            this.OutcomeId = stringId;
            this.DisplayMessage = displayMessage;
            this.VerboseMessage = verboseMessage;
        }

        public Id OutcomeId { get; set; }

        public string DisplayMessage { get; set; }

        public string VerboseMessage { get; set; }
    }
}
