

public class InputMenu
(
    int maxLength
) : IMenu<string>
{
    string value = "";
    public string SelectedItem => value;
    public void MoveUp() { }
    public void MoveDown() { }
    public void MoveLeft() { }
    public void MoveRight() { }
    public void SendChar(Char c)
    {
        if (Char.IsLetterOrDigit(c) && value.Length < maxLength)
            value += Char.ToUpper(c);
    }
    public void Delete() =>
        value = value.Substring(0, Math.Max(0, value.Length - 1));
    public void Draw()
    {
        Console.WriteLine("Only letters and digits, please!");
        Console.Write("> " + value);
    }
}
