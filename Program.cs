using System;

namespace C__Calculator {
    class Program {
        
        static bool running = true;
        static int cursorPosition = 5;
        static char cursorChar = '#';
        static string result = "";

        static double firstNumber = 0;
        static double secondNumber = 0;
        static int numberOn = 0;
        static string currentNumber = "";
        static int thing = 0;

        static void drawCalaulator() {
            string calculator = "╔═══════════╗\n║...........║\n╠══╦══╦══╦══╣\n║ 1║ 2║ 3║ +║\n╠══╬══╬══╬══╣\n║ 4║ 5║ 6║ -║\n╠══╬══╬══╬══╣\n║ 7║ 8║ 9║ *║\n╠══╬══╬══╬══╣\n║ C║ 0║ =║ ÷║\n╚══╩══╩══╩══╝";
            char[] charCalculator = calculator.ToCharArray();

            switch(cursorPosition) {
                //First Button Row
                case 0:
                    charCalculator[43] = cursorChar;
                    break;
                case 1:
                    charCalculator[46] = cursorChar;
                    break;
                case 2:
                    charCalculator[49] = cursorChar;
                    break;
                case 3:
                    charCalculator[52] = cursorChar;
                    break;
                //Second Button Row
                case 4:
                    charCalculator[71] = cursorChar;
                    break;
                case 5:
                    charCalculator[74] = cursorChar;
                    break;
                case 6:
                    charCalculator[77] = cursorChar;
                    break;
                case 7:
                    charCalculator[80] = cursorChar;
                    break;
                //Third Button Row
                case 8:
                    charCalculator[99] = cursorChar;
                    break;
                case 9:
                    charCalculator[102] = cursorChar;
                    break;
                case 10:
                    charCalculator[105] = cursorChar;
                    break;
                case 11:
                    charCalculator[108] = cursorChar;
                    break;
                //Forth Button Row
                case 12:
                    charCalculator[127] = cursorChar;
                    break;
                case 13:
                    charCalculator[130] = cursorChar;
                    break;
                case 14:
                    charCalculator[133] = cursorChar;
                    break;
                case 15:
                    charCalculator[136] = cursorChar;
                    break;
                //Out of bounds
                case <0:
                    charCalculator[43] = cursorChar;
                    cursorPosition = 0;
                    break;
                case >15:
                    charCalculator[136] = cursorChar;
                    cursorPosition = 15;
                    break;
            }
            
            calculator = new string(charCalculator);

            string dots = "";

            for (int i = 0; i<(11 - result.ToCharArray().Length); i++){
                dots += "·";
            }

            if(result.Length>11){
                result = result.Substring(result.Length - 9, 9);
                result = result.Insert(0, "..");
            }
            calculator = calculator.Replace("...........", (dots + result));
            

            Console.WriteLine(calculator);
        }

