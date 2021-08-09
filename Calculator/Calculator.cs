using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        public string Calculate(string mathString)
        {
            List<string> mathList = StringToList(mathString);
            mathString = Solution(mathList).ToString();
            return mathString;
        }


        private double Solution(List<string> list)
        {
            List<string> symbols = new() { "+", "-", "*", "/"};
            List<string> brackets = new() { "(", ")" };

            Stack<double> numsStack = new();
            Stack<int> numsCounterStack = new();
            Stack<string> operatorsStack = new();
            Stack<int> openedBracketIndex = new();

            numsCounterStack.Push(0);
            for(int i = 0; i < list.Count; i++)
            {
                if (symbols.Contains(list[i]))
                {
                    if (list[i] == "+" && list[i - 1] == "(" || list[i] == "+" && i == 0)
                    {
                        continue;
                    }
                    else if (operatorsStack.Count == 0)
                    {
                        operatorsStack.Push(list[i]);
                    }
                    else if(list[i] == "-" && list[i-1] == "+")
                    {
                        operatorsStack.Pop();
                        operatorsStack.Push(list[i]);
                    }
                    else if(symbols.Contains(operatorsStack.Peek()))
                    {
                        if( Priority(operatorsStack.Peek()) < Priority(list[i]))
                        {
                            operatorsStack.Push(list[i]);
                        }
                        else if (Priority(operatorsStack.Peek()) == Priority(list[i]) || Priority(operatorsStack.Peek()) > Priority(list[i]))
                        {
                            string symbol = operatorsStack.Pop();
                            if (symbol == "-" && numsStack.Count == 1)
                            {
                                double num2 = numsStack.Pop();
                                num2 = -num2;
                                numsStack.Push(num2);
                            }
                            else
                            {
                                double num2 = numsStack.Pop();
                                double num1 = numsStack.Pop();
                                switch (symbol)
                                {
                                    case "*":
                                        num1 *= num2;
                                        numsStack.Push(num1);
                                        break;
                                    case "/":
                                        num1 /= num2;
                                        numsStack.Push(num1);
                                        break;
                                    case "+":
                                        num1 += num2;
                                        numsStack.Push(num1);
                                        break;
                                    case "-":
                                        num1 -= num2;
                                        numsStack.Push(num1);
                                        break;
                                }
                            }
                            operatorsStack.Push(list[i]);
                            
                        }
                    }
                    else
                    {
                        operatorsStack.Push(list[i]);
                    }
                }
                else if (brackets.Contains(list[i]))
                {
                    if(list[i] == "(")
                    {
                        openedBracketIndex.Push(i);
                        operatorsStack.Push(list[i]);
                        numsCounterStack.Push(0);
                    }
                    else
                    {
                        
                        string symbol;
                        while (true)
                        {
                            if (numsCounterStack.Peek() > 1)
                            {
                                symbol = operatorsStack.Pop();
                                if (symbols.Contains(symbol))
                                {
                                    
                                        int numsCounter = numsCounterStack.Pop() - 1;
                                        numsCounterStack.Push(numsCounter);
                                        double num2 = numsStack.Pop();
                                        double num1 = numsStack.Pop();
                                        switch (symbol)
                                        {
                                            case "*":
                                                num1 *= num2;
                                                numsStack.Push(num1);
                                                break;
                                            case "/":
                                                num1 /= num2;
                                                numsStack.Push(num1);
                                                break;
                                            case "+":
                                                num1 += num2;
                                                numsStack.Push(num1);
                                                break;
                                            case "-":
                                                num1 -= num2;
                                                numsStack.Push(num1);
                                                break;
                                        }
                                    
                                    
                                }
                                else if (symbol == "(")
                                {
                                    numsCounterStack.Pop();
                                    break;
                                }
                            }
                            else
                            {
                                bool isOpenBracketTaked = false;
                                numsCounterStack.Pop();
                                symbol = operatorsStack.Pop();
                                if(symbol == "(" && openedBracketIndex.Pop() != 0)
                                {
                                    isOpenBracketTaked = true;
                                    
                                    symbol = operatorsStack.Pop();
                                }
                                else
                                {
                                    break;
                                }
                                double num2 = numsStack.Pop();
                                double num1 = numsStack.Pop();
                                switch (symbol)
                                {
                                    case "*":
                                        num1 *= num2;
                                        numsStack.Push(num1);
                                        break;
                                    case "/":
                                        num1 /= num2;
                                        numsStack.Push(num1);
                                        break;
                                    case "+":
                                        num1 += num2;
                                        numsStack.Push(num1);
                                        break;
                                    case "-":
                                        num1 -= num2;
                                        numsStack.Push(num1);
                                        break;
                                }
                                if (isOpenBracketTaked) break;
                                
                            }
                        }
                    }
                }
                else
                {
                    numsStack.Push(Convert.ToInt32(list[i]));
                    int numsCounter = numsCounterStack.Pop() + 1;
                    numsCounterStack.Push(numsCounter);
                }
            }

            while(operatorsStack.Count != 0)
            {
                string symbol = operatorsStack.Pop();
                
                if(symbol == "-" && numsCounterStack.Peek() == 1)
                {
                    double num2 = numsStack.Pop();
                    num2 = -num2;
                    numsStack.Push(num2);
                    
                }
                else
                {
                    int numsCounter = numsCounterStack.Pop() - 1;
                    numsCounterStack.Push(numsCounter);
                    double num2 = numsStack.Pop();
                    double num1 = numsStack.Pop();
                    switch (symbol)
                    {
                        case "*":
                            num1 *= num2;
                            numsStack.Push(num1);
                            break;
                        case "/":
                            num1 /= num2;
                            numsStack.Push(num1);
                            break;
                        case "+":
                            num1 += num2;
                            numsStack.Push(num1);
                            break;
                        case "-":
                            num1 -= num2;
                            numsStack.Push(num1);
                            break;
                    }
                }
            }
            return numsStack.Pop();
        }
        private List<string> StringToList(string mathS)
        {
            List<char> symbols = new() { '*', '/', '+', '-' };
            List<char> brackets = new() { '(', ')' };
            List<char> numbers = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<string> math = new();

            for(int i = 0; i < mathS.Length; i++)
            {
                if (symbols.Contains(mathS[i]))
                {
                    if(mathS[i].ToString() == "+")
                    {
                        if(i == 0)
                        {
                            continue;
                        }
                        else if(mathS[i - 1].ToString() == "(")
                        {
                            continue;
                        }
                        else
                        {
                            math.Add(mathS[i].ToString());
                        }
                    }
                    else if (mathS[i].ToString() == "-")
                    {
                        if (mathS[i+1].ToString() == "(")
                        {
                            math.Add("-1");
                            math.Add("*");
                        }
                        else if (i == 0)
                        {
                            math.Add(mathS[i].ToString());
                        }
                        else if (mathS[i - 1].ToString() == "(")
                        {
                            math.Add(mathS[i].ToString());
                        }
                        else if(mathS[i - 1].ToString() == "+")
                        {
                            math.Add(mathS[i].ToString());
                        }
                        else if (mathS[i - 1].ToString() == "-")
                        {
                            math[math.Count - 1] = "+";
                        }
                        else
                        {
                            math.Add("+");
                            math.Add(mathS[i].ToString());
                        }
                    }
                    else
                    {
                        math.Add(mathS[i].ToString());
                    }
                }
                else if (brackets.Contains(mathS[i]))
                {
                    math.Add(mathS[i].ToString());
                }
                else if (numbers.Contains(mathS[i]))
                {

                    if (i == 0)
                    {
                        math.Add(mathS[i].ToString());
                    }
                    else if (math[math.Count - 1][0] == '-' || numbers.Contains(math[math.Count - 1][0]))
                    {
                        math[math.Count - 1] += mathS[i];
                    }
                    else
                    {
                        math.Add(mathS[i].ToString());
                    }
                }
            }
            
            
            
            return math;
        }
        
        private int Priority(string symbol)
        {
            switch (symbol)
            {
                case "+":
                    return 1;
                case "-":
                    return 1;
                case "*":
                    return 2;
                case "/":
                    return 2;
                default:
                    break;
            }
            return 0;
        }

    }



}
