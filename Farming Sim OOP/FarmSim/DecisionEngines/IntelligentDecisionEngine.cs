using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class IntelligentDecisionEngine : DecisionEngine
{    
    Random random= new Random();
    public override Row<Crop> ChooseRow(Row<Row<Crop>> rowList, Farmer farmer, IDisplay display)
    {   
        var matureRow = rowList
            .Where(row => row.item1.isMature
                || row.item1.harvestPoint-row.item1.GrowthPoint == new Fertilizer().xpPoint 
                || row.item1.harvestPoint-row.item1.GrowthPoint == new Water().xpPoint)
            .OrderByDescending(row => row.item1.sellPrice)
            .FirstOrDefault();
        if (matureRow != null && farmer.Energy>=new Harvest().energyCost)
            return matureRow;
        var rottenRow= rowList
            .Where(row=> row.item1.isRotten)
            .OrderByDescending(row => row.item1.GrowthPoint)
            .FirstOrDefault();
        if (rottenRow != null)
            return rottenRow;
        var emptyRow= rowList
            .Where(row=> row.item1.isEmpty)
            .FirstOrDefault();
        if (emptyRow != null && farmer.Energy>=new Plant().energyCost 
                && farmer.Coins >= 3)
            return emptyRow;
        var allRows = rowList.ToList();
        var randomRow = allRows[random.Next(allRows.Count)];
        return randomRow;
    }
    public override Row<Crop> ChooseCrop(List<Row<Crop>> crops, Farmer farmer, IDisplay display)
    {
        Crop randomCrop;
        if(farmer.Coins < 3)
            return new Row<Crop>(new EmptyCrop(), 0);
        while (true)
        {
            int randomInt = random.Next(0, 101);
            if (randomInt <= 33)
                randomCrop = new Wheat();
            else if (randomInt > 33 && randomInt < 66)
                randomCrop = new Carrot();
            else
                randomCrop = new Potato();
            if (farmer.Coins >= randomCrop.buyPrice * 3)
                return new Row<Crop>(randomCrop, 0);
        }
    }
    public override Row<Crop> ChooseAction(List<Action> actions, Farmer farmer, IDisplay display, Row<Crop> row)
    {
        Action action = null;
        var crop=row.item1;
        if (crop.isEmpty && farmer.Energy >= new Plant().energyCost && farmer.Coins >= new Wheat().buyPrice * 3)
            action = new Plant();
        else if (crop.isMature && farmer.Energy >= new Harvest().energyCost)
            action = new Harvest();
        else if (crop.isRotten && farmer.Energy>=new Destruction().energyCost)
            action = new Destruction();
        else if (crop.harvestPoint - crop.GrowthPoint== new Water().xpPoint && farmer.Energy >= new Water().energyCost)
            action = new Water();
        else if (crop.harvestPoint - crop.GrowthPoint== new Fertilizer().xpPoint && farmer.Energy >= new Harvest().energyCost)
            action = new Fertilizer();
        else if (!crop.isMature && !crop.isRotten && farmer.Energy >= new Fertilizer().energyCost)
        { 
            int randomInt = random.Next(1, 101);
            if (randomInt <= 50)
                action= new Water();    
            else if (50<randomInt)
                action = new Fertilizer();
        }
        else if(!crop.isMature && !crop.isRotten && farmer.Energy >= new Water().energyCost)
            action= new Water();
        if (action != null && farmer.Energy >= action.energyCost)
            return new Row<Crop>(action.Use(farmer, display, row).item1, row.index);
        display.PrintMessage($"Too tired for any viable action! Next players turn.");
        farmer.Energy=0;
        return row;
    }
    public override INavigator<T> GetNavigator<T>(IMenu<T> menu, IDisplay display) 
        =>  new IntelligentNavigator<T>(menu, display);
}