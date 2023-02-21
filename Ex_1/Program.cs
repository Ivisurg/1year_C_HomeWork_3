// Задача 1
// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом. Проверка без применения строк
// 14212 -> нет
// 12821 -> да
// 23432 -> да

int InputInt(string msg)
{
    System.Console.Write($"{msg}> ");
    if (int.TryParse(Console.ReadLine(), out int value)) return value;
    System.Console.WriteLine("Вы ввели не число. Перезапустите программу.");
    Environment.Exit(1);
    return 0;
}

int number = InputInt("Введите ПЯТИЗНАЧНОЕ число, которое будем проверять на свойство палиндрома");

if (number > 9999 && number < 100000)
{
    int numberForCut = number;   //пересохранили введенное число для работы (введенное число остается неизменным в памяти)
    int grade = 10000;          //пятая степень делителя для проверки первой цифры. При работе с массивом из цифр числа степень = длинне массива.
    int flag = 1;               //маркер с ошибкой (по умолчанию введенное число НЕ палиндром)

    for (int i = 1; i < 3; i++)   //в общем случае магическое число 3 заменяем значением = половине длины числа (строки/массива из цифр числа)
    {
        int numFront = numberForCut / grade;
        int numBack = numberForCut % 10;
        if (numFront == numBack)
        {
            System.Console.WriteLine($"{i}-ое число {numFront} совпадает с {6 - i}-ым числом {numBack}");
            flag = 0;                                              //флаг показывает отсутсвие ошибки
            numberForCut = (numberForCut % grade) / 10;          //откинули первую и последнюю цифры   
            grade = grade / 100;                               //уменьшили на 2 порядка (степени) делителя для поиска первой цифры урезанного числа
        }
        else
        {
            System.Console.WriteLine($"Введенное число {number} не является палиндромом.");
            flag = 1;
            break;
        }
    }

    if (flag == 0) System.Console.WriteLine($"Введенное число {number} является палиндромом.");

}
else System.Console.WriteLine($"Введенное число {number} не пятизначное. Перезапустите программу");