public interface IWeatherEffect
{
    void ProduceLightWeather(Row<Crop> row, IDisplay display);
    Row<Crop> ProduceHeavyWeather(Row<Crop> row, IDisplay display);
}