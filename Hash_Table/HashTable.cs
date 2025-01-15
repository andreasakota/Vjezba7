using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    class HashTable
    {
        Node[] buckets;
        int length;
        public HashTable(int length)
        {
            this.length = length;
            buckets = new Node[length];
        }
        public void Display()
        {
            for (int bucket = 0; bucket < buckets.Length; bucket++)
            {
                Node current = buckets[bucket];
                Console.Write(bucket + ": ");
                while (current != null)
                {
                    Console.Write("[" + current.Name + "," + current.Value + "] ");
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }
        private int Hash(string str)
        {
            int total = 0;
            char[] c;
            c = str.ToCharArray();
            for (int k = 0; k <= c.GetUpperBound(0); k++)
                total += (int)c[k];

            return total % this.length;
        }


        public void Insert(string name, int value)
        {
            int bucket_index = Hash(name);
            buckets[bucket_index] = new Node(name, value, buckets[bucket_index]);
        }



        public int Search(string name)
        {
            Node current = buckets[Hash(name)];
            while (current != null)
            {
                if (current.Name.Equals(name))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            throw new Exception(name + " Not Found.");
        }




        public void Delete(string name)
        {
            int bucket = Hash(name);
            Node current = buckets[bucket];
            Node previous = null;
            while (current != null)
            {
                if (current.Name.Equals(name))
                {
                    if (previous == null)
                        buckets[bucket] = current.Next;
                    else
                        previous.Next = current.Next;
                    return;
                }
                previous = current;
                current = current.Next;
            }
            throw new Exception(name + " Not found.");
        }


    }
}
