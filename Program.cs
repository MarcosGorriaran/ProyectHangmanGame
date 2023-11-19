using System;

namespace HangingGame
{
    class Execute
    {
        public static void Main()
        {
            const ConsoleColor ErrorColor = ConsoleColor.Red, WelcomeColor = ConsoleColor.Green;
            const string WelcomeMsg = "***************************************\n*********Bienvenid@ AL AHORCADO********\n***************************************";
            const string MainMenuAsk = "Por favor, escoge el nivel de dificultad:";
            const string MainMenuOptions = "A. Facil\nB. Normal\nC. Dificil\nD. Experto\nE. Exit";
            const string MainMenuAskValue = "Elige una opcion: ";
            const string OptionOutsideRange = "La opcion seleccionada esta fuera del rango permitido";
            const char LineJumper = '\n', SectionSpliter = '-';
            const int Spliter = 2, UTFAWord = 65, ExitOption = 4, MinOption = 0, MaxOption = 4,EasyAttemptsReducer = 0,NormalAttemptsReducer = 2, HardAttemptsReducer = 3, ExpertAttemptsReducer = 4;
            const int EasyMode = 0, NormalMode = 1, HardMode = 2, ExpertMode = 3;

            string[] hangmans = {"  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========" };
            int option, attemptReducer;
            bool repeat;

            Console.ForegroundColor = WelcomeColor;
            for (int i = 0; i < WelcomeMsg.Split(LineJumper).Length; i++)
            {
                //Center the Welcome messege to the center of the console window
                Console.SetCursorPosition((Console.WindowWidth-WelcomeMsg.Split(LineJumper)[i].Length)/Spliter, Console.CursorTop);
                Console.WriteLine(WelcomeMsg.Split(LineJumper)[i]);
            }
            Console.ResetColor();
            do
            {
                repeat = false;
                do
                {
                    if (repeat)
                    {
                        Console.ForegroundColor = ErrorColor;
                        Console.WriteLine(OptionOutsideRange);
                        Console.ResetColor();
                    }
                    repeat = true;
                    Console.WriteLine(new string(SectionSpliter,Console.WindowWidth));
                    Console.WriteLine(MainMenuAsk);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(MainMenuOptions);
                    Console.ResetColor();
                    Console.Write(MainMenuAskValue);
                    option = Convert.ToInt32(Console.ReadLine().ToUpper()[0])-UTFAWord;
                } while (option<MinOption || option>MaxOption);
                attemptReducer = option switch
                {
                    EasyMode => EasyAttemptsReducer,
                    NormalMode => NormalAttemptsReducer,
                    HardMode => HardAttemptsReducer,
                    ExpertMode => ExpertAttemptsReducer,
                };

            }while (option!=ExitOption);
        }
    }
}