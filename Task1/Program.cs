using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintFirstCharacter();
        }

        private static void PrintFirstCharacter()
        {
            try
            {
                Console.WriteLine("Write some Text");
                var enteredText = Console.ReadLine();

                if (enteredText == null)
                {
                    throw new System.ArgumentNullException("Text is not written");
                }
                if (enteredText.Trim() == "")
                {
                    throw new System.ArgumentException("Characters were not added");
                }

                Console.WriteLine(enteredText[0]);
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine(a.Message);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine(a.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected Error appears{e}");
            }
        }
    }
}