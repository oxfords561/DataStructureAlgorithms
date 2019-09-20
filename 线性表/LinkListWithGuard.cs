
using System;

/**
带哨兵的单链表
 */
public class LinkListWithGuard<T> : IListDS<T>
{
    private Node<T> head;//单链表的哨兵
    private Node<T> First => Head.Next;//单链表的头结点
    public Node<T> Head
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

    public LinkListWithGuard()
    {
        head = new Node<T>(default(T));
    }

    //默认尾插法进行添加元素
    public void Append(T item)
    {
        Node<T> q = new Node<T>(item);
        Node<T> p = new Node<T>();

        //如果单链表不为空 则尾插法
        p = head;
        while (p.Next != null)
        {
            p = p.Next;
        }

        p.Next = q;
    }

    //清空单链表
    public void Clear()
    {
        head = null;
    }

    //删除单链表的第i个结点
    public T Delete(int i)
    {
        if (IsEmpty() || i < 0)
        {
            Console.WriteLine("Link is empty or Position is error");
            return default(T);
        }

        //删除的是头结点，只需要将头结点指向后继
        Node<T> q = new Node<T>();

        Node<T> p = head;
        int j = 1;
        while (p.Next != null && j < i)
        {
            j++;
            q = p;
            p = p.Next;
        }

        if (j == i)
        {
            q.Next = p.Next;
            return p.Data;
        }
        else
        {
            Console.WriteLine("the ith node is not exist");
            return default(T);
        }
    }

    //获取单链表的第i个数据元素 i 从1开始
    public T GetElem(int i)
    {
        if (IsEmpty())
        {
            Console.WriteLine("list is empty");
            return default(T);
        }

        Node<T> p = new Node<T>();
        p = head;
        int j = 1;
        while (p.Next != null && j < i)
        {
            j++;
            p = p.Next;
        }

        if (j == i)
        {
            return p.Data;
        }
        else
        {
            Console.WriteLine(" the ith node is not exist");
            return default(T);
        }
    }

    //求单链表的长度
    public int GetLength()
    {
        Node<T> p = head;
        int len = 0;
        while (p != null)
        {
            p = p.Next;
            len++;
        }
        return len;
    }

    //在单链表的第i个结点的位置前插入一个值为item的结点
    public void Insert(T item, int i)
    {
        //异常情况，插入的位置未知或者空表
        if (IsEmpty() || i < 1)
        {
            Console.WriteLine("List is empty or Position is error");
            return;
        }

        Node<T> p = First;
        Node<T> r = new Node<T>();
        int j = 1;
        while (p.Next != null && j < i)
        {
            r = p;
            p = p.Next;
            j++;
        }

        if (j == i)
        {
            Node<T> q = new Node<T>(item);
            q.Next = p;
            r.Next = q;
        }
    }

    //在单链表的第i个结点的位置后插入一个值为item的结点
    public void InsertPost(T item, int i)
    {
        if (IsEmpty() || i < 1)
        {
            Console.WriteLine("List is empty or Position is error!");
            return;
        }

        Node<T> p = First;
        int j = 1;
        while (p != null && j < i)
        {
            p = p.Next;
            ++j;
        }
        if (j == i)
        {
            Node<T> q = new Node<T>(item);
            q.Next = p.Next;
            p.Next = q;
        }
    }

    //判断单链表是否为空
    public bool IsEmpty()
    {
        if (First == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //在单链表中找寻值为value的结点
    public int Locate(T value)
    {
        if (IsEmpty())
        {
            Console.WriteLine("List is Empty!");
            return -1;
        }
        Node<T> p = new Node<T>();
        p = First;
        int i = 1;
        while (!p.Data.Equals(value) && p.Next != null)
        {
            p = p.Next;
            ++i;
        }
        return i;
    }

    public void Display()
    {

        Node<T> p = First;
        while (p!= null)
        {
            Console.WriteLine(p.Data);
            p = p.Next;
        }
    }


    //将单链表进行倒置
    public void Reverse()
    {
        if (IsEmpty())
        {
            Console.WriteLine("List is Empty!");
            return;
        }

        Node<T> p = new Node<T>();
        Node<T> q = new Node<T>();
        Node<T> temp = null;
        p = First;//p 指向第一个结点

        while (p!= null)
        {
            q = p;
            p = p.Next;
            q.Next = temp;
            temp = q;
        }

        if(p == null){
            head.Next = temp;
        }
    }
}