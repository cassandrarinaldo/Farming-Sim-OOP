public class SunEvent : WeatherEvent
{
    public SunEvent(IWeatherEffect weatherEffect) : base(weatherEffect) { }
    private Random random = new Random();
    public override Row<Crop> Affect(Row<Crop> row, IDisplay display)
    {
        display.PrintMessage("The sun is shining."); 
        display.PrintMessage("Checking severity...");
        int probability = random.Next(1, 101);
        if (probability <= 70)
            weatherEffect.ProduceLightWeather(row,display);
        else
            return weatherEffect.ProduceHeavyWeather(row,display);
        return row;
    }
}
