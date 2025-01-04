
public abstract class WeatherEvent
{
    protected IWeatherEffect weatherEffect;
    public WeatherEvent(IWeatherEffect weatherEffect)=> this.weatherEffect = weatherEffect;
    public abstract Row<Crop> Affect(Row<Crop> row, IDisplay display);
}