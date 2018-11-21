//A delegate is similar to a callback, a general term that captures constructs such as C function pointers.
//A delegate variable is assigned a method at runtime.This is useful for writing plug-in methods.
//Demo1  Basic delegate example
//Demo2 In this example, we have a utility method named Transform that applies a transform to each element in an integer array.The Transform method has a
//delegate parameter for specifying a plug-in transform.
//Demo3 Generic Delegate Types
//Demo4 Implementing the Transform using Func
//Demo5 Delegate types are all incompatible with one another, even if their signatures are the same:
#define Demo7 //Demo1 //Demo2 //Demo3//Demo4//Demo5//Demo6
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
            int [] doubleArray = { 1, 2, 3, 4 };
            Transform(doubleArray, Square);
         
            foreach (int i in doubleArray)
            {

                Console.Write(i + " ");
               
            }
            Console.ReadLine();

        }
        public static void Transform<T>(T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }

        }

        public static int Square(int x) => x * x;
       
    }

#elif (Demo4)

    class Test
    {
      
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
        public static void Transform<T>(T[] values,Func<T,T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = transformer(values[i]);
            }

        }

        public static double Square(double x) => x * x;
       
    }

#elif (Demo5)

    class Test
    {
        //Delegate types are all incompatible with one another, even if their signatures are the same:
        public delegate void Del1(int x);
        public delegate void Del2(int x);
        public  static void Main(string[] args)
        {
            Del1 d1 = Add;
          //  Del2 d2 = d1; //Not Permitted
            Del2 d2 = new Del2(d1); //Permitted
          //  Delegate instances are considered equal if they have the same type and method target(s).For multicast delegates, the order of
          //the method targets is significant.
        }
        public static void Add(int a) => a += a;
       
    }

#elif (Demo6)
    //   Return type variance
    //When you call a method, you may get back a type that is more
    //specific than what you asked for. This is ordinary polymorphic
    //behavior.In keeping with this, a delegate target method may
    //return a more specific type than described by the delegate
    class Test
    {
        delegate object ObjectRetriever();
        public  static void Main(string[] args)
        {
            ObjectRetriever o = new ObjectRetriever(GetString);
            object result = o();
            Console.WriteLine(result);
            Console.ReadLine();

            //The ObjectRetriever expects to get back an object; rather,it isan object subclass will also do because delegate return types are
            //covariant
        }
        public static string GetString() => "Hello World";
       
    }

#elif (Demo7)
    //   Parameter variance
//    When you call a method, you can supply arguments that have
//more specific types than the parameters of that method.This is
//ordinary polymorphic behavior.In keeping with this, a delegate
//target method may have less specific parameter types than
//described by the delegate. This is called contravariance:
    class Test
    {
        delegate void StringAction(string s);
        public  static void Main(string[] args)
        {
            StringAction sa = new StringAction(ActOnObject);
            sa("Hello");
            Console.ReadLine();
                      
        }
        static void ActOnObject(object o) => Console.Write(o);
//NOte: The standard event pattern is designed to help you leverage
//delegate parameter contravariance through its use of the
//common EventArgs base class. For example, you can have
//a single method invoked by two different delegates, one
//passing a MouseEventArgs and the other passing a
//KeyEventArgs.
    }

    

#endif


}
