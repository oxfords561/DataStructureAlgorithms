
/**
双向链表的结点类
 */
public class DbNode<T>
{
    private T data;//数据域
    private DbNode<T> prev;//前驱引用域
    private DbNode<T> next;//后继应用域

    public DbNode(T val, DbNode<T> p)
    {
        this.data = val;
        this.next = p;
    }

    public DbNode(DbNode<T> p)
    {
        this.next = p;
    }

    public DbNode(T val)
    {
        data = val;
        next = null;
    }

    public DbNode()
    {
        data = default(T);
        next = null;
    }

    public T Data
    {
        get
        {
            return data;
        }

        set
        {
            data = value;
        }
    }

    public DbNode<T> Prev
    {
        get
        {
            return prev;
        }
        set
        {
            prev = value;
        }
    }

    public DbNode<T> Next
    {
        get
        {
            return next;
        }
        set
        {
            next = value;
        }
    }
}