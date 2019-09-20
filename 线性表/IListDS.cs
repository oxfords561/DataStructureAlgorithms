
/**
线性表接口，定义线性表通用方法
 */
public interface IListDS<T>
{
    int GetLength();//求长度
    void Clear();//清空操作
    bool IsEmpty();//判断线性表是否为空
    void Append(T item);//附加操作
    void Insert(T item,int i);//插入操作
    T Delete(int i);//删除操作
    T GetElem(int i);//取表元
    int Locate(T value);//按值查找
    void Display();//展示表中的元素
    void Reverse();//线性表倒置
}