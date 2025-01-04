public class SunEffect : IWeatherEffect 
{
    public void ProduceLightWeather(Row<Crop> row, IDisplay display)
    {
        row.item1.GrowthPoint += 3;
        display.PrintMessage($"{row.item1.Name} grew faster under the sun.");
    }
    public Row<Crop> ProduceHeavyWeather(Row<Crop> row, IDisplay display)
    { 
        display.PrintMessage($"Deadly sunrays! Your {row.item1.Name} got destroyed.");
        Row<Crop> affectedRow = new Row<Crop>(new EmptyCrop(), row.index);
        return affectedRow;
    }
}
