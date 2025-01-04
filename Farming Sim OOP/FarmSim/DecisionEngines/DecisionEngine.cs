using System.Security.Cryptography;
public abstract class DecisionEngine
{ 
    public abstract INavigator<T> GetNavigator<T>(IMenu<T> menu, IDisplay display);
    public virtual Row<Crop> ChooseRow(Row<Row<Crop>> rowList, Farmer farmer, IDisplay display)
    {   
        display.PrintMessage("Choose row:");
        List<MenuItem<Row<Crop>>> items = [];
        foreach (var value in rowList)
            items.Add(new MenuItem<Row<Crop>>(value.Info(), value));
        items.Add(new MenuItem<Row<Crop>>("SKIP TURN", null));
        IMenu<Row<Crop>> menu = new ChoiceMenu<Row<Crop>>(items);
        var chosenAlternative = GetNavigator(menu, display).Navigate();
        if (chosenAlternative == null)
            farmer.Energy = 0;
        return chosenAlternative;
    }
    public virtual Row<Crop> ChooseAction(List<Action> actions, Farmer farmer, IDisplay display, Row<Crop> row)
    { 
        display.PrintMessage($"Choose what you want to do:");
        List<MenuItem<Action>> items = [];
        foreach(var value in actions)
            items.Add(new MenuItem<Action>(value.Info(), value));
        IMenu<Action> menu = new ChoiceMenu<Action>(items);
        return GetNavigator(menu, display).Navigate().Use(farmer, display, row);
    }
    public virtual Row<Crop> ChooseCrop(List<Row<Crop>> crops, Farmer farmer, IDisplay display)
    {
        display.PrintMessage("Choose what crop you want to plant:");
        List<MenuItem<Row<Crop>>> items = [];
        foreach (var value in crops)
            items.Add(new MenuItem<Row<Crop>>($"{value.item1.Name} : {value.item1.buyPrice} coins per plot", value));
        IMenu<Row<Crop>> menu = new ChoiceMenu<Row<Crop>>(items);
        return GetNavigator(menu, display).Navigate();
    }
}