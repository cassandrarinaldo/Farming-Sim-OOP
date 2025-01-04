using System.ComponentModel.Design;

public class Farmer
(
    string FarmerName,
    string FarmName,
    Row<Row<Crop>> plots,
    List<Action> actions,
    DecisionEngine decisionEngine
)
{
    public string farmerName = FarmerName;
    public string farmName = FarmName;
    public Row<Row<Crop>> plots = plots;
    public DecisionEngine decisionEngine = decisionEngine;
    public int Energy = 6;
    public int Coins = 20;
    List<Action> actions = actions;
    public bool hasLost = false;
    public string Info
    {
        get
        {
            string info = $"{farmerName} : {farmName} Farm ~~~~~ Energy: {Energy}   Coins: {Coins}";
            return info;
        }
    }
    public void ResetEnergy()
        => Energy = 6;
    public void ResetFarmer()
    {
        this.ResetEnergy();
        Coins = 20;
        plots = new Row<Row<Crop>>(
                new Row<Crop>(new EmptyCrop(), 0), 
                new Row<Crop>(new EmptyCrop(), 1),
                new Row<Crop>(new EmptyCrop(), 2), 
                0);
        hasLost = false;
    }
    public int checkEnergy()
    {
        var lowest=actions
            .OrderBy(action=> action.energyCost)
            .Select(action=>action.energyCost)
            .FirstOrDefault();
        return lowest;
    }
    public void CheckAvailableAction()
    {
        if(this.Coins < (new Wheat().buyPrice * 3) && plots.item1.item1.isEmpty 
            && plots.item2.item1.isEmpty && plots.item3.item1.isEmpty)
            hasLost = true;
        else
            hasLost = false;
    }
    public Row<Row<Crop>> PlayGame(Row<Row<Crop>> rows, IDisplay display)
    {
        CheckAvailableAction();
        if(hasLost)
        {
            display.PrintMessage("You lost.");
            return rows;
        }
        Row<Crop> chosenRow = decisionEngine.ChooseRow(rows, this, display);
        if (chosenRow == null)
            {
                display.PrintMessage("You skipped your turn");
                return rows;
            }
        Row<Crop> updatedRow = decisionEngine.ChooseAction(actions, this, display, chosenRow);
        int index = chosenRow.index;
        if (rows.item1.index == index)
            rows.item1 = new Row<Crop>(updatedRow.item1, updatedRow.index);
        else if (rows.item2.index == index)
            rows.item2 = new Row<Crop>(updatedRow.item1, updatedRow.index);
        else if (rows.item3.index == index)
            rows.item3 = new Row<Crop>(updatedRow.item1, updatedRow.index);
        if (Energy > 0 && Energy < checkEnergy())
            {
                display.PrintMessage("Not enough energy for any action. " +
                "Next players turn");
                Energy = 0;
            }
        CheckAvailableAction();
        return rows;
    }
} 