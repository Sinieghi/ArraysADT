unsafe struct Array
{
    //this is one of the most important topic here
    //i'm using pointers but just ignore. All the methods of an array
    //is here.

    public int*[] A { get; set; }

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

    public int DELETE(ref Array array, int index)
    {
        //min O(1)
        //max O(n)
        if (index > array.Length) return -1;
        int x;
        int i;
        x = (int)array.A[index];
        for (i = index; i < array.Length - 1; i++)
        {
            array.A[i] = array.A[i + 1];
        }
        array.Length--;
        return x;
    }

    public void ADD(int x)
    {
        //O(1)
        if (Length >= Size) return;
        A[Length] = &x;
        Length++;
    }

    public void Display(ref Array array)
    {
        int i;
        for (i = 0; i < array.Length; i++)
        {
            System.Console.Write((int)array.A[i]);
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

    public int Get(int index)
    {
        if (index > A.Length) return -1;
        return (int)A[index];
    }
    public void Set(int index, int x)
    {
        if (index < 0 || index > A.Length) return;
        A[index] = (int*)x;
    }
    public int Sum()
    {
        int total = 0;
        for (int i = 0; i < A.Length; i++)
        {
            total += (int)A[i];
        }

        return total;
    }
    public float Avg()
    {
        return (float)Sum() / A.Length;
    }
    public int Max()
    {
        int max = (int)A[0];
        int i;
        for (i = 0; i < A.Length; i++)
        {
            if (max < (int)A[i]) max = (int)A[i];
        }
        return max;
    }

    public int Min()
    {
        int min = (int)A[0];
        int i;
        for (i = 0; i < A.Length; i++)
        {
            if (min > (int)A[i]) min = (int)A[i];
        }
        return min;
    }
    public readonly void Reverse(ref Array array)
    {
        int j, i;
        for (i = 0, j = A.Length - 1; j > i; i++, j--)
        {
            // temp = (int)array.A[i];
            // array.A[i] = array.A[j];
            // array.A[j] = (int*)temp;

            Swap(ref array.A[i], ref array.A[j]);
        }
    }

    public void Rotate(ref Array array)
    {
        int j = array.Length - 1, i = 0, temp;
        // temp = (int)array.A[i];
        // array.A[i] = array.A[j];
        // array.A[j] = (int*)temp;

        Swap(ref array.A[i], ref array.A[j]);
    }

    public void Shift(ref Array array)
    {


        int i;
        for (i = 0; i < array.Length - 1; i++)
        {
            array.A[i] = array.A[i + 1];
        }
        array.Length--;



    }

    public void InsertOnSorted(Array* array, int x)
    {

        if (array->Length == array->Size) return;
        int i = array->Length - 1;
        while (i >= 0 && (int)array->A[i] > x)
        {
            array->A[i + 1] = array->A[i];
            i--;
        }
        array->A[i + 1] = (int*)x;
        array->Length++;
    }

    public bool CheckIfIsSorted(ref Array array)
    {
        //O(n)
        for (int i = 0; i < array.Length - 1; i++)
        {
            if ((int)array.A[i] > (int)array.A[i + 1])
                return false;
        }
        return true;
    }

    public void Rearrange(ref Array array)
    {
        //O(n)
        int i = 0, j = A.Length - 1;
        while (i < j)
        {
            while ((int)array.A[i] < 0)
            {
                i++;
            }
            while ((int)array.A[j] >= 0)
            {
                j--;
            }
            if (i < j)
                Swap(ref array.A[i], ref array.A[j]);
        }
    }

    public void Merge(ref Array arrayA, ref Array arrayB, ref Array arrayC)
    {
        // 0 = teta
        // 0(n + m)
        int m = arrayA.A.Length;
        int n = arrayB.A.Length;
        int i = 0, j = 0, k = 0;
        while (i < m && j < n)
        {
            if (arrayA.A[i] < arrayB.A[j])
                arrayC.A[k++] = arrayA.A[i++];
            else
                arrayC.A[k++] = arrayB.A[j++];
        }
        //append remaining elements, always 1 will be left 
        for (; i < n; i++)
            arrayC.A[k++] = arrayA.A[i];
        for (; i < m; i++)
            arrayC.A[k++] = arrayB.A[i];

        arrayC.Length = arrayA.Length + arrayB.Length;
        arrayC.Size = arrayA.Size + arrayB.Size;


    }

    public void Union(ref Array arrayA, ref Array arrayB, ref Array arrayC)
    {
        // 0 = teta
        // 0(n + m)
        int m = arrayA.A.Length;
        int n = arrayB.A.Length;
        int i = 0, j = 0, k = 0;
        while (i < m && j < n)
        {
            if (arrayA.A[i] < arrayB.A[j])
                arrayC.A[k++] = arrayA.A[i++];
            else if (arrayB.A[j] < arrayA.A[i])
                arrayC.A[k++] = arrayB.A[j++];
            else
            {
                arrayC.A[k++] = arrayA.A[i++];
                j++;
            }
        }
        //append remaining elements, always 1 will be left 
        for (; i < n; i++)
            arrayC.A[k++] = arrayA.A[i];
        for (; i < m; i++)
            arrayC.A[k++] = arrayB.A[i];

        arrayC.Length = k;
        arrayC.Size = arrayA.Size + arrayB.Size;
    }

    public void Intersection(ref Array arrayA, ref Array arrayB, ref Array arrayC)
    {
        // 0 = teta
        // 0(n + m)
        int m = arrayA.A.Length;
        int n = arrayB.A.Length;
        int i = 0, j = 0, k = 0;
        while (i < m && j < n)
        {
            if (arrayA.A[i] < arrayB.A[j])
                i++;
            else if (arrayB.A[j] < arrayA.A[i])
                j++;
            else if (arrayA.A[i] == arrayB.A[j])
            {
                arrayC.A[k++] = arrayA.A[i++];
                j++;
            }
        }
        arrayC.Length = k;
        arrayC.Size = arrayA.Size + arrayB.Size;
    }


    public void Difference(ref Array arrayA, ref Array arrayB, ref Array arrayC)
    {
        // 0 = teta
        // 0(n + m)
        int m = arrayA.A.Length;
        int n = arrayB.A.Length;
        int i = 0, j = 0, k = 0;
        while (i < m && j < n)
        {
            if (arrayA.A[i] < arrayB.A[j])
                arrayC.A[k++] = arrayA.A[i++];
            else if (arrayB.A[j] < arrayA.A[i])
                j++;
            else
            {
                i++;
                j++;
            }
        }
        //append remaining elements, always 1 will be left 
        for (; i < n; i++)
            arrayC.A[k++] = arrayA.A[i];

        arrayC.Length = k;
        arrayC.Size = arrayA.Size + arrayB.Size;
    }

    //    A - B
    public void DifferenceUnsorted(ref Array arrayA, ref Array arrayB, ref Array arrayC)
    {
        // 0 = teta
        // 0(n + m)
        int m = arrayA.Length;
        int n = arrayB.A.Length;
        arrayC.Length = arrayA.A.Length + arrayB.A.Length;
        int i, j, k = 0;
        for (i = 0; i < n; i++)
        {
            bool isThere = false;
            for (j = 0; j < m; j++)
            {
                if (arrayA.A[i] == arrayB.A[j])
                {
                    isThere = true;
                    break;
                }
            }
            if (!isThere) arrayC.A[k++] = arrayA.A[i];
        }

        arrayC.Length = k;
        arrayC.Size = arrayA.Size + arrayB.Size;
    }

    public void IntersectionUnsortedList(ref Array arrayA, ref Array arrayB, ref Array arrayC)
    {
        // 0 = teta
        // 0(n + m)
        int m = arrayA.Length;
        int n = arrayB.A.Length;
        arrayC.Length = arrayA.A.Length + arrayB.A.Length;
        int i, j, k = 0;
        for (i = 0; i < n; i++)
        {
            bool isThere = false;
            for (j = 0; j < m; j++)
            {
                if (arrayA.A[i] == arrayB.A[j])
                {
                    isThere = true;
                    break;
                }
            }
            if (isThere) arrayC.A[k++] = arrayA.A[i];
        }

        arrayC.Length = k;
        arrayC.Size = arrayA.Size + arrayB.Size;
    }

    public void UnionUnsorted(ref Array arrayA, ref Array arrayB, ref Array arrayC)
    {
        // 0 = teta
        // 0(n + m)
        int m = arrayA.Length;
        int n = arrayB.A.Length;
        arrayC.Length = arrayA.A.Length + arrayB.A.Length;
        int i, j, k = 0;
        for (i = 0; i < n; i++)
        {
            arrayC.A[k++] = arrayA.A[i];
        }
        for (i = 0; i < m; i++)
        {
            bool isThere = false;
            for (j = 0; j < arrayC.A.Length; j++)
            {
                if (arrayB.A[i] == arrayB.A[j])
                {
                    isThere = true;
                    break;
                }
            }
            if (!isThere) arrayC.A[k++] = arrayA.A[i];
        }

        arrayC.Length = k;
        arrayC.Size = arrayA.Size + arrayB.Size;
    }




}