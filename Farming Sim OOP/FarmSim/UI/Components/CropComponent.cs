public class CropComponent
(
    Farmer farmer
) : IComponent
{
    public void Draw()
    {
        Console.WriteLine(farmer.Info);
        foreach(var row in farmer.plots)
        {
            Console.WriteLine();
            Console.WriteLine("############    ############    ############");
            Console.WriteLine("#          #    #          #    #          #");
            Console.WriteLine(
                $"# {row.item1.Name,-8} #    # {row.item2.Name,-8} #    # {row.item3.Name,-8} #"
            );
            Console.WriteLine(
                $"# {row.item1.GrowthPoint,2}/{row.item1.harvestPoint, -2} XP #    " +
                $"# {row.item2.GrowthPoint,2}/{row.item2.harvestPoint, -2} XP #    " +
                $"# {row.item3.GrowthPoint,2}/{row.item3.harvestPoint, -2} XP #"
            );
            Console.WriteLine("############    ############    ############");
        }
    }
}