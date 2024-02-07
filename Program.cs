class Program
{

    static void Main(string[] args)
    {
        int[] a = [1, 5, 6, 4, 8];

        unsafe
        {
        };
        // int n, i;
        // System.Console.WriteLine("Enter size of array");
        // array.Size = int.Parse(Console.ReadLine());

        unsafe
        {
            Array array = new() { Length = 16, Size = 20 };
            array.A = new int*[20];
            Array arrayB = new() { Length = 20, Size = 20 };
            arrayB.A = new int*[20];
            //     array.Length = 0;
            //     System.Console.WriteLine("Enter the num of numbers");
            //     n = int.Parse(Console.ReadLine());
            //     array.A = new int*[n];
            //     System.Console.WriteLine("Enter all elements");
            //     for (i = 0; i < n; i++)
            //     {
            //         array.A[i] = (int*)int.Parse(Console.ReadLine());
            //     }
            //     array.Length = n;
            // }
            // array.Append(ref array, 10);
            array.PopulateArr(&array);
            array.PopulateArr(&arrayB);
            // System.Console.WriteLine(array.DELETE(2));
            // System.Console.WriteLine(array.LinearSearch(3));
            // System.Console.WriteLine(array.LinearSearchTransposition(3));
            //here a good approach for dealing with search.
            // System.Console.WriteLine(array.LinearSearchMoveToHead(3));
            //those 2 is very interesting how they works
            // System.Console.WriteLine(array.BinarySearchLoop(15));
            // System.Console.WriteLine(array.BinarySearchRecursive(0, array.Size, 15));
            // array.INSERT(0, 10);

            // System.Console.WriteLine("set");
            // array.Set(10, 5552);
            // System.Console.Write("get ");
            // System.Console.WriteLine(array.Get(10));
            // System.Console.WriteLine("Max ");
            // System.Console.WriteLine(array.Max());
            // System.Console.WriteLine("Min ");
            // System.Console.WriteLine(array.Min());
            // System.Console.WriteLine("Average ");
            // System.Console.WriteLine(array.Avg());




            // System.Console.WriteLine("Set will be printed");

            // int u = array.DELETE(ref array, 10);
            // array.Display();
            // System.Console.WriteLine();
            // //this insert works in case the input bigger than the elements inside.
            array.InsertOnSorted(&array, 15);
            array.InsertOnSorted(&array, 33);
            array.InsertOnSorted(&array, 55);
            // array.InsertOnSorted(&array, -55);
            // array.Set(6, -5552);
            // array.Set(8, 50);
            // array.Set(11, -33);
            // //this boy check id the array is sorted
            // System.Console.WriteLine(array.CheckIfIsSorted(ref array));
            // array.Rearrange(ref array);
            // array.Display();

            //you should use parameter to pass the third array, but i will use for time save
            System.Console.WriteLine(array.A.Length);
            Array arrayC = new()
            {
                A = new int*[array.Length + arrayB.A.Length]
            };
            // array.Merge(ref array, ref arrayB, ref arrayC);
            // array.Union(ref array, ref arrayB, ref arrayC);
            array.Intersection(ref array, ref arrayB, ref arrayC);
            array.Display(ref arrayC);
        }


    }
}