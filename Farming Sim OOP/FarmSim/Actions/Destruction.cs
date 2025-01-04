using System.Collections.Generic;
using System.Linq;
public class Destruction : Action
{ 
    public override int energyCost => 2;
    public override string Info() => $"Destroy: {energyCost} energy";
    public override Row<Crop> Use(Farmer farmer, IDisplay display, Row<Crop> row)
    {
        if (farmer.Energy < energyCost)
        {
            display.PrintMessage("Not enough energy to destroy. Try a different action");
            return row;
        }
        else
        {
            if(checkifEmpty(row, farmer))
            {
                display.PrintMessage("There are only empty plots here. Try a different action.");
                return row;
            }
            else
            {
                farmer.Energy -= energyCost;
                display.PrintMessage($"{farmer.farmerName} destroyed {row.item1.Name} on ROW {row.index+1}");
                row = new Row<Crop>(new EmptyCrop(), row.index);
            }
        }
        return row;
    }
}