using static System.Console;

//TimesTable(15);
static void TimesTable(byte number)
{
    WriteLine($"This is the {number} times table: ");
    for(int row=1; row<=12; row++)
    {
        WriteLine($"{row} x {number} = {row * number}");
    }
    WriteLine();
}

//decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "FR");
//WriteLine($"You must pay {taxToPay} in tax");
static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
{
    decimal rate = 0.0M;
    switch (twoLetterRegionCode)
    {
        case "CH":
            rate = 0.08M;
            break;
        case "DK":
        case "NO":
            rate = 0.25M;
            break;
        case "GB":
        case "FR":
            rate = 0.2M;
            break;
        case "HU":
            rate = 0.27M;
            break;
        case "OR":
        case "AK":
        case "MI":
            rate = 0.0M;
            break;
        case "ND":
        case "WI":
        case "ME":
        case "VA":
            rate = 0.05M;
            break;
        case "CA":
            rate = 0.0825M;
            break;
        default:
            rate = 0.05M;
            break;
    }
    return amount * rate;
}

//RunCardinalToOrdinal();

/// <summary>
/// 32비트 정수를 서수로 변환한다
/// </summary>
/// <param name="number">1, 2, 3과 같은 기수</param>
/// <returns>1th, 2nd, 3rd와 같은 서수</returns>
static string CardinalToOrdinal(int number)
{
    switch (number)
    {
        case 11:
        case 12:
        case 13:
            return $"{number}th";
        default:
            int lastDigit = number % 10;
            string suffix = lastDigit switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
            return $"{number}{suffix}";
    }
}

static void RunCardinalToOrdinal()
{
    for(int number = 1; number <= 40; number++)
    {
        Write($"{CardinalToOrdinal(number)} ");
    }
}


//RunFactorial();
//재귀함수
static int Factorial(int number)
{
    if(number < 1)
    {
        return 0;
    }
    else if(number ==1){
        return 1;
    }
    else
    {
        checked
        {
            return number * Factorial(number - 1);
        }
    }
}

static void RunFactorial()
{
    for (int i = 1;i<15;i++)
    {
        try
        {
            WriteLine($"{i}! = {Factorial(i):N0}");
        }
        catch (System.OverflowException)
        {
            WriteLine($"{i}! is too big for a 32-bit integer");
        }
    }
}

//피보나치 
//명령형 함수와 선언형 함수의 차이
static int FibImperative(int term)
{
    if(term == 1)
    {
        return 0;
    }
    else if(term == 2)
    {
        return 1;
    }
    else
    {
        return FibImperative(term - 1) + FibImperative(term - 2);
    }
}

static void RunFibImperative()
{
    for(int i=1; i<=30; i++) 
    {
        WriteLine($"The {CardinalToOrdinal(i)} term of Fibonacci sequence is {FibImperative(term: i):N0}.");
    }
}

//RunFibImperative();

static int FibFunctional(int term) => term switch
{
    1 => 0,
    2 => 1,
    _ => FibImperative(term - 1) + FibImperative(term - 2)
};

static void RunFibFunctional()
{
    for (int i = 1; i <= 30; i++)
    {
        WriteLine($"The {CardinalToOrdinal(i)} term of Fibonacci sequence is {FibFunctional(term: i):N0}.");
    }
}

RunFibFunctional();