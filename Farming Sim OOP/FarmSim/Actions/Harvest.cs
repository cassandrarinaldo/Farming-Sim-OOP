using System.Linq;
using System.Dynamic;
using System.Collections;
public class Harvest : Action
{
    public override int energyCost => 3;
    public override string Info() => $"Harvest: {energyCost} energy";
    public override Row<Crop> Use(Farmer farmer, IDisplay display, Row<Crop> row)
    {
        if (farmer.Energy < energyCost)
        {
            display.PrintMessage("Not enough energy to harvest. Choose a different action");
            return row;
        }
        if(checkifEmpty(row, farmer))
            display.PrintMessage("You chose an empty row.");
        else if(row.item1.isMature)
        {
            farmer.Coins += row.item1.sellPrice;
            farmer.Energy -= energyCost;
            display.PrintMessage($"{farmer.farmerName} harvested {row.item1.Name} " + 
            $"and gained {row.item1.sellPrice} coins.");
            row = new Row<Crop>(new EmptyCrop(), row.index);
        }
        else if (row.item1.isRotten)
            display.PrintMessage($"{row.item1.Name} is rotten and can't be harvested. " + 
            "You need to destroy it.");
        else
            display.PrintMessage($"{row.item1.Name} is not mature yet.");
        return row;
    }
}
