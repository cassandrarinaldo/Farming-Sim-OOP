using System.Collections;

public abstract class Action
{
    public abstract string Info();
    public abstract Row<Crop> Use(Farmer farmer, IDisplay display, Row<Crop> row);
    public abstract int energyCost { get;}
    public virtual int xpPoint {get;}
    public virtual bool checkifEmpty(Row<Crop> crop, Farmer farmer)
    {
        foreach(var row in farmer.plots)
        {
            if(row.index == crop.index)
                return row.item1.isEmpty;
        }
        return default;
    }
}
