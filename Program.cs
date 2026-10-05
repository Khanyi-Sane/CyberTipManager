using CyberTipManager;
using System.Runtime.Serialization;

var manager = new TipManager();

// Subscribe to the event with a lambda: runs every time a tip is displayed
manager.TipDisplayed += (sender, tip) =>
    Console.WriteLine($"   -> Tip displayed ({tip.Category}).");

// Assign a lambda to the delegate
TipFormatter formatter = tip => $"* {tip.Category.ToUpper()}: {tip.Message}";

// Display all stored tips first (uses ToString)
Console.WriteLine("=== All Cybersecurity Tips ===");
foreach (CyberTip tip in manager.Tips)
    Console.WriteLine(tip);

while (true)
{
    Console.Write("\nEnter a category (Passwords, Phishing, Privacy) or 'exit': ");
    string input = Console.ReadLine()?.Trim() ?? string.Empty;

    if (input.ToLower() == "exit")
    {
        Console.WriteLine("Goodbye, stay safe!");
        break;
    }

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Please enter a category.");
        continue;
    }

    List<CyberTip> matches = manager.GetByCategory(input);

    if (matches.Count == 0)
        Console.WriteLine($"No tips found for category '{input}'.");
    else
        manager.DisplayTips(matches, formatter);
}