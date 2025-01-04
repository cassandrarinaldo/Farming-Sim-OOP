
public interface IMenu<T>
{
    void Draw();
    void MoveUp();
    void MoveLeft();
    void MoveRight();
    void MoveDown();
    void SendChar(Char c);
    void Delete();
    T SelectedItem { get; }
}