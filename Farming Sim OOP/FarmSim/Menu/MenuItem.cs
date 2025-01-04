//Denna klass är inspirerad av klassen MenuItem i Pokemon från lektion 1
public class MenuItem<T>
(
    string name, 
    T value
)
{
    public string Name { get; } = name;
    public T Value { get; } = value;
}