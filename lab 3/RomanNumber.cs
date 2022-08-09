using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class RomanNumber : ICloneable, IComparable
    {
        //Конструктор получает число n, которое должен представлять объект класса
        ushort value;
        public RomanNumber(ushort n)
        {
            if(n==0)
                throw new RomanNumberException();
            value = n;
        }
        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value + n2.value));
        }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            if (n2.value>=n1.value)
                throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value - n2.value));
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value * n2.value));
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            if (n2.value >= n1.value)
                throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value / n2.value));
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            ushort n = value;
            string result = "\n";
            List<int> dashPosition = new List<int>();
            for (int i=0; n>0;i++)
            {
                ushort remainder= (ushort)(n % 10);
                if(i>=3&&remainder!=0)
                {
                    result = result.Insert(1, stringConstructor(i, remainder,dashPosition));
                }
               else if (remainder != 0)
                {
                    result = result.Insert(1, stringConstructor(i, remainder));
                }
                n /= 10;
                if (n==0&&i>=3&&value>=4000)
                {
                    dashPosition.Sort();
                    int k = 0;
                    int l = result.Length-1;
                    for (int j = 0; j < l; j++)
                    {
                        if (j == dashPosition[k])
                        {
                            result = result.Insert(j, "_");
                            k++;
                        }
                        else
                            result = result.Insert(j, " ");
                        if (k == dashPosition.Count)
                            break;
                    }
                }
            }
            return result;
        }
        string stringConstructor(int discharge, ushort remainder, List<int> dashPosition=null)
        {
            string A, B, C;
            switch (discharge)
            {
                case 0:
                    A = "I";
                    B = "V";
                    C = "X";
                    break;
                case 1:
                    A = "X";
                    B = "L";
                    C = "C";
                    break;
                case 2:
                    A = "C";
                    B = "D";
                    C = "M";
                    break;
                case 3:
                    A = "M";
                    B = "V";
                    C = "X";
                    if(remainder==4|| remainder==9)
                    {
                        dashPosition.Add(1);
                    }
                    else if(remainder>4&& remainder<9)
                    {
                        dashPosition.Add(0);
                    }
                    break;
                case 4:
                    A = "X";
                    B = "L";
                    C = "";
                    break;
                default:
                    throw new RomanNumberException();
            }
            string result="";
            switch(remainder)
            {
                case 1:
                    result = string.Format("{0}", A);
                    break;
                case 2:
                    result = string.Format("{0}{0}", A);
                    break;
                case 3:
                    result = string.Format("{0}{0}{0}", A);
                    break;
                case 4:
                    result = string.Format("{0}{1}", A,B);
                    break;
                case 5:
                    result = string.Format("{0}", B);
                    break;
                case 6:
                    result = string.Format("{1}{0}",A,B );
                    break;
                case 7:
                    result = string.Format("{1}{0}{0}", A, B);
                    break;
                case 8:
                    result = string.Format("{1}{0}{0}{0}", A, B);
                    break;
                case 9:
                    result = string.Format("{0}{1}",  A,C);
                    break;
            }
            if(discharge == 4)
            {
                if (dashPosition.Count != 0)
                    dashPosition[0] += result.Length;

                switch(remainder)
                {
                    case 1:
                        
                            dashPosition.Add(0);
                        break;
                    case 2:
                        
                            dashPosition.Add(0);
                            dashPosition.Add(1);
                        
                        break;
                    case 3:
                       
                            dashPosition.Add(0);
                            dashPosition.Add(1);
                            dashPosition.Add(2);
                        
                        break;
                    case 4:
                        
                            dashPosition.Add(0);
                            dashPosition.Add(1);
                        
                        break;
                    case 5:
                        
                            dashPosition.Add(0);
                        
                        break;
                    case 6:
                      
                            dashPosition.Add(0);
                            dashPosition.Add(1);
                        
                        break;
                }
            }
            return result;
        }
        //Реализация интерфейса IClonable
        public object Clone()
        {
            return new RomanNumber(value);
        }
        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if(!(obj is RomanNumber))
                throw new RomanNumberException();
            var number = (RomanNumber)obj;
            return value.CompareTo(number.value);
        }
    }

}
