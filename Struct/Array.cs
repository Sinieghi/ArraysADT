unsafe struct Array
{
    //this is one of the most important topic here
    //i'm using pointers but just ignore. All the methods of an array
    //is here.

    public int*[] A { get; set; } = new int*[20];

    public Array()
    {
    }

    public int Size { get; set; }
    public int Length { get; set; }

    public void PopulateArr(Array* arr)
    {
        for (int i = 0; i < arr->Length; i++)
        {
            arr->A[i] = (int*)i;
        }
    }

    public void INSERT(int index, int x)
    {
        //min O(1)
        //max O(n)
        if (index > Size) return;
        int i;
        for (i = Length; i > index; i--)
        {
            A[i] = A[i - 1];
        }
        A[index] = (int*)x;
        Length++;
    }

    public int DELETE(int index)
    {
        //min O(1)
        //max O(n)
        if (index > Length) return -1;
        int x;
        int i;
        x = (int)A[index];
        for (i = index; i < Length - 1; i++)
        {
            A[i] = A[i + 1];
        }
        Length--;
        return x;
    }

    public void ADD(int x)
    {
        //O(1)
        if (Length >= Size) return;
        A[Length] = &x;
        Length++;
    }

    public void Display()
    {
        int i;
        for (i = 0; i < Length; i++)
        {
            System.Console.Write((int)A[i]);
            System.Console.Write(" ");
        }
    }

    // unsafe public delegate*<Array, int, void> Append;
    //Append is same as add
    unsafe public void Append(ref Array array, int x)
    {
        if (array.Length > array.Size) return;
        array.A[array.Length++] = (int*)x;
    }




    public int LinearSearch(int key)
    {
        int i;
        for (i = 0; i < Length; i++)
        {
            if (key == (int)A[i])
                return i;
        }
        return -1;
    }
    public int LinearSearchTransposition(int key)
    {
        int i;
        for (i = 0; i < Length; i++)
        {
            if (key == (int)A[i])
            {
                Swap(ref A[i], ref A[i - 1]);
                return i - 1;
            }
        }
        return -1;
    }

    public readonly int LinearSearchMoveToHead(int key)
    {
        int i;
        for (i = 0; i < Length; i++)
        {
            if (key == (int)A[i])
            {
                Swap(ref A[i], ref A[0]);
                return 0;
            }
        }
        return -1;
    }

    public static void Swap(ref int* x, ref int* y)
    {
        try
        {
            System.Console.WriteLine((int)x);
            System.Console.WriteLine((int)y);
            int temp;
            temp = (int)x;
            x = y;
            y = (int*)temp;


        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e);
        }
    }

    public int BinarySearchLoop(int key)
    {
        int l = 0, h = A.Length;
        //mid = floorOf (l + h) / 2
        while (l <= h)
        {

            int mid = (l + h) / 2;
            if (key == (int)A[mid]) return mid;
            else if (key < (int)A[mid]) h = mid + 1;
            else l = mid + 1;

        }
        return -1;
    }
    public int BinarySearchRecursive(int l, int h, int key)
    {
        if (l > h) return -1;
        int mid = (l + h) / 2;
        if (key == (int)A[mid]) return mid;
        else if (key < (int)A[mid]) return BinarySearchRecursive(l, mid - 1, key);
        else
            return BinarySearchRecursive(mid + 1, h, key);
    }
}