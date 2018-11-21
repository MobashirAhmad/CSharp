//A delegate is similar to a callback, a general term that captures constructs such as C function pointers.
//A delegate variable is assigned a method at runtime.This is useful for writing plug-in methods.
//Demo1  Basic delegate example
//Demo2 In this example, we have a utility method named Transform that applies a transform to each element in an integer array.The Transform method has a
//delegate parameter for specifying a plug-in transform.
//Demo3 Generic Delegate Types
#define Demo3 //Demo1 //Demo2
using System;
namespace DelegatesEvents
{

#if (Demo1)
    class Test
    {
        delegate int Transformer(int x); // declare delegate type
        static void Main(string[] args)
        {

            Transformer transform = Square; // Create delegate Instance using Shorthand 
                                            // Transformer transform = new Transformer(Square);  // Create delegate Instance 

            int result = transform(3);       // Invoke Delegate using Shorthand
                                             // int result = transform.Invoke(3); // Invoke Delegate

            transform += Que;
        }

        public static int Square(int x) => x * x; //Short way of writing below method

        public static int Que(int x) => x * x * x;

        //public static int Square(int x)
        //{
        //    int result = x * x;
        //    return result;
        //}
    }
#elif (Demo2)

    class Test
    {
        public delegate int Transformer(int i);
        public  static void Main(string[] args)
        {
            int [] intArray = { 1, 2, 3, 4 };
            //Transform(intArray, Square);
            Transform(intArray, Que);
            foreach (int i in intArray)
            {

                Console.Write(i + " ");
               
            }
            Console.ReadLine();

        }
        public static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }

        }

        public static int Square(int x) => x * x;
        public static int Que(int x) => x * x *x;
    }
#elif (Demo3)

    class Test
    {
        public delegate T Transformer <T>(T x);
        public  static void Main(string[] args)
        {
            double [] doubleArray = { 1, 2, 3, 4 };
            Transform(doubleArray, Square);
         
            foreach (int i in doubleArray)
            {

                Console.Write(i + " ");
               
            }
            Console.ReadLine();

        }
        public static void Transform(double[] values, Transformer<double> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }

        }

        public static double Square(double x) => x * x;
       
    }

#endif


}
