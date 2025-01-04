public class RobotFarmerFactory
(
    IDisplay display
) : FarmerFactory
{
    public override Farmer Create(string defaultFarmer, string defaultFarm)
    {
        display.PrintMessage($"The Robot Farmer is called {defaultFarmer} and they own The {defaultFarm} Farm!");
        return new Farmer(
            defaultFarmer,
            defaultFarm,
            CreatePlots(),
            CreateActions(),
            new IntelligentDecisionEngine()
        );
    }
}