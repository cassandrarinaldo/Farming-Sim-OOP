using System.Runtime.InteropServices.Marshalling;

public abstract class Crop
{
    public abstract string Name { get;}
    public abstract int buyPrice { get;}
    public abstract int sellPrice { get;}
    public abstract int harvestPoint { get;}
    private int growthPoint;
    public virtual bool isEmpty { get; set;}
    public virtual bool isMature => GrowthPoint == harvestPoint;
    public virtual bool isRotten => GrowthPoint > harvestPoint;
    public virtual int GrowthPoint
    { 
        get {return growthPoint;} 
        set { growthPoint = value;}
    }   
}