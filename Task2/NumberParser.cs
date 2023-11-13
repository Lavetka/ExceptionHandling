using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            bool incorectFirstSymbol = true;
            bool incorrectSymbols = true;
            bool isMinusValue = false;
            string firstValidSymbol = "+-1234567890";
            string validSymbols = "1234567890";
            int result = 0;

            if (stringValue == null)
            {
                throw new System.ArgumentNullException();
            }

            string stringValueWithoutSpace = stringValue.Trim();

            if (stringValueWithoutSpace == "")
            {
                throw new System.FormatException();
            }

            char firstSymbol = stringValueWithoutSpace[0];

            if (firstValidSymbol.Contains(firstSymbol))
            {
                incorectFirstSymbol = false;
                if (firstSymbol == '-')
                {
                    isMinusValue = true;
                }
                else if (firstSymbol == '+')
                {
                }
                else
                {
                    result = (int)Char.GetNumericValue(firstSymbol);
                }
            }
            if (stringValueWithoutSpace.Length == 1)
            {
                return result;
            }

            if (incorectFirstSymbol)
            {
                throw new System.FormatException();
            }

            for (var b = 1; stringValueWithoutSpace.Length > b; b++)
            {
                char currentChar = stringValueWithoutSpace[b];
                if (validSymbols.Contains(currentChar))
                {
                    if (isMinusValue)
                    {
                        checked
                        {
                            result = result * 10 - ((int)Char.GetNumericValue(currentChar));
                            incorrectSymbols = false;
                        }
                    }
                    else
                    {
                        checked
                        {
                            result = result * 10 + ((int)Char.GetNumericValue(currentChar));
                            incorrectSymbols = false;
                        }
                    }
                }
                else
                {
                    incorrectSymbols = true;
                    break;
                }
            }
            if (incorrectSymbols)
            {
                throw new System.FormatException();
            }
            return result;
        }
    }
}