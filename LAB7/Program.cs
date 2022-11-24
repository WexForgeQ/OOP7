using System;
using System.Collections.Generic;
namespace LAB7
{
    
    interface ICommon<T>
    {
        void Add(T item);
        void Delete(T item);
        void LookThrough();

    }
    class CollectionType<T>: ICommon<T>
    {
        Set<T> A = new Set<T>();
        public void Add(T item)
        {
            A.AddItemSet(item);
        }
        public void Delete(T item)
        {
            if(A.members.Contains(item))
            {
                A.members.Remove(item);
            }
            else
            {
                Console.WriteLine("Такого элемента нет в множестве");
            }
        }
        public void LookThrough()
        {
            A.DisplaySpis();
        }

        public class Set<T>
        {

            public List<T> members = new List<T>();
            public static int countofsets = 0;
            public int number = 0;
            public Set(List<T> items)
            {
                members = items;
                countofsets++;
                number = countofsets;
            }
            public Set()
            {
                countofsets++;
                number = countofsets;
            }
            public void AddItemSet(T item)
            {
                int i = 0;
                foreach (T mb in members)
                {
                    if (mb.Equals(item))
                    {
                        i++;
                    }
                }
                if (i >= 1)
                {
                    Console.WriteLine($"Такой элемент({item}) уже существует в множестве");
                }
                else
                {
                    members.Add(item);
                }

            }
            public static Set<T> operator +(Set<T> A, Set<T> B)
            {
                int s = 0;
                foreach (var item in B.members)
                {
                    foreach (T item2 in A.members)
                    {
                        if (item2.Equals(item))
                        {
                            s++;
                        }
                    }
                    if (s == 0)
                    {
                        A.members.Add(item);
                    }
                    s = 0;
                }
                return A;
            }

            public static T operator %(Set<T> A, int poz)
            {
                return A.members[poz];
            }

            public void DisplaySpis()
            {
                if (members.Count > 0)
                {
                    Console.WriteLine("Множество №" + number);
                    foreach (var item in members)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Множество №" + number + " пустое");
                }


            }
        }
    }
   

 class Program
 {
        static void Main(string[] args)
        {
            CollectionType<int> A = new CollectionType<int>();
            A.Add(1);
            A.Add(2);
            A.LookThrough();
            A.Delete(1);
            A.LookThrough();




        }

 }


}
