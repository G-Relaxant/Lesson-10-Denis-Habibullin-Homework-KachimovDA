Console.Write("Введите число от 1 до N: ");
long number = long.Parse(Console.ReadLine());
long[] array = new long[number];
FillArray(array);
Console.Write($"Числа для группировки: ");
TestPrintArray(array, number);
Console.WriteLine();
long arrayValuesZeroingCounter = 1; // Нужен для ограничения первого(основного) цикла, так как классический индекс мы использовать не можем в данном случае, требуется вот такой счётчик переноса ячеек из исходного массива в группы(обнулений ячеек массива)
int groupNumber = 1;
Console.WriteLine($"Группа {groupNumber}: {array[0]}");
array[0] = 0;

while(arrayValuesZeroingCounter < number)   //   1   //Основной цикл, генерирует новые группы, и завершает программу
{
    Console.WriteLine($"TEST 1"); // Тестовые выписки, для отслеживания алгоритма(пока не работает)
    long[] group = new long[number]; // Каждая группа создаётся как отдельный массив
    long lastCellGroupIndex = 2; // Ограничитель для цикла проверки(деления) числа на предыдущие в текущей группе (то есть временная "длина" массива)
    long FirstIndexGroupValueSearchRelay = 0; // Передатчик(эстафета) из цикла 2 индекса с ненулевым значением ячейки
    for(long ind = 0; array[FirstIndexGroupValueSearchRelay] == 0 && ind < number; ind++)  //  2   //Этот цикл ищет ненулевое значение исходного массива, что бы задать первый(нулевой) элемент новой группы
    {
        Console.WriteLine($"TEST 2");
        FirstIndexGroupValueSearchRelay = ind + 1;
    }
    //FirstIndexGroupValueSearchRelay++;
    group[0] = array[FirstIndexGroupValueSearchRelay]; // Начало текущей(новой) группы
    array[FirstIndexGroupValueSearchRelay] = 0;
    arrayValuesZeroingCounter++;
    for(long i = 0; i < number; i++)  //  3  //Цикл перебора исходного массива для поиска подходящих значений в группу
    {
        Console.WriteLine($"TEST 3");
        long groupIndex = 0; // Первый делитель для проверки берётся с нулевого индекса группы, то есть перебор группы идёт слева направо
        if(array[i] != 0) // Проверка на ненулевое значение ячейки для дальнейшей проверки на совместимость с группой
        {
            Console.WriteLine($"TEST 3 1");
            while(groupIndex < lastCellGroupIndex)  //  4  //Цикл проверки на совместимость с группой(деление на все предыдущие значения в группе)
            {
                Console.WriteLine($"TEST 4");
                if(array[i] % group[groupIndex] != 0) // Проверка делением, если результат(остаток) не равен 0, то число прошло проверку текущим делителем, далее делитель меняется(на следующий из группы)
                {
                    Console.WriteLine($"TEST 4 1 YES");
                    groupIndex++;
                    if(groupIndex == lastCellGroupIndex - 1) // Проверка на наличие следующих делителей(или завершение проверки и запись проверяемого числа(делимого) в группу)
                    {
                        Console.WriteLine($"TEST 4 2");
                        group[groupIndex] = array[i];
                        Console.WriteLine($"Test GI yes {groupIndex}");
                        lastCellGroupIndex++;
                        array[i] = 0;
                        arrayValuesZeroingCounter++;
                    }
                }
                else // Если остаток равен 0, значит число не подходит в группу, так как оно поделилось на другое число из группы, цикл 4 останавливается и берётся следующее число из исходного массива
                {
                    Console.WriteLine($"Test GI no {groupIndex}");
                    Console.WriteLine($"TEST 4 1 NO");
                    break;
                }
                Console.WriteLine($"Test GI after check {groupIndex}");
                groupIndex++;
            }
        }
    }
    groupNumber++;
    Console.Write($"Группа {groupNumber}: ");
    PrintGroup(group, lastCellGroupIndex);   //   НУЖНО ДОДЕЛАТЬ РАСПЕЧАТКУ ГРУПП, ЧТО БЫ ВЫПИСЫВАЛ НЕ ВЕСЬ МАССИВ, А ТОЛЬКО НЕНУЛЕВЫЕ ЗНАЧЕНИЯ (НАПОМИНАЛКА)
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