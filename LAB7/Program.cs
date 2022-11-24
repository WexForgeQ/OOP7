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
        public Set<T> A = new Set<T>();
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
                if (members is List<bool>)
                    throw new Exception("Данный тип недопустим в множестве");

                members = items;
                countofsets++;
                number = countofsets;
            }
            public Set()
            {
                if(members is List<bool>)
                    throw new Exception("Данный тип недопустим в множестве");
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
    public class Question
    {
        public string question;

        public string Quest
        {
            get
            {
                return question;
            }
            set
            {
                if (value == null)
                    throw new Exception("Вопрос не может быть пустым");
                else if (!value.Contains('?'))
                    throw new Exception("В вопросе отсутствует символ <?>");
                else
                    question = value;
            }
        }

        public Question()
        {
            question = "Default";
        }

        public Question(string que)
        {
            question = que;
        }
        public void DisplayQuestion()
        {
            Console.WriteLine("Вопрос: " + question);
        }
        public override string ToString()
        {
            return "Тип объекта:" + GetType() + " Вопрос:" + question;
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
            try
            {
                CollectionType<bool> B = new CollectionType<bool>();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Проверка закончена");
            }
            CollectionType<string> C = new CollectionType<string>();
            Question Q = new Question();
            CollectionType<Question> Qtype = new CollectionType<Question>();
            Qtype.Add(Q);
            Qtype.LookThrough();
        }

 }


}
