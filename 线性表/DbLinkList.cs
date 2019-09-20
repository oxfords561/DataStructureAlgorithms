
using System;

public class DbLinkList<T> : IListDS<T>
{

    private DbNode<T> head;//双向链表头引用
    public DbNode<T> Head
    {
        get
        {
            return head;
        }
        set
        {
            head = value;
        }
    }

    public DbLinkList()
    {
        head = null;
    }

    public void Append(T item)
    {
        DbNode<T> q = new DbNode<T>(item);
        DbNode<T> p = new DbNode<T>();

        //如果双向链表是空表
        if (head == null)
        {
            head = q;
            return;
        }

        //如果双向链表不为空，尾插法
        p = head;
        while (p.Next != null)
        {
            p = p.Next;
        }

        p.Next = q;
        q.Prev = p;
        q.Next = null;

    }

    public void Clear()
    {
        head = null;
    }

    public T Delete(int i)
    {
        if (IsEmpty() || i < 0)
        {
            Console.WriteLine("Link is empty or Position is error");
            return default(T);
        }

        DbNode<T> q = new DbNode<T>();
        if (i == 1)
        {
            q = head;
            head = head.Next;
            
            return q.Data;
        }

        return default(T);
    }

    public T GetElem(int i)
    {
        throw new System.NotImplementedException();
    }

    public int GetLength()
    {
        throw new System.NotImplementedException();
    }

    public void Insert(T item, int i)
    {
        throw new System.NotImplementedException();
    }

    public bool IsEmpty()
    {
        throw new System.NotImplementedException();
    }

    public int Locate(T value)
    {
        throw new System.NotImplementedException();
    }

    public void Reverse()
    {
        throw new System.NotImplementedException();
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        DbNode<T> p = head;
        while (p != null)
        {
            Console.WriteLine(p.Data);
            p = p.Next;
        }
    }
}