/*	
	C# Calculator ¬ 7Games
	Created: 11/12/21
	Last Edited: 12/12/21
*/

using System;

namespace C__Calculator {
	class Program {
		
		//Ints
		static int[] buttonLocations = {43, 46, 49, 52, 71, 74, 77, 80, 99, 102, 105, 108, 127, 130, 133, 136};
		static int cursorPosition = 5;
		static int calcOperator = 0;
		static int numberOn = 0;
		//Doubles
		static double firstNumber = 0;
		static double secondNumber = 0;
		
		//Chars
		static char cursorChar = '#';
		//Strings
		static string result = "";
		static string calculator = "";
		static string currentNumber = "";
		
		//Bools
		static bool running = true;

		static void drawCalaulator() {
			//Converts the calculator string to a char array to make it easier to edit.
			char[] charCalculator = calculator.ToCharArray();

			//Makes sure that the cursor is in a acceptable location.
			switch(cursorPosition) {
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

			//Moves the cursor to the button location.
			charCalculator[buttonLocations[cursorPosition]] = cursorChar;
			
			calculator = new string(charCalculator);

			//Makes dots appear before the characters in the result box.
			string dots = "";
			for (int i = 0; i<(11 - result.ToCharArray().Length); i++){
				dots += "·";
			}

			/*Check to see if the length of result is bigger than 11, 
			if it is it makes the string 9 characters then adds two dots to the begining of the string.*/
			if(result.Length>11){
				result = result.Substring(result.Length - 9, 9);
				result = result.Insert(0, "..");
			}
			
			calculator = calculator.Replace("···········", (dots + result));
			
			Console.WriteLine(calculator);
		}

		static void input() {
			switch(Console.ReadKey().Key){
				//Moves the cursor.
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
				//Selects the button the cursor is currently on.
				case ConsoleKey.Spacebar:
					//Numbers
					if(cursorPosition != 3 && cursorPosition != 7 && cursorPosition != 11 && cursorPosition != 12 && cursorPosition != 14 && cursorPosition != 15){
						if (numberOn < 2) {
							//Adds the number currently selected to the result box.
							char[] charCalculator = calculator.ToCharArray();
							result += charCalculator[buttonLocations[cursorPosition] + 1];
							currentNumber += charCalculator[buttonLocations[cursorPosition] + 1];
						}
					}

					//Calculator Operators
					if(cursorPosition == 3 || cursorPosition == 7 || cursorPosition == 11 || cursorPosition == 15){
						if (numberOn == 0) {
							int[] operatorLocation = {3, 7, 11, 15};
							char[] charCalculator = calculator.ToCharArray();
							result += charCalculator[buttonLocations[cursorPosition] + 1];
							
							for(int i = 0; i < 3; i++) {
								if (cursorPosition - operatorLocation[i] == 0) {
									calcOperator = i;
								}
							}

							numberOn = 1;
							firstNumber = Convert.ToUInt32(currentNumber);
							currentNumber = "";
						}  else if (numberOn==1) {
								int[] operatorLocation = {3, 7, 11, 15};
								char[] charCalculator = calculator.ToCharArray();

								for(int i = 0; i < 3; i++) {
									if (cursorPosition - operatorLocation[i] == 0) {
										calcOperator = i;
									}
								}

								//Replaces the current operator with the one the user selects.
								if (result.Contains('+')) 
									result = result.Replace('+', charCalculator[buttonLocations[cursorPosition] + 1]);
								else if (result.Contains('-')) 
									result = result.Replace('-', charCalculator[buttonLocations[cursorPosition] + 1]);
								else if (result.Contains('x')) 
									result = result.Replace('x', charCalculator[buttonLocations[cursorPosition] + 1]);
								else if (result.Contains('÷')) 
									result = result.Replace('÷', charCalculator[buttonLocations[cursorPosition] + 1]);
							}
					}
					//Clear and Equal Buttons
					switch(cursorPosition) {
						case 12:
							result = string.Empty;
							currentNumber = string.Empty;
							firstNumber = 0;
							secondNumber = 0;
							calcOperator = 0;
							numberOn = 0;
							break;
						case 14:
							if (numberOn == 1) {
								result += "=";
								numberOn = 2;
								secondNumber = Convert.ToUInt32(currentNumber);
								switch(calcOperator) {
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
				calculator = "╔═══════════╗\n║···········║\n╠══╦══╦══╦══╣\n║ 1║ 2║ 3║ +║\n╠══╬══╬══╬══╣\n║ 4║ 5║ 6║ -║\n╠══╬══╬══╬══╣\n║ 7║ 8║ 9║ x║\n╠══╬══╬══╬══╣\n║ C║ 0║ =║ ÷║\n╚══╩══╩══╩══╝";
				Console.SetCursorPosition(0, 0);
				drawCalaulator();
				input();
			}
		}
	}
}