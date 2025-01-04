
public class ChoiceMenu<T>
(
    IEnumerable<MenuItem<T>> items,
    int selectedIndex = 0
) : IMenu<T>
{
    readonly IList<MenuItem<T>> items = items.ToList();
    public void Draw()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.Write(i == selectedIndex ? "> " : "  ");
            Console.WriteLine(items[i].Name);
        }
    }
    public void MoveUp()
        => selectedIndex = Math.Clamp(selectedIndex - 1, 0, items.Count - 1);
    public void MoveDown()
        => selectedIndex = Math.Clamp(selectedIndex + 1, 0, items.Count - 1);
    public void MoveLeft() => MoveUp();
    public void MoveRight() => MoveDown();
    public void SendChar(Char c) { }
    public void Delete() { }
    public T SelectedItem => items[selectedIndex].Value;
}
