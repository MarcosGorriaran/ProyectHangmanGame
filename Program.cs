using System;

namespace HangingGame
{
    class Execute
    {
        public static void Main()
        {
            const ConsoleColor ErrorColor = ConsoleColor.Red, WelcomeColor = ConsoleColor.Green;
            const ConsoleColor CorrectBackground = ConsoleColor.Green;
            const ConsoleColor WrongBackground = ConsoleColor.Red;
            const ConsoleColor BlackForWhiteBackground = ConsoleColor.Black;
            const string WelcomeMsg = "***************************************\n*********Bienvenid@ AL AHORCADO********\n***************************************";
            const string MainMenuAsk = "Por favor, escoge el nivel de dificultad:";
            const string MainMenuOptions = "A. Facil\nB. Normal\nC. Dificil\nD. Experto\nE. Exit";
            const string MainMenuAskValue = "Elige una opcion: ";
            const string OptionOutsideRange = "La opcion seleccionada esta fuera del rango permitido";
            const string ShowLeftAttemtps = "Le quedan {0} intentos";
            const string LetterOptions = "ABCDEFGHIJKLMNOPKRSTWXYZ";
            const char EmptyWords = '_';
            const char LetterOptionSpliter = ' ';
            const char LineJumper = '\n', SectionSpliter = '-';
            const int Spliter = 2, UTFAWord = 65, UTFZWord = 90, ExitOption = 4, MinOption = 0, MaxOption = 4,EasyAttemptsReducer = 0,NormalAttemptsReducer = 2, HardAttemptsReducer = 3, ExpertAttemptsReducer = 4;
            const int EasyMode = 0, NormalMode = 1, HardMode = 2, ExpertMode = 3, LetterOptionsJumpLineOn = 13;

            string[] hangmanWords = {"DISCO","PERSONA","BIENVENIDA", "DESPROPORCIONAMENTE" };
            string[] hangmans = {"  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                                "  +---+\n  |   |\n      |\n      |\n      |\n      |\n========="
                                 };
            string guessWord, showWords;
            char[] usedCharacters;
            int option, attemptReducer, attempts;
            bool repeat, found;

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
                //MainMenu
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
                
                if (option != ExitOption)
                {
                    attemptReducer = option switch
                    {
                        EasyMode => EasyAttemptsReducer,
                        NormalMode => NormalAttemptsReducer,
                        HardMode => HardAttemptsReducer,
                        ExpertMode => ExpertAttemptsReducer,
                    };
                    attempts = hangmans.Length - attemptReducer;
                    guessWord = hangmanWords[option];
                    showWords = new string(EmptyWords, guessWord.Length);
                    usedCharacters = new char[0];
                    while (attempts > 0)
                    {
                        //The game
                        Console.WriteLine(new string(SectionSpliter, Console.WindowWidth));
                        Console.WriteLine(ShowLeftAttemtps, attempts);
                        //Building Keyboard
                        for (int i = 0; i < LetterOptions.Length; i++)
                        {
                            int j = 0;
                            found = false;
                            while(j < usedCharacters.Length && !found)
                            {
                                found = usedCharacters[j] == LetterOptions[i];
                                j++;
                            }
                            if (found)
                            {
                                Console.BackgroundColor = guessWord.Contains(LetterOptions[i]) ? CorrectBackground : WrongBackground;
                                Console.ForegroundColor = BlackForWhiteBackground;
                            }
                            Console.Write(LetterOptions[i]);
                            Console.ResetColor();
                            Console.Write(LetterOptionSpliter);
                            if ((i+1)%LetterOptionsJumpLineOn==0)
                            {
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine(hangmans[attempts-1]);
                        do
                        {

                        }
                    }
                }
            }while (option!=ExitOption);
        }
    }
}