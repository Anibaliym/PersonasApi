using FluentValidation.Results;

namespace Personas.Domain.Core.Messaging
{
    public class CommandResponse
    {
        public CommandResponse()
        {
            Timestamp = DateTime.Now;
            ValidationResult = new ValidationResult();
            Result = false;
            Data = string.Empty;
        }

        public bool Result { get; set; }
        public object Data { get; set; }
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
