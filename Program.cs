/*
 * Alumne: Gorriaran Caamaño Marcos
 * M03. Programacio UF1 
 * v1. 20/11/2023
 * Proyect Hangman       
 */
using System;

namespace HangingGame
{
    class Execute
    {
        public static void Main()
        {
            const ConsoleColor ErrorColor = ConsoleColor.Red, WelcomeColor = ConsoleColor.Green, CorrectBackground = ConsoleColor.Green, WrongBackground = ConsoleColor.Red, BlackForWhiteBackground = ConsoleColor.Black;
            const ConsoleColor WinColor = ConsoleColor.Green, LoseColor = ConsoleColor.Yellow, HangmanColor = ConsoleColor.Cyan;
            const string WelcomeMsg = "***************************************\n*********Bienvenid@ AL AHORCADO********\n***************************************";
            const string GoodbyeMsg = "***************************************\n*************Adios jugador@************\n***************************************";
            const string MainMenuAsk = "Por favor, escoge el nivel de dificultad:";
            const string MainMenuOptions = "A. Facil\nB. Normal\nC. Dificil\nD. Experto\nE. Exit";
            const string MainMenuAskValue = "Elige una opcion: ";
            const string OptionOutsideRange = "La opcion seleccionada esta fuera del rango permitido";
            const string GameOptionOtusideRange = "La letra que ha seleccionado no esta dentro de la lista de caracteres posibles";
            const string CharacterAlreadyUsed = "La letra seleccionada ya ha sido utilizado";
            const string ShowLeftAttemtps = "Le queda {0} intentos";
            const string AskLetter = "Proporcioname con la letra que deseas probar: ";
            const string LetterOptions = "ABCDEFGHIJKLMNOPKRSTWXYZ";
            const string PlayerWins = "Has acertado la palabra, esta era: ";
            const string PlayerLoses = "No has conseguido acertar la palabra antes del limite de intentos, la palabra era: ";
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
            char optionWord;
            int option,gameOption, attemptReducer, attempts;
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
                    //Seting Up the game
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
                    //The game
                    while (attempts > 0 && showWords.Contains(EmptyWords))
                    {
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
                        //Showing correct words
                        Console.WriteLine();
                        foreach (char i in showWords.ToCharArray())
                        {
                            Console.Write(i);
                            Console.Write(LetterOptionSpliter);
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = HangmanColor;
                        Console.WriteLine(hangmans[attempts-1]);
                        Console.ResetColor();

                        //Asking and validating
                        found = false;
                        repeat = false;
                        do
                        {
                            if (repeat)
                            {
                                Console.ForegroundColor = ErrorColor;
                                Console.WriteLine(found ? CharacterAlreadyUsed : GameOptionOtusideRange);
                                Console.ResetColor();
                            }
                            repeat = true;
                            Console.Write(AskLetter);
                            gameOption = Convert.ToInt32(Console.ReadLine().Trim().ToUpper()[0]);
                            int i = 0;
                            found = false;
                            while ((gameOption >= UTFAWord && gameOption <= UTFZWord) && i<usedCharacters.Length && !found)
                            {
                                found = Convert.ToInt32(usedCharacters[i])==gameOption;
                                i++;
                            }
                        } while ((gameOption<UTFAWord || gameOption>UTFZWord) || found);

                        //Changin status of game
                        optionWord = Convert.ToChar(gameOption);
                        char[] aux = showWords.ToCharArray();
                        found = false;
                        for(int i = 0; guessWord.IndexOf(optionWord, i) != -1; i++)
                        {
                            found = true;
                            aux[guessWord.IndexOf(optionWord, i)] = guessWord[guessWord.IndexOf(optionWord, i)];
                        }
                        if (!found)
                        {
                            attempts--;
                        }
                        showWords = new string(aux);
                        aux = usedCharacters;
                        usedCharacters = new char[usedCharacters.Length+1];
                        for(int i = 0; i < usedCharacters.Length-1; i++)
                        {
                            usedCharacters[i] = aux[i];
                        }
                        usedCharacters[usedCharacters.Length-1] = optionWord;
                    }
                    Console.ForegroundColor = attempts > 0 ? WinColor : LoseColor;
                    Console.WriteLine((attempts>0 ? PlayerWins : PlayerLoses)+guessWord);
                    Console.ResetColor();
                }
            }while (option!=ExitOption);

            //Goodbye messege
            Console.WriteLine(new string(SectionSpliter, Console.WindowWidth));
            Console.ForegroundColor = WelcomeColor;
            for (int i = 0; i < GoodbyeMsg.Split(LineJumper).Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - GoodbyeMsg.Split(LineJumper)[i].Length) / Spliter, Console.CursorTop);
                Console.WriteLine(GoodbyeMsg.Split(LineJumper)[i]);
            }
            Console.ResetColor();
        }
    }
}