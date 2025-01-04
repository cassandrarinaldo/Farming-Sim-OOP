public class Farm
(
    Farmer farmer1,
    Farmer farmer2,
    WinnerCollection winners
) : IRun
{
    IDisplay display1 = new Display(new CropComponent(farmer1));
    IDisplay display2 = new Display(new CropComponent(farmer2));
    int goal = 25; 
    private Random random = new Random();
    public void CheckForWeatherEvent(Row<Row<Crop>> plots, IDisplay display)
    {
        int eventChance = random.Next(1, 101);
        if (eventChance <= 35)
            TriggerWeatherEvent(plots, display);
    }
    private void TriggerWeatherEvent(Row<Row<Crop>> plots, IDisplay display)
    {
        WeatherEvent weatherEvent;
        if (random.Next(0, 2) == 0)
            weatherEvent = new RainEvent(new RainEffect());
        else
            weatherEvent = new SunEvent(new SunEffect());
        Row<Crop> chosenRow = SelectRandomNonEmptyRow(plots);
        if (chosenRow != null)
        {
            Row<Crop> updatedRow = weatherEvent.Affect(chosenRow, display);
            if (plots.item1 == chosenRow)
                plots.item1 = updatedRow;
            else if (plots.item2 == chosenRow)
                plots.item2 = updatedRow;
            else if (plots.item3 == chosenRow)
                plots.item3 = updatedRow;
        }
    }
    private Row<Crop> SelectRandomNonEmptyRow(Row<Row<Crop>> plots)
    {
        var rows = new List<Row<Crop>> { plots.item1, plots.item2, plots.item3 }
            .Where(row => row != null && !row.item1.isEmpty 
                    && !row.item2.isEmpty && !row.item3.isEmpty)
            .ToList();
        return rows.Any() ? rows[random.Next(rows.Count)] : null;
    }
    public void PlayTurn(Farmer farmer, IDisplay display, int goal)
    {
        display1.PrintMessage($"{farmer.farmerName}'s turn.");
        CheckForWeatherEvent(farmer.plots, display);
        while(farmer.Energy > 0 && farmer.Coins < goal && !farmer.hasLost)
        {
            farmer.PlayGame(farmer.plots, display);
            if(farmer.hasLost)
                break;
        }
        if(farmer.Coins >= goal)
        {
            display1.PrintMessage($"{farmer.farmerName} won! Congratulations!");
            winners.AddWinner(farmer.farmerName);
        }
        if(farmer.hasLost)
            display.PrintMessage($"{farmer.farmerName} has lost. Your opponent has won.");
        else
            farmer.ResetEnergy();
    }    
    public void Run(){
        while (farmer1.Coins < goal && farmer2.Coins < goal 
                && !farmer1.hasLost && !farmer2.hasLost)
        {
            PlayTurn(farmer1, display1, goal);
            farmer1.CheckAvailableAction();
            if(farmer1.Coins >= goal) 
                break;
            if(farmer1.hasLost)
                break;
            Console.Clear();
            PlayTurn (farmer2, display2, goal);
            farmer2.CheckAvailableAction();
            if(farmer2.hasLost)
                break;
        }
        if(farmer1.hasLost)
            winners.AddWinner(farmer2.farmerName);
        if(farmer2.hasLost)
            winners.AddWinner(farmer1.farmerName);
        winners.PrintMostWins(display1);
        display1.PrintMessage("Do you want to play again?");
        List<string> playAgain =
            new InteractiveNavigator<List<string>>(
                new ChoiceMenu<List<string>>([
                    new ("YES", new List<string>(){"YES"}),
                    new("NO", new List<string>(){"NO"})
                ]),
                display1
            ).Navigate();
        if(playAgain.Contains("NO"))
        {
            display1.PrintMessage("See you next season, farmer!");
            Environment.Exit(0);
        }
        if(playAgain.Contains("YES"))
        {
            farmer1.ResetFarmer();
            farmer2.ResetFarmer();
            IRun newGame  =
                new InteractiveNavigator<IRun>(
                    new ChoiceMenu<IRun>([
                        new("Same players", new Farm(farmer1, farmer2, winners)),
                        new ("New players", new Game(winners))
                    ]),
                display1
            ).Navigate();
            newGame.Run();
        }
    }
}