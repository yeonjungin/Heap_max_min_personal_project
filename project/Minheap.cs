using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public class Minheap
    {
        public static List<int> node = new List<int>();
        public static int size = 0;
        public static int i = 0;

        public static bool isEmpty()
        {
            return size == 0;
        }
        public static int GetParent(int x)
        {
            int i = x / 2;
            return node[i];
        }
        public static int GetLeft(int i)
        {
            int a = i * 2;
            return node[a];
        }
        public static int GetRight(int i)
        {
            int a = i * 2 + 1;
            return node[a];
        }
        public static void insert(int key, bool first)
        {
            if (first)
            {
                node.Add(key);
                return;
            }
            i = ++size;
            node.Add(key);

            while (i != 1 && key< GetParent(i))
            {
                node[i] = GetParent(i);
                MessageBox.Show("parent : " + node[i] + " <--> " + "child : " + key + "의 위치가 변한다.");
                i /= 2;
            }
            node[i] = key;
        }
        public static void remove()
        {
            if (isEmpty())
            {
                return;
            }
            int item = node[1];
            int last = node[size--];
            node.RemoveAt(size + 1);

            int parent = 1;
            int child = 2;
            while (child <= size)
            {
                if (child < size && GetLeft(parent) > GetRight(parent))
                {
                    child++;
                }
                if (last <= node[child]) break;
                node[parent] = node[child];
                parent = child;
                child *= 2;
            }
            if (size > 0)
            {
                node[parent] = last;
            }
        }
    }
}
