
public interface IDisplay
{
    void Redraw();
    void PrintMessage (string message, bool autoNext = false);
    void PrintMenu<T>(IMenu<T> menu);
}