using System.Reflection.Metadata.Ecma335;
public class Game : IRun
{
    public WinnerCollection winners;
    public Game(WinnerCollection winners)
        => this.winners = winners;
    public void Run()
    {
        Display display = new();
        display.PrintMessage("Welcome to Wanja and Cassandra's Farming Simulator!");
        display.PrintMessage("First one to 25 coins win.");
        display.PrintMessage("What kind of game do you want to play?");
        FarmerFactory humanFactory = new HumanFarmerFactory(display);
        FarmerFactory robotFactory = new RobotFarmerFactory(display);
        List<FarmerFactory> factory  =
            new InteractiveNavigator<List<FarmerFactory>>(
                new ChoiceMenu<List<FarmerFactory>>([
                    new("Human farmer vs Robot farmer", new List<FarmerFactory>(){humanFactory, robotFactory}),
                    new ("Human farmer vs Human farmer", new List<FarmerFactory>(){humanFactory, humanFactory})
                ]),
                display
            ).Navigate();
        display.PrintMessage("Let's create our first farmer.");
        Farmer farmer1 = factory[0].Create("GANDALF", "MIDGARD");
        display.PrintMessage("Let's create our second farmer.");
        Farmer farmer2 = factory[1].Create("MERRY", "SHIRE");
        Farm farm = new Farm(farmer1, farmer2, winners);
        farm.Run();
    }
}