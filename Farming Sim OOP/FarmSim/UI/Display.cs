using System.ComponentModel;

public class Display : IDisplay
{
    IComponent component;
    string currentMessage = "";
    int textBoxWidth = 40;
    public Display() : this(new EmptyComponent()) { }
    public Display(IComponent component)
        => this.component = component;
    public void Redraw()
    {
        Console.CursorVisible = false;
        Console.Clear();
        component.Draw();
        if(currentMessage.Length > 0)
            printMessageBox(currentMessage);
    }
    public void PrintMenu<T>(IMenu<T> menu)
    {
        Redraw();
        menu.Draw();
        Thread.Sleep(60);
    }
    public void PrintMessage(string message, bool autoNext = false)
    {
        currentMessage = message;
        for(int i = 0; i < message.Length; i++)
        {
            if(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter && !autoNext)
                break;
            currentMessage = message.Substring(0, i + 1);
            Redraw();
            Thread.Sleep(60);
        }
        int start = 0;
        while( start < message.Length)
        {
            int lineEnd = Math.Min(start + textBoxWidth, message.Length);
            if(lineEnd == message.Length)
                break;
            if(lineEnd < message.Length && message[lineEnd] != ' ')
            {
                int lastSpace = message.LastIndexOf(' ', lineEnd);
                if(lastSpace > start)
                    lineEnd = lastSpace;
            }
            currentMessage = message.Substring(start, lineEnd - start);
            Redraw();
            start = lineEnd + 1;
        }
        currentMessage = message + new string(' ', textBoxWidth - 2 - message.Length % textBoxWidth) + " >";
        Redraw();
        if(!autoNext)
            Console.ReadKey();
        currentMessage = message;
        Redraw();
    }
    void printMessageBox(char c) => printMessageBox(c.ToString());
    void printMessageBox(string message)
    {
        int i = 0;
        Console.WriteLine();
        Console.WriteLine(new string('~', textBoxWidth));
        while(i < message.Length)
        {
            int j = Math.Min(i + textBoxWidth, message.Length);
            if(j < message.Length && message[j] != ' ')
            {
                int lastSpace = message.LastIndexOf(' ', j);
                if(lastSpace >= i)
                    j = lastSpace;
            }
            Console.WriteLine(message.Substring(i, j - i).Trim());
            i = j + 1;
        }
        Console.WriteLine(new string('~', textBoxWidth));
    }
}