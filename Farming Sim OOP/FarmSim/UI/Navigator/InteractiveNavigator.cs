
public class InteractiveNavigator<T>
(
    IMenu<T> menu, 
    IDisplay display
) : INavigator<T>
{
    public T Navigate()
    {
        while (true)
        {
            display.PrintMenu(menu);
            var keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    return menu.SelectedItem;
                case ConsoleKey.UpArrow:
                    menu.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    menu.MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    menu.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    menu.MoveRight();
                    break;
                case ConsoleKey.Backspace:
                    menu.Delete();
                    break;
                default:
                    menu.SendChar(keyInfo.KeyChar);
                    break;
            }
        }
    }
}