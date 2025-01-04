class Carrot : Crop
{
    public override string Name => "CARROT";
    public override int buyPrice => 2;
    public override int sellPrice => 10;
    public override int harvestPoint => 4;
    private int growthPoint = 0;
    public override bool isEmpty => false;
}