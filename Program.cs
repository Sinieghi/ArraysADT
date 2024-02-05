class Program
{

    static void Main(string[] args)
    {
        int[] a = [1, 5, 6, 4, 8];
        Array array = new() { Length = 20, Size = 20 };
        unsafe
        {
        };
        // int n, i;
        // System.Console.WriteLine("Enter size of array");
        // array.Size = int.Parse(Console.ReadLine());

        unsafe
        {
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
            // System.Console.WriteLine(array.DELETE(2));
            // System.Console.WriteLine(array.LinearSearch(3));
            // System.Console.WriteLine(array.LinearSearchTransposition(3));
            //here a good approach for dealing with search.
            // System.Console.WriteLine(array.LinearSearchMoveToHead(3));
            //those 2 is very interesting how they works
            System.Console.WriteLine(array.BinarySearchLoop(15));
            System.Console.WriteLine(array.BinarySearchRecursive(0, array.Size, 15));
            // array.INSERT(0, 10);
            array.Display();
        }


    }
}