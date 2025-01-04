
class Potato : Crop
{
    public override string Name => "POTATO";
    public override int buyPrice => 3;
    public override int sellPrice => 15;
    public override int harvestPoint => 6;
    private int growthPoint = 0;
    public override bool isEmpty => false;
}