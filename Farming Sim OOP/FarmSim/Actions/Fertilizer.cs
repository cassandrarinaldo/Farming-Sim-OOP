public class Fertilizer : Action
{
    public override int energyCost => 4;
    public override int xpPoint => 2;
    public override string Info() => $"Fertilize: {energyCost} energy (+{xpPoint} points)";
    public override Row<Crop> Use(Farmer farmer, IDisplay display, Row<Crop> row)
    {
        if (farmer.Energy<energyCost)
        {
            display.PrintMessage("Not enough energy to fertilize. Try a different action");
            return row;
        }
            if(checkifEmpty(row, farmer))
            {
                display.PrintMessage("There are no plants to fertilize here. Try a different action.");
                return row;
            }
             else
            {
                row.item1.GrowthPoint += xpPoint;
                farmer.Energy -= energyCost;
                display.PrintMessage($"{farmer.farmerName} fertilized ROW {row.index+1}, "+
                $"{row.item1.Name} now has {row.item1.GrowthPoint} points of {row.item1.harvestPoint}.");
            }
        return row;
    }
}