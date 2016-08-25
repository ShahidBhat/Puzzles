using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Practice
{
    class Constructors
    {
        private int a1, b1;
        public Constructors()
        { 
        }
        public Constructors(int a, int b)
        {
            a1 = a;
            b1 = b;
        }
    }
    class Demo
    {
        public static void Main(string[] args)
        {
            Constructors c1 = new Constructors();
        }
    }
}
