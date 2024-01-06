namespace Personas.Domain.Core.Models
{
    public class ResponseCommand
    {
        public bool Result { get; set; }
        public object Data { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
