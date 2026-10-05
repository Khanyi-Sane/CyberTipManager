namespace CyberTipManager
{
    public class CyberTip
    {
        public string Category { get; set; }
        public string Message { get; set; }

        public CyberTip(string category, string message)
        {
            Category = category;
            Message = message;
        }

        public override string ToString() => $"[{Category}] {Message}";
    }
}
