using System.Runtime.InteropServices;
public class HumanFarmerFactory
(
    IDisplay display
) : FarmerFactory
{
    public override Farmer Create(string defaultFarmer, string defaultFarm)
    {
        string farmerName = getFarmerName(defaultFarmer);
        display.Redraw();
        string farmName = getFarmName(farmerName, defaultFarm);
        return new Farmer(
            farmerName,
            farmName,
            CreatePlots(),
            CreateActions(),
            new InteractiveDecisionEngine()
        );
    }
    private string getFarmerName(string defaultFarmer)
    {
        display.PrintMessage("Tell us your name!");
        string farmerName = new InteractiveNavigator<string>(
            new InputMenu(10), display).Navigate();
        if(farmerName.Length > 0)
        {
            if(farmerName == "MERRY")
            {
                display.PrintMessage("You can't choose that name. " + 
                "Try another one.");
                getFarmerName(defaultFarmer);
            }
            else
            {
                display.PrintMessage($"Welcome, {farmerName}!");
                return farmerName;
            }
        }
        else
        {
            display.PrintMessage($"You haven't picked a name. " + 
            $"You will be called {defaultFarmer}.");
            return defaultFarmer;
        }
        return "Something went wrong.";
    }
    private string getFarmName(string farmerName, string defaultFarm)
    {
        display.PrintMessage($"What is your farm called, {farmerName}?");
        string farmName = new InteractiveNavigator<string>(
            new InputMenu(10), display).Navigate();
        if(farmName.Length > 0)
        {
            if(farmName == "SHIRE")
            {
                display.PrintMessage("You can't choose that name. " + 
                "Try another one.");
                getFarmName(farmerName, defaultFarm);
            }
            else
            {
                display.PrintMessage($"Welcome to {farmName} Farm!");
                return farmName;
            }
        }
        else
        {
            display.PrintMessage($"You haven't picked a name for your farm. " + 
            $"It will be called {defaultFarm} Farm.");
            return defaultFarm;
        }
        return "Something went wrong.";
    }
}