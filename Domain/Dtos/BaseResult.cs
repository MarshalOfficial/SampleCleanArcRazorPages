using System.Text;

namespace Domain.Dtos
{
    public class BaseResult
    {
        public bool Succeed { get; set; }
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

        public string GetAllErrorMessages()
        {
            if (Errors.Count == 0) return string.Empty;

            var str = new StringBuilder();

            foreach (var error in Errors)
            {
                str.AppendLine(string.Join(Environment.NewLine, error.Value));
            }

            return str.ToString();
        }
    }
}