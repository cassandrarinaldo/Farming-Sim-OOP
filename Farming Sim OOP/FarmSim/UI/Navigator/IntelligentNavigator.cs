public class IntelligentNavigator<T>
(
  IMenu<T> menu, 
  IDisplay display
) : INavigator<T>
{
  public T Navigate()
  {
    while (true)
      display.PrintMenu(menu); 
  }
}
