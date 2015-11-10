using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingStudents
{
    class ArrayList<T>
    {
        private const int N = 1000;
        private T[] _data;
        private int _length;

        public ArrayList()
        {
            _data = new T[N];
            _length = -1;
        }

        public void Add(T value)
        {
            if (_length + 1 < N)
            {
                _data[++_length] = value;
            }
            else
            {
                throw new OverflowException();
            }
        }

        public T GetAt(int index)
        {
            if (isValidIndex(index))
            {
                return _data[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveAt(int index)
        {
            if (isValidIndex(index))
            {
                for (int i = index; i < _length; i++)
                {
                    _data[i] = _data[i + 1];
                }
                _length--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Sort()
        {
            Array.Sort(_data, 0, Length);
        }

        public T TakeAt(int index)
        {
            T value = GetAt(index);
            RemoveAt(index);
            return value;
        }

        public void Clear()
        {
            _length = -1;
        }

        public int Length
        {
            get
            {
                return _length + 1;
            }
        }

        public T this[int index]
        {
            get
            {
                return GetAt(index);
            }
        }


        private bool isValidIndex(int index)
        {
            return index <= _length && index >= 0;
        }


    }


    class Student : IComparable
    {
        private const int N = 4;
        private double _GPA;
        private string _name;
        private int[] _grades = new int[N];

        public Student(string name, int grade1, int grade2, int grade3, int grade4)
        {
            _name = name;
            _grades[0] = grade1;
            _grades[1] = grade2;
            _grades[2] = grade3;
            _grades[3] = grade4;
            _GPA = CalcGPA();
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public double GPA
        {
            get
            {
                return _GPA;
            }
        }

        private double CalcGPA()
        {
            double GPA = 0;
            for (int i = 0; i < N; i++)
            {
                GPA += _grades[i];
            }
            GPA /= N;
            return GPA;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Student otherStudent = obj as Student;
            //Student otherStudent = (Student) obj;
            if (otherStudent != null)
            {
                return this.GPA.CompareTo(otherStudent.GPA);
            }
            else
                throw new ArgumentException();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<Student> students = new ArrayList<Student>();
            students.Add(new Student("Vasya", 3, 4, 5, 4));
            students.Add(new Student("Petya", 5, 5, 5, 5));
            students.Add(new Student("Ivan", 4, 5, 4, 5));
            students.Sort();

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("Name: {0}, GPA: {1}", students[i].Name, students[i].GPA);
            }
            
            Console.ReadLine();

        }
    }
}
