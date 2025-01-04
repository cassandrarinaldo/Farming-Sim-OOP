using System.Linq;
using System.Dynamic;
using System.Collections;
public class Water : Action
{
    public override int energyCost => 2;    
    public override int xpPoint => 1;
    public override string Info() => $"Water: {energyCost} energy (+{xpPoint} points)";
    public override Row<Crop> Use(Farmer farmer, IDisplay display, Row<Crop> row)
    {
        if (farmer.Energy<energyCost)
        {
            display.PrintMessage("Not enough energy to water. Choose a different action");
            return row;
        }
        if(checkifEmpty(row, farmer))
        {
            display.PrintMessage("There are no plants to water here. Choose a different action.");
            return row;
        }
        else
        {
            row.item1.GrowthPoint += xpPoint;
            farmer.Energy -= energyCost;
            display.PrintMessage($"{farmer.farmerName} watered a row. " + 
            $"{row.item1.Name} now has {row.item1.GrowthPoint} points of {row.item1.harvestPoint}.");
        }
        return row;
    }
}