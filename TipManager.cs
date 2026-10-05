namespace CyberTipManager
{
    // Delegate: any method/lambda that takes a CyberTip and returns a string
    public delegate string TipFormatter(CyberTip tip);

    public class TipManager
    {
        // Event raised after each tip is displayed
        public event EventHandler<CyberTip>? TipDisplayed;

        public List<CyberTip> Tips { get; } = new List<CyberTip>
        {
            new CyberTip("Passwords", "Use a unique password for every account."),
            new CyberTip("Passwords", "Turn on two-factor authentication."),
            new CyberTip("Phishing", "Check the sender's address before clicking links."),
            new CyberTip("Phishing", "Banks never ask for your PIN by email."),
            new CyberTip("Privacy", "Review app permissions regularly."),
            new CyberTip("Privacy", "Avoid sharing personal details on public profiles.")
        };

        // Lambda expression with FindAll to filter by category (case-insensitive)
        public List<CyberTip> GetByCategory(string category) =>
            Tips.FindAll(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

        // Uses the delegate to format each tip, then raises the event
        public void DisplayTips(List<CyberTip> tips, TipFormatter formatter)
        {
            foreach (CyberTip tip in tips)
            {
                Console.WriteLine(formatter(tip));
                TipDisplayed?.Invoke(this, tip);
            }
        }
    }
}