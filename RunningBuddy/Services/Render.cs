namespace RunningBuddy.Services;

public class Render
{
    public Render()
    {
        Logging.Log("Render service initialized.");
    }
    
    // Menu rendering method for more interactive app control
    public int ShowMenu(string[] options, string title)
    {
        int selectedItem = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"----- {title} -----");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-> ");
                }
                else
                    Console.Write("  ");
                
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
            
            ConsoleKey inputKey = Console.ReadKey(true).Key;

            switch (inputKey)
            {
                case ConsoleKey.Enter:
                    return selectedItem;
                
                case ConsoleKey.UpArrow:
                    selectedItem--;
                    
                    if (selectedItem < 0)
                        selectedItem = options.Length - 1;
                    break;
                
                case ConsoleKey.DownArrow:
                    selectedItem++;
                    if (selectedItem == options.Length)
                        selectedItem = 0;
                    break;
            }
        }
    }
    
    // Renders menu for easier bool entering
    public int BoolMenu(string[] boolMenu, string[] questionsArray, int questionIndex)
    {
        int selectedBool = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(questionsArray[questionIndex]);
            
            for (int i = 0; i < boolMenu.Length; i++)
            {
                if (boolMenu[i] == "yes")
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (boolMenu[i] == "no")
                    Console.ForegroundColor = ConsoleColor.Red;
                
                if (i == selectedBool)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("  ");
                }
                
                Console.WriteLine(boolMenu[i]);
                Console.ResetColor();
            }
            
            ConsoleKey inputKey = Console.ReadKey(true).Key;

            switch (inputKey)
            {
                case ConsoleKey.Enter:
                    return selectedBool;
                
                case ConsoleKey.UpArrow:
                    selectedBool--;

                    if (selectedBool < 0)
                        selectedBool = boolMenu.Length - 1;

                    break;
                
                case ConsoleKey.DownArrow:
                    selectedBool++;

                    if (selectedBool > boolMenu.Length - 1)
                        selectedBool = 0;

                    break;
            }
        }
    }
}
