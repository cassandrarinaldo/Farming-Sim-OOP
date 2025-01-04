
class EmptyCrop : Crop
{
    public override string Name => "EMPTY";
    public override int buyPrice => 0;
    public override int sellPrice => 0;
    public override int harvestPoint => 0;
    private int growthPoint = 0;
    public override bool isEmpty => true;
    public override bool isMature => false;
    public override bool isRotten => false;
}