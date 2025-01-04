using System.Collections;
public class RowEnum<T> : IEnumerator<T>
{
    private readonly Row<T> _row;
    private int position = -1;
    private bool disposed = false;
    public RowEnum(Row<T> row) => _row = row;
    public bool MoveNext()
    {
        position++;
        return position < _row._row.Length;
    }
    public void Reset()
    {
        if (disposed)
            throw new ObjectDisposedException("RowEnum");
        position = -1;
    }
    public T Current =>_row._row[position];
    object IEnumerator.Current => Current;
    public void Dispose() { }
}