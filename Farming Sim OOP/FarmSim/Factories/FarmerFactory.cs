public abstract class FarmerFactory
{
    public abstract Farmer Create(string defaultFarmer, string defaultFarm);
    protected Row<Row<Crop>> CreatePlots()
    {
        Row<Row<Crop>> plots = new Row<Row<Crop>>(
            new Row<Crop>(new EmptyCrop(), 0), 
            new Row<Crop>(new EmptyCrop(), 1), 
            new Row<Crop>(new EmptyCrop(), 2), 
            0);
        return plots;
    }
    protected List<Action> CreateActions()
    {
        List<Action> actions = new List<Action>(){
            new Plant(),
            new Harvest(),
            new Water(),
            new Fertilizer(),
            new Destruction()};
        return actions;
    }
}