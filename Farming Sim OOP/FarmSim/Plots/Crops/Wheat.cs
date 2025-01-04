class Wheat : Crop
{
    public override string Name => "WHEAT";
    public override int buyPrice => 1;
    public override int sellPrice => 5;
    public override int harvestPoint => 4;
    private int growthPoint = 0;
    public override bool isEmpty => false;
}