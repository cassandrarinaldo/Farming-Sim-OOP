public class RainEffect : IWeatherEffect
{
    public void ProduceLightWeather(Row<Crop> row, IDisplay display)
    {
        row.item1.GrowthPoint += 4;
        display.PrintMessage($"Your {row.item1.Name} was watered by the rain.");
    }
    public Row<Crop> ProduceHeavyWeather(Row<Crop> row, IDisplay display)
    { 
        display.PrintMessage($"There's a storm! Your {row.item1.Name} got destroyed.");
        Row<Crop> affectedRow = new Row<Crop>(new EmptyCrop(), row.index);
        return affectedRow;
    }
}