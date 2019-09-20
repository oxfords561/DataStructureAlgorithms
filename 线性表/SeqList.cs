
using System;

/**
顺序表实现
 */
public class SeqList<T> : IListDS<T>
{
    private int maxsize;//顺序表的容量
    private T[] data;//数组，用于存储顺序表的数据元素
    private int last;//指示顺序表最后一个元素的位置

    //索引器
    public T this[int index]
    {
        get
        {
            return data[index];
        }
        set
        {
            data[index] = value;
        }
    }

    //最后一个数据元素位置属性
    public int Last
    {
        get
        {
            return last;
        }
    }

    //容量属性
    public int Maxsize
    {
        get
        {
            return maxsize;
        }
        set
        {
            maxsize = value;
        }
    }

    //构造器
    public SeqList(int size)
    {
        data = new T[size];
        maxsize = size;
        last = -1;
    }

    //在顺序表末尾添加新元素
    public void Append(T item)
    {
        if (IsFull())
        {
            Console.WriteLine("List is full");
            return;
        }
        data[++last] = item;
    }

    //清空顺序表
    public void Clear()
    {
        last = -1;
    }

    //删除顺序表的第i个数据元素
    public T Delete(int i)
    {
        T tmp = default(T);
        if (IsEmpty())
        {
            Console.WriteLine("List is empty");
            return tmp;
        }
        if (i < 1 || i > last + 1)
        {
            Console.WriteLine("Position is error");
            return tmp;
        }

        if (i == last + 1)
        {
            tmp = data[last--];
        }
        else
        {
            tmp = data[i - 1];
            for (int j = i; j <= last; ++j)
            {
                data[j] = data[j + 1];
            }
        }

        --last;
        return tmp;

    }

    //获取顺序表中第i个数据元素
    public T GetElem(int i)
    {
        if (IsEmpty() || (i < 1) || (i > last + 1))
        {
            Console.WriteLine("List is empty or Position is error!");
            return default(T);
        }
        return data[i - 1];
    }

    //求顺序表的长度
    public int GetLength()
    {
        return last + 1;
    }

    //在顺序表的第i个数据元素的位置插入一个数据元素     i 从1 开始
    public void Insert(T item, int i)
    {
        if (IsFull())
        {
            Console.WriteLine("List is full");
            return;
        }
        if (i < 1 || i > last + 2)
        {
            Console.WriteLine("Position is error!");
            return;
        }
        if (i == last + 2)
        {
            data[last + 1] = item;

        }
        else
        {
            for (int j = last; j >= i - 1; --j)
            {
                data[j + 1] = data[j];
            }
            data[i - 1] = item;
        }
        ++last;
    }


    //判断顺序表是否为空
    public bool IsEmpty()
    {
        if (last == -1) return true;
        return false;
    }

    //判断顺序表是否为满
    public bool IsFull()
    {
        if (last == maxsize - 1) return true;
        return false;
    }

    //在顺序表中查找值为value的数据元素
    public int Locate(T value)
    {
        if (IsEmpty())
        {
            Console.WriteLine("List is Empty");
            return -1;
        }

        int i = 0;
        for (i = 0; i <= last; i++)
        {
            if (value.Equals(data[i])) break;
        }

        if (i > last) return -1;

        return i;
    }

    //倒置
    public void Reverse()
    {
        T tmp = default(T);
        int len = GetLength();
        for (int i = 0; i < len / 2; ++i)
        {
            tmp = data[i];
            data[i] = data[len - 1 - i];
            data[len - 1 - i] = tmp;
        }
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("List is empty");
            return;
        }

        for (int i = 0; i < last + 1; i++)
        {
            Console.WriteLine(data[i]);
        }
    }
}