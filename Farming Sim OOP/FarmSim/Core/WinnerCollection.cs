using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class WinnerCollection
{
    private List<string> winners = new List<string>();
    public void AddWinner(string winnerName) => winners.Add(winnerName);
    public void PrintMostWins(IDisplay display)
    {
        var mostFrequentWinner = winners
            .GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault();
        if (mostFrequentWinner != null)
            display.PrintMessage($"{mostFrequentWinner.Key} has the most wins with {mostFrequentWinner.Count()} wins.");
    }
}