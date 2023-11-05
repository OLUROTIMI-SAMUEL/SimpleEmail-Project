using System.ComponentModel.DataAnnotations;

namespace Email_Project.Entities
{
    public class EmailModel
    {

        public string To { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;


    }
}