        static void input() {
            switch(Console.ReadKey().Key){
                case ConsoleKey.UpArrow:
                    cursorPosition-=4;
                    break;
                case ConsoleKey.DownArrow:
                    cursorPosition+=4;
                    break;
                case ConsoleKey.RightArrow:
                    cursorPosition+=1;
                    break;
                case ConsoleKey.LeftArrow:
                    cursorPosition-=1;
                    break;
                case ConsoleKey.Spacebar:
                    switch(cursorPosition) {
                        //First Button Row
                        case 0:
                            if (numberOn < 2) {
                                result += "1";
                                currentNumber += "1";
                            }
                            break;
                        case 1:
                            if (numberOn < 2) {
                                result += "2";
                                currentNumber += "2";
                            }
                            break;
                        case 2:
                            if (numberOn < 2) {
                                result += "3";
                                currentNumber += "3";
                            }
                            break;
                        case 3:
                            if (numberOn==0){
                                result += "+";
                                thing = 0;
                                numberOn = 1;
                                firstNumber = Convert.ToUInt32(currentNumber);
                                currentNumber = "";
                            } else if (numberOn==1) {
                                thing = 0;
                                if(result.Contains('-')) {
                                    result = result.Replace('-', '+');
                                } else if(result.Contains('*')) {
                                    result = result.Replace('*', '+');
                                } else if(result.Contains('÷')) {
                                    result = result.Replace('÷', '+');
                                }
                                
                            }
                            break;
                        //Second Button Row
                        case 4:
                            if (numberOn < 2) {
                                result += "4";
                                currentNumber += "4";
                            }
                            break;
                        case 5:
                            if (numberOn < 2) {
                                result += "5";
                                currentNumber += "5";
                            }
                            break;
                        case 6:
                            if (numberOn < 2) {
                                result += "6";
                                currentNumber += "6";
                            }
                            break;
                        case 7:
                            if (numberOn==0){
                                result += "-";
                                thing = 1;
                                numberOn = 1;
                                firstNumber = Convert.ToUInt32(currentNumber);
                                currentNumber = "";
                            } else if (numberOn==1) {
                                thing = 1;
                                if(result.Contains('+')) {
                                    result = result.Replace('+', '-');
                                } else if(result.Contains('*')) {
                                    result = result.Replace('*', '-');
                                } else if(result.Contains('÷')) {
                                    result = result.Replace('÷', '-');
                                }
                                
                            }
                            break;
                        //Third Button Row
                        case 8:
                            if (numberOn < 2) {
                                result += "7";
                                currentNumber += "7";
                            }
                            break;
                        case 9:
                            if (numberOn < 2) {
                                result += "8";
                                currentNumber += "8";
                            }
                            break;
                        case 10:
                            if (numberOn < 2) {
                                result += "9";
                                currentNumber += "9";
                            }
                            break;
                        case 11:
                            if (numberOn==0){
                                result += "*";
                                thing = 2;
                                numberOn = 1;
                                firstNumber = Convert.ToUInt32(currentNumber);
                                currentNumber = "";
                            } else if (numberOn==1) {
                                thing = 2;
                                if(result.Contains('+')) {
                                    result = result.Replace('+', '*');
                                } else if(result.Contains('-')) {
                                    result = result.Replace('-', '*');
                                } else if(result.Contains('÷')) {
                                    result = result.Replace('÷', '*');
                                }
                                
                            }
                            break;
                        //Forth Button Row
                        case 12:
                            result = string.Empty;
                            currentNumber = string.Empty;
                            firstNumber = 0;
                            secondNumber = 0;
                            thing = 0;
                            numberOn = 0;
                            break;
                        case 13:
                            if (numberOn < 2) {
                                result += "0";
                                currentNumber += "0";
                            }
                            break;
                        case 14:
                            if (numberOn == 1) {
                                result += "=";
                                numberOn = 2;
                                secondNumber = Convert.ToUInt32(currentNumber);
                                switch(thing) {
                                    case 0:
                                        result += (firstNumber + secondNumber);
                                        break;
                                    case 1:
                                        result += (firstNumber - secondNumber);
                                        break;
                                    case 2:
                                        result += (firstNumber * secondNumber);
                                        break;
                                    case 3:
                                        result += (firstNumber / secondNumber);
                                        break;
                                }
                            }
                            break;
                        case 15:
                            if (numberOn==0){
                                result += "÷";
                                thing = 3;
                                numberOn = 1;
                                firstNumber = Convert.ToUInt32(currentNumber);
                                currentNumber = "";
                            } else if (numberOn==1) {
                                thing = 3;
                                if(result.Contains('+')) {
                                    result = result.Replace('+', '÷');
                                } else if(result.Contains('-')) {
                                    result = result.Replace('-', '÷');
                                } else if(result.Contains('*')) {
                                    result = result.Replace('*', '÷');
                                }
                                
                            }
                            break;
                    }
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
                default:
                    break;
            }
        }
        
        static void Main(string[] args) {
            Console.WriteLine("Calculator by 7Games\n\nUse [Arrow Keys] to move cursor\nUse the [Space Bar] the select.\nPress [ESC] to exit.");
            Console.ReadKey();
            Console.Clear();

            while(running){
                Console.SetCursorPosition(0, 0);
                drawCalaulator();
                input();
            }
        }
    }
}