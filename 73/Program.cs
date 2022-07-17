Console.Write("Введите число от 1 до N: ");
long number = long.Parse(Console.ReadLine());
long[] array = new long[number];
FillArray(array);
Console.WriteLine($"Количество чисел для группировки: {number}");
TestPrintArray(array, number);
Console.WriteLine();
long arrayValuesZeroingCounter = 1;
int groupNumber = 1;
Console.WriteLine($"Группа {groupNumber}: {array[0]}");
array[0] = 0;

while(arrayValuesZeroingCounter < number)   //   1
{
    Console.WriteLine($"TEST 1");
    long[] group = new long[number];
    long lastCellGroupIndex = 2;
    long FirstIndexGroupValueSearchRelay = 0;
    for(long ind = 0; array[FirstIndexGroupValueSearchRelay] == 0 && ind < number; ind++)  //  2
    {
        Console.WriteLine($"TEST 2");
        FirstIndexGroupValueSearchRelay = ind + 1;
    }
    //FirstIndexGroupValueSearchRelay++;
    group[0] = array[FirstIndexGroupValueSearchRelay];
    for(long i = 0; i < number; i++)  //  3
    {
        Console.WriteLine($"TEST 3");
        long groupIndex = 0;
        if(array[i] != 0)
        {
            Console.WriteLine($"TEST 3 1");
            while(groupIndex < lastCellGroupIndex)  //  4
            {
                Console.WriteLine($"TEST 4");
                if(array[i] % group[groupIndex] != 0)
                {
                    Console.WriteLine($"TEST 4 1 YES");
                    if(groupIndex == lastCellGroupIndex - 1)
                    {
                        Console.WriteLine($"TEST 4 2");
                        group[groupIndex] = array[i];
                        lastCellGroupIndex++;
                        array[i] = 0;
                        arrayValuesZeroingCounter++;
                    }
                }
                else
                {
                    Console.WriteLine($"TEST 4 1 NO");
                    break;
                }
                groupIndex++;
            }
        }
    }
    groupNumber++;
    Console.Write($"Группа {groupNumber}: ");
    PrintGroup(group, lastCellGroupIndex);
    Console.WriteLine($"Test LCGI {lastCellGroupIndex}, AVZC {arrayValuesZeroingCounter}");
    Console.WriteLine();
}


void FillArray(long[] a)
{
    long n = 1;
    for(long i = 0; i < a.Length; i++)
    {
        a[i] = n;
        n++;
    }
}

void PrintGroup(long[] a, long b)
{
    Console.Write("[");
    for(long i = 0; i < b; i++)
    {
        Console.Write(a[i]);
        if(i < b - 1)
            Console.Write(", ");
        else
            Console.WriteLine("]");
    }
}

void TestPrintArray(long[] a, long b)
{
    Console.Write("[");
    for(long i = 0; i < b; i++)
    {
        Console.Write(a[i]);
        if(i < b - 1)
            Console.Write(", ");
        else
            Console.WriteLine("]");
    }
}