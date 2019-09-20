
/**
链表节点类
 */
public class Node<T>
{
    private T data;//数据域
    private Node<T> next;//引用域
    public Node(T data, Node<T> next)
    {
        this.data = data;
        this.next = next;
    }

    public Node(Node<T> p)
    {
        this.next = p;
    }

    public Node(T data)
    {
        this.data = data;
        this.next = null;
    }

    public Node() : this(default(T), null)
    {

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

    public Node<T> Next
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