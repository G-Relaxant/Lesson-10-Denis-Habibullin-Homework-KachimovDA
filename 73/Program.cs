Console.Write("Введите число N: ");
long number = long.Parse(Console.ReadLine());
long[] array = new long[number];
FillArray(array);
Console.WriteLine($"Количество чисел для группировки: {number}");
long arrayValuesZeroingCounter = 0;
int groupNumber = 1;
Console.WriteLine($"Группа {groupNumber}: {array[0]}");
array[0] = 0;

while(arrayValuesZeroingCounter < number)
{
    long[] group = new long[number];
    long lastCellGroupIndex = 1;
    long FirstIndexGroupValueSearchRelay = 0;
    for(long FirstIndexGroupValueSearch = 0; array[FirstIndexGroupValueSearch] == 0 || FirstIndexGroupValueSearch < number; FirstIndexGroupValueSearch++)
    {
        FirstIndexGroupValueSearchRelay = FirstIndexGroupValueSearch;
    }
    FirstIndexGroupValueSearchRelay++;
    group[0] = FirstIndexGroupValueSearchRelay;
    for(long i = FirstIndexGroupValueSearchRelay + 1; i < number; i++)
    {
        long groupIndex = 0;
        if(array[i] != 0)
        {
            while(groupIndex < lastCellGroupIndex)
            {
                if(array[i] % group[groupIndex] != 0)
                {
                    if(groupIndex == lastCellGroupIndex - 1)
                    {
                        group[groupIndex] = array[i];
                        lastCellGroupIndex++;
                        array[i] = 0;
                        arrayValuesZeroingCounter++;
                    }
                }
                else
                {
                    break;
                }
                groupIndex++;
            }
        }
    }
    groupNumber++;
    Console.Write($"Группа {groupNumber}: ");
    PrintGroup(group, lastCellGroupIndex);
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