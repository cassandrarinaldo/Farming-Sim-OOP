using System.Dynamic;
using System.Collections;
using System.Linq;
public class Plant : Action
{
    public override int energyCost => 2;
    public override string Info() => $"Plant: {energyCost} energy";
    public int cheapestCrop()
    {
        List<Row<Crop>> crop = new List<Row<Crop>>(){
            new Row<Crop>(
                new Wheat(), 
                new Carrot(), 
                new Potato(), 
                0)};
        var cheapest= crop
            .OrderByDescending(row => row.item1.buyPrice)
            .Select(row=> row.item1.buyPrice)
            .FirstOrDefault();
        return cheapest;
    }
    public override Row<Crop> Use(Farmer farmer, IDisplay display, Row<Crop> row)
    {
        if (farmer.Energy < energyCost)
        {
            display.PrintMessage("Not enough energy to plant. " + 
            "Try a different action");
            return row;
        }
        if(!checkifEmpty(row, farmer))
        {
            display.PrintMessage("There are no spaces to plant here. " + 
            "Try a different action.");
            return row;
        }
        if(farmer.Coins < cheapestCrop())
        {
            display.PrintMessage("You cannot afford any crop. " + 
            "Try a different action");
            return row;
        }
        else
        {
            List<Row<Crop>> crop = new List<Row<Crop>>(){
                new Row<Crop>(new Wheat(), row.index),
                new Row<Crop>(new Carrot(), row.index), 
                new Row<Crop>(new Potato(), row.index)};
            Row<Crop> updatedRow = farmer.decisionEngine.ChooseCrop(crop, farmer, display);
            if(farmer.Coins < updatedRow.item1.buyPrice * 3)
            {
                display.PrintMessage("You can't afford this crop. Try another one.");
                return row;
            }
            else
            {
                farmer.Coins -= updatedRow.item1.buyPrice * 3;
                farmer.Energy -= energyCost;
                display.PrintMessage($"{farmer.farmerName} planted {updatedRow.item1.Name} on ROW {row.index+1}.");
                return updatedRow;
            }
        }
    }
}
