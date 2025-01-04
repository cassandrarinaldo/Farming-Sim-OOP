using System.Collections;

public class Row<T> : IEnumerable<T>
{
    public int index { get; set; }
    public T item1
    { 
        get => _row[0]; 
        set { _row[0] = value; UpdateRowArray();} 
    }
    public T item2
    { 
        get => _row[1]; 
        set { _row[1] = value; UpdateRowArray();} 
    }
    public T item3
    { 
        get => _row[2]; 
        set { _row[2] = value; UpdateRowArray();} 
    }
    public T[] _row;
    public Row (T[] rowArray)
    {
        _row = new T[rowArray.Length];
        for(int i = 0; i < rowArray.Length; i++)
            _row[i] = rowArray[i];
    }
    public Row(T item, int index)
    {
        this.index = index;
        _row = [item, item, item];
    }
    public Row(T t1, T t2, T t3, int index)
    {
        this.index = index;
        _row = [t1, t2, t3];
    }
    public string Info() => "ROW " + (index + 1);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<T> GetEnumerator() => new RowEnum<T>(this);
    public void UpdateRowArray()
    {
        _row[0] = item1;
        _row[1] = item2;
        _row[2] = item3;
    }
}