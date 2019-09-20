using System;
using System.Collections.Generic;

namespace 数据结构鱼算法
{
    class TestList
    {
        static void Main(string[] args)
        {
            // SeqList<int> lst1 = new SeqList<int>(10);
            // lst1.Append(1);
            // lst1.Append(12);
            // lst1.Append(123);
            // lst1.Append(1234);
            // lst1.Display();
            // //lst.Reverse();
            // //ReversSeqList(lst);
            // //ShowList(lst);
            // SeqList<int> lst2 = new SeqList<int>(34);
            // lst2.Append(2);
            // lst2.Append(20);

            // SeqList<int> lst3 = Merge(lst1, lst2);

            //ShowList(lst3);

            // LinkList<int> lst11 = new LinkList<int>();
            // lst11.Append(1);
            // lst11.Append(12);
            // lst11.Append(123);
            // lst11.Append(1234);

            // lst11.Reverse();

            // lst11.Display();

            // LinkList<int> lst22 = new LinkList<int>();
            // lst22.Append(0);
            // lst22.Append(10);
            // lst22.Append(10);
            // lst22.Append(100);
            // lst22.Append(1001);
            // lst22.Append(1001);
            // lst22.Append(100);

            // lst22.Delete(1);

            // lst22.Display();

            LinkListWithGuard<int> llwg = new LinkListWithGuard<int>();
            llwg.Append(1);
            llwg.Append(23);
            llwg.Append(34);
            llwg.Insert(100,2);
            // Console.WriteLine(llwg.Locate(100));
            llwg.Reverse();
            llwg.Display();

            // LinkList<int> lc = Purge(lst22);
            // ShowLinkList(lc);

            //ShowLinkList(lst);

            // DbLinkList<int> dbLinkList = new DbLinkList<int>();
            // dbLinkList.Append(123);
            // dbLinkList.Append(234);
            // dbLinkList.Append(4553);

            // dbLinkList.Display();
        }


        //将两个单链表进行混合得到总的单链表 O((m+n)*k)
        static LinkList<int> MergeLast(LinkList<int> la, LinkList<int> lb)
        {
            Node<int> p = la.Head;
            Node<int> q = lb.Head;

            LinkList<int> lc = new LinkList<int>();
            Node<int> s = new Node<int>();

            while (p != null && q != null)
            {
                if (p.Data < q.Data)
                {
                    s = p;
                    p = p.Next;
                }
                else
                {
                    s = q;
                    q = q.Next;
                }
                lc.Append(s.Data);
            }

            if (p == null)
            {
                p = q;
            }

            while (p != null)
            {
                s = p;
                p = p.Next;
                lc.Append(s.Data);
            }

            return lc;
        }

        //将两个单链表进行混合得到总的单链表 O((m+n)) 目前测试还有问题？
        static LinkList<int> MergeFirst(LinkList<int> la, LinkList<int> lb)
        {
            Node<int> p = la.Head;
            Node<int> q = lb.Head;

            LinkList<int> lc = new LinkList<int>();
            Node<int> s = new Node<int>();
            lc.Head = la.Head;
            lc.Head.Next = null;

            while (p != null && q != null)
            {
                if (p.Data < q.Data)
                {
                    s = p;
                    p = p.Next;
                }
                else
                {
                    s = q;
                    q = q.Next;
                }
                //lc.Append(s.Data);
                s.Next = lc.Head.Next;
                lc.Head.Next = s;
            }

            if (p == null)
            {
                p = q;
            }

            while (p != null)
            {
                s = p;
                p = p.Next;
                //lc.Append(s.Data);
                s.Next = lc.Head.Next;
                lc.Head.Next = s;
            }

            return lc;
        }

        //删除单链表中的相同元素组成新的单链表
        static LinkList<int> Purge(LinkList<int> la)
        {
            LinkList<int> lb = new LinkList<int>();
            Node<int> p = la.Head;
            Node<int> q = new Node<int>();
            Node<int> s = new Node<int>();

            s = p;
            p = p.Next;
            s.Next = null;
            lb.Head = s;
            while (p != null)
            {
                s = p;
                p = p.Next;
                q = lb.Head.Next;
                while (q != null && q.Data != s.Data)
                {
                    q = q.Next;
                }

                if (q == null)
                {

                    //头插法
                    // s.Next = lb.Head.Next;
                    // lb.Head.Next = s;

                    //尾插法 O(n)
                    lb.Append(s.Data);
                }
            }

            return lb;
        }

        //将两个有序表进行混合得到总的有序表
        static SeqList<int> Merge(SeqList<int> la, SeqList<int> lb)
        {
            SeqList<int> lc = new SeqList<int>(la.Maxsize + lb.Maxsize);
            int i = 0;
            int j = 0;
            while ((i <= (la.GetLength() - 1)) && (j <= (lb.GetLength() - 1)))
            {
                if (la[i] < lb[j])
                {
                    lc.Append(la[i++]);
                }
                else
                {
                    lc.Append(lb[j++]);
                }
            }

            while (i <= (la.GetLength() - 1))
            {
                lc.Append(la[i++]);
            }

            while (j <= (lb.GetLength() - 1))
            {
                lc.Append(lb[j++]);
            }

            return lc;
        }

        //选取顺序表中不相同的元素组成新的顺序表
        static SeqList<int> Purge(SeqList<int> la)
        {
            SeqList<int> lb = new SeqList<int>(la.Maxsize);
            lb.Append(la[0]);
            for (int i = 0; i <= la.GetLength() - 1; i++)
            {
                int j = 0;
                //查看b表中有无与a表中相同的数据元素 
                for (j = 0; j <= lb.GetLength() - 1; ++j)
                {
                    //有相同的数据元素 
                    if (la[i].CompareTo(lb[j]) == 0)
                    {
                        break;
                    }
                }
                //没有相同的数据元素，将a表中的数据元素附加到b表的末尾。 
                if (j > lb.GetLength() - 1)
                {
                    lb.Append(la[i]);
                }
            }
            return lb;
        }

    }
}
