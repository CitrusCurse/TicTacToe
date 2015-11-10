//Tic-Tac-Toe
//Coded By: Kristina Powell (circa May 2015)
//Warning: The code is disgustingly ugly and not optimized...but the game works...
//...as long as you follow the directions...uhhh....awkward
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystery
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variable Declaration
            char topLeft = ' ' ,topCenter = ' ', topRight = ' ', left = ' ', center = ' ', right = ' ', bottomLeft = ' ', bottomCenter = ' ', bottomRight = ' ';
            char responseChar;
            int escape = 0;
            string ticTacToeBoard;
            #endregion

            #region Tic-Tac-Toe Board
            ticTacToeBoard = "\n      |     |    \n   "+ topLeft +"  |  "+ topCenter +"  |  "+ topRight +"  \n _____|_____|_____\n      |     |     \n   "+ left +"  |  "+ center +"  |  "+ right +"  \n _____|_____|_____\n      |     |     \n   "+ bottomLeft +"  |  "+ bottomCenter +"  |  "+ bottomRight +"  \n      |     |\n";
            #endregion

            #region Beginning Sequence (Key or Start Game)
            Console.WriteLine("\n    Tic-Tac-Toe!\n     (2 Player)\n" + ticTacToeBoard);
            Console.Write("Would you like to display the key? (y or n)  ");
            responseChar = char.ToLower(Convert.ToChar(Console.ReadLine()[0]));

            if (responseChar == 'y')
                PositionKey(ref topLeft, ref topCenter, ref topRight, ref left, ref center, ref right,
                            ref bottomLeft, ref bottomCenter, ref bottomRight, ref escape, ref responseChar);
            else
                Game(ref topLeft, ref topCenter, ref topRight, ref left, ref center, ref right,
                     ref bottomLeft, ref bottomCenter, ref bottomRight, ref escape, ref responseChar);
            #endregion

        }

        #region Position Key
        static void PositionKey(ref char topLeft, ref char topCenter, ref char topRight, ref char left, ref char center, ref char right,
                 ref char bottomLeft, ref char bottomCenter, ref char bottomRight, ref int escape, ref char responseChar)
        {
            Console.WriteLine("\nNote: These will be the keywords when entering a move.\nType the word help when prompted during move selection to see the key.");
            Console.WriteLine("\nIn order (L to R): topLeft, topCenter, topRight,\n                   left, center, right,\n                     bottomLeft, bottomCenter, bottomRight.");
            Game(ref topLeft, ref topCenter, ref topRight, ref left, ref center, ref right,
                 ref bottomLeft, ref bottomCenter, ref bottomRight, ref escape, ref responseChar);
        }
        #endregion

        #region Check Sequence
        static void CheckSequence(ref char topLeft, ref char topCenter, ref char topRight, ref char left, ref char center, ref char right,
                                  ref char bottomLeft, ref char bottomCenter, ref char bottomRight, ref char player1Char, ref char player2Char,
                                  ref string player1Name, ref string player2Name, ref int escape, ref int round, ref string ticTacToeBoard,
                                  ref char responseChar, ref string moveSelection)
        {
            int player1Win = 0, player2Win = 0;


            if (round == 9)
            {
                if (player1Win != 1 && player2Win != 1)
                {
                    Console.WriteLine("This game was a tie.");
                    escape = 1;
                    player1Win = 0;
                    player2Win = 0;
                }
            }

            if (round > 4)
            {
                if (((topLeft == topCenter && topCenter == topRight) || (left == center && center == right) || (bottomLeft == bottomCenter && bottomCenter == topCenter) ||
                    (topLeft == left && left == bottomLeft) || (topCenter == center && center == bottomCenter) || (topRight == right && right == bottomRight) ||
                    (topLeft == center && center == bottomRight) || (topRight == center && center == bottomLeft)))
                {
                    ticTacToeBoard = "\n      |     |    \n   " + topLeft + "  |  " + topCenter + "  |  " + topRight + "  \n _____|_____|_____\n      |     |     \n   " + left + "  |  " + center + "  |  " + right + "  \n _____|_____|_____\n      |     |     \n   " + bottomLeft + "  |  " + bottomCenter + "  |  " + bottomRight + "  \n      |     |\n";

                    #region Player 1 Win Conditions
                    if ((topLeft == player1Char && topCenter == player1Char && topRight == player1Char) ||
                        (left == player1Char && center == player1Char && right == player1Char) ||
                        (bottomLeft == player1Char && bottomCenter == player1Char && topCenter == player1Char) ||
                        (topLeft == player1Char && left == player1Char && bottomLeft == player1Char) ||
                        (topCenter == player1Char && center == player1Char && bottomCenter == player1Char) ||
                        (topRight == player1Char && right == player1Char && bottomRight == player1Char) ||
                        (topLeft == player1Char && center == player1Char && bottomRight == player1Char) ||
                        (topRight == player1Char && center == player1Char && bottomLeft == player1Char))
                    {
                        Console.WriteLine("{0} has won this round.", player1Name);
                        player1Win = 1;
                        escape = 1;
                    }
                    #endregion

                    #region Player 2 Win Conditions
                    if ((topLeft == player2Char && topCenter == player2Char && topRight == player2Char) ||
                        (left == player2Char && center == player2Char && right == player2Char) ||
                        (bottomLeft == player2Char && bottomCenter == player2Char && topCenter == player2Char) ||
                        (topLeft == player2Char && left == player2Char && bottomLeft == player2Char) ||
                        (topCenter == player2Char && center == player2Char && bottomCenter == player2Char) ||
                        (topRight == player2Char && right == player2Char && bottomRight == player2Char) ||
                        (topLeft == player2Char && center == player2Char && bottomRight == player2Char) ||
                        (topRight == player2Char && center == player2Char && bottomLeft == player2Char))
                    {
                        Console.WriteLine("{0} has won this round.", player2Name);
                        player2Win = 1;
                        escape = 1;
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Game Loop
        static void Game(ref char topLeft, ref char topCenter, ref char topRight, ref char left, ref char center, ref char right,
                         ref char bottomLeft, ref char bottomCenter, ref char bottomRight, ref int escape, ref char responseChar)
        {
            #region Variable Declaration
            string player1Name, player2Name, moveSelection = "  ";
            int round = 1, game = 1;
            char player1Char, player2Char;
            string ticTacToeBoard;
            #endregion

            #region Tic-Tac-Toe Board
            ticTacToeBoard = "\n      |     |    \n   " + topLeft + "  |  " + topCenter + "  |  " + topRight + "  \n _____|_____|_____\n      |     |     \n   " + left + "  |  " + center + "  |  " + right + "  \n _____|_____|_____\n      |     |     \n   " + bottomLeft + "  |  " + bottomCenter + "  |  " + bottomRight + "  \n      |     |\n";
            #endregion

            #region Player Setup
            Console.Write("\nPlease type a name for Player 1: ");
            player1Name = Console.ReadLine();
            Console.Write("\nPlease type a character piece for {0} (ex: X, O, etc.) ", player1Name);
            player1Char = Convert.ToChar(Console.ReadLine()[0]);
            Console.Write("\nPlease type a name for Player 2: ");
            player2Name = Console.ReadLine();
            Console.Write("\nPlease type a character piece for {0} (ex: X, O, etc.) ", player2Name);
            player2Char = Convert.ToChar(Console.ReadLine()[0]);
            #endregion

            #region Main Loop: False Escape
            while (escape == 0 || topLeft != ' ' && topCenter != ' ' && topRight != ' ' && left != ' ' && center != ' ' && right != ' ' && bottomLeft != ' ' && bottomCenter != ' ' && bottomRight != ' ' || round < 9)
            {
                #region Round 1
                if (round == 1)
                {
                    ticTacToeBoard = "\n      |     |    \n      |     |     \n _____|_____|_____\n      |     |     \n      |     |     \n _____|_____|_____\n      |     |     \n      |     |     \n      |     |\n";
                    Console.WriteLine(ticTacToeBoard);
                }
                #endregion

                #region If Player 1's Turn...
                if ((round+2)%2 == 1)
                {
                    #region Move Selection
                    Console.WriteLine("{0}, please select a move.", player1Name);
                    moveSelection = Console.ReadLine();
                    moveSelection = moveSelection.ToLower();
                    #endregion

                    #region Help Screen
                    if (moveSelection == "help")
                    {
                        PositionKey(ref topLeft, ref topCenter, ref topRight, ref left, ref center, ref right,
                                    ref bottomLeft, ref bottomCenter, ref bottomRight, ref escape, ref responseChar);
                        Console.WriteLine("{0}, please select a move.", player1Name);
                        moveSelection = Console.ReadLine();
                        moveSelection = moveSelection.ToLower();
                    #endregion

                        #region Space Check
                        if (((moveSelection == "topleft" || moveSelection == "top left" || moveSelection == "tl" || moveSelection == "t l") && topLeft != ' ') ||
                            ((moveSelection == "topcenter" || moveSelection == "top center" || moveSelection == "tc" || moveSelection == "t c") && topCenter != ' ') ||
                            ((moveSelection == "topright" || moveSelection == "top right" || moveSelection == "tr" || moveSelection == "t r") && topRight != ' ') ||
                            ((moveSelection == "left" || moveSelection == "l") && left != ' ') || 
                            ((moveSelection == "center" || moveSelection == "c")&& center != ' ') ||
                            ((moveSelection == "right" || moveSelection == "r")&& right != ' ') ||
                            ((moveSelection == "bottomleft" || moveSelection == "bottom left" || moveSelection == "bl" || moveSelection == "b l") && bottomLeft != ' ') ||
                            ((moveSelection == "bottomcenter" || moveSelection == "bottom center" || moveSelection == "bc" || moveSelection == "b c") && bottomCenter != ' ') ||
                            ((moveSelection == "bottomright" || moveSelection == "bottom right" || moveSelection == "br" || moveSelection == "b r") && bottomRight != ' '))
                        {
                            Console.WriteLine("This space has already been played on");
                            moveSelection = Console.ReadLine();
                            moveSelection = moveSelection.ToLower();
                        }
                        #endregion
                    }

                    #region Move Declaration
                    if (moveSelection == "topleft" || moveSelection == "top left" || moveSelection == "tl" || moveSelection == "t l")
                        topLeft = player1Char;
                    if (moveSelection == "topcenter" || moveSelection == "top center" || moveSelection == "tc" || moveSelection == "t c")
                        topCenter = player1Char;
                    if (moveSelection == "topright" || moveSelection == "top right" || moveSelection == "tr" || moveSelection == "t r")
                        topRight = player1Char;
                    if (moveSelection == "left" || moveSelection == "l")
                        left = player1Char;
                    if (moveSelection == "center" || moveSelection == "c")
                        center = player1Char;
                    if (moveSelection == "right" || moveSelection == "r")
                        right = player1Char;
                    if (moveSelection == "bottomleft" || moveSelection == "bottom left" || moveSelection == "bl" || moveSelection == "b l")
                        bottomLeft = player1Char;
                    if (moveSelection == "bottomcenter" || moveSelection == "bottom center" || moveSelection == "bc" || moveSelection == "b c")
                        bottomCenter = player1Char;
                    if (moveSelection == "bottomright" || moveSelection == "bottom right" || moveSelection == "br" || moveSelection == "b r")
                        bottomRight = player1Char;
                    #endregion
                }
                #endregion

                #region If Player 2's Turn...
                if ((round + 2) % 2 == 0)
                {
                    #region Move Selection
                    Console.WriteLine("{0}, please select a move.", player2Name);
                    moveSelection = Console.ReadLine();
                    moveSelection = moveSelection.ToLower();
                    #endregion
                    
                    #region Help Screen
                    if (moveSelection == "help")
                    {
                        PositionKey(ref topLeft, ref topCenter, ref topRight, ref left, ref center, ref right,
                                    ref bottomLeft, ref bottomCenter, ref bottomRight, ref escape, ref responseChar);
                        Console.WriteLine("{0}, please select a move.", player2Name);
                        moveSelection = Console.ReadLine();
                        moveSelection = moveSelection.ToLower();
                    #endregion

                        #region Space Check
                        if (((moveSelection == "topleft" || moveSelection == "top left" || moveSelection == "tl" || moveSelection == "t l") && topLeft != ' ') ||
                            ((moveSelection == "topcenter" || moveSelection == "top center" || moveSelection == "tc" || moveSelection == "t c") && topCenter != ' ') ||
                            ((moveSelection == "topright" || moveSelection == "top right" || moveSelection == "tr" || moveSelection == "t r") && topRight != ' ') ||
                            ((moveSelection == "left" || moveSelection == "l") && left != ' ') ||
                            ((moveSelection == "center" || moveSelection == "c") && center != ' ') ||
                            ((moveSelection == "right" || moveSelection == "r") && right != ' ') ||
                            ((moveSelection == "bottomleft" || moveSelection == "bottom left" || moveSelection == "bl" || moveSelection == "b l") && bottomLeft != ' ') ||
                            ((moveSelection == "bottomcenter" || moveSelection == "bottom center" || moveSelection == "bc" || moveSelection == "b c") && bottomCenter != ' ') ||
                            ((moveSelection == "bottomright" || moveSelection == "bottom right" || moveSelection == "br" || moveSelection == "b r") && bottomRight != ' '))
                        {
                            Console.WriteLine("This space has already been played on");
                            moveSelection = Console.ReadLine();
                            moveSelection = moveSelection.ToLower();
                        }
                        #endregion
                    }

                    #region Move Declaration
                    if (moveSelection == "topleft" || moveSelection == "top left" || moveSelection == "tl" || moveSelection == "t l")
                        topLeft = player2Char;
                    if (moveSelection == "topcenter" || moveSelection == "top center" || moveSelection == "tc" || moveSelection == "t c")
                        topCenter = player2Char;
                    if (moveSelection == "topright" || moveSelection == "top right" || moveSelection == "tr" || moveSelection == "t r")
                        topRight = player2Char;
                    if (moveSelection == "left" || moveSelection == "l")
                        left = player2Char;
                    if (moveSelection == "center" || moveSelection == "c")
                        center = player2Char;
                    if (moveSelection == "right" || moveSelection == "r")
                        right = player2Char;
                    if (moveSelection == "bottomleft" || moveSelection == "bottom left" || moveSelection == "bl" || moveSelection == "b l")
                        bottomLeft = player2Char;
                    if (moveSelection == "bottomcenter" || moveSelection == "bottom center" || moveSelection == "bc" || moveSelection == "b c")
                        bottomCenter = player2Char;
                    if (moveSelection == "bottomright" || moveSelection == "bottom right" || moveSelection == "br" || moveSelection == "b r")
                        bottomRight = player2Char;
                    #endregion
                }
                #endregion

                #region Updated Tic-Tac-Toe Board
                ticTacToeBoard = "\n      |     |    \n   " + topLeft + "  |  " + topCenter + "  |  " + topRight + "  \n _____|_____|_____\n      |     |     \n   " + left + "  |  " + center + "  |  " + right + "  \n _____|_____|_____\n      |     |     \n   " + bottomLeft + "  |  " + bottomCenter + "  |  " + bottomRight + "  \n      |     |\n";
                Console.WriteLine(ticTacToeBoard);
                #endregion

                #region Run Check Sequence
                CheckSequence(ref topLeft, ref topCenter, ref topRight, ref left, ref center, ref right,
                                  ref bottomLeft, ref bottomCenter, ref bottomRight, ref player1Char, ref player2Char,
                                  ref player1Name, ref player2Name, ref escape, ref round, ref ticTacToeBoard,
                                  ref responseChar, ref moveSelection);
                round++;
                #endregion

                #region Sub-Loop: True Escape
                while (escape == 1)
                {
                    Console.Write("Would you like to play again? (y or n)  ");
                    responseChar = char.ToLower(Convert.ToChar(Console.ReadLine()));
                    if (responseChar == 'y')
                    {
                        Reset(ref round, ref topLeft, ref topCenter, ref topRight, ref left, ref center, ref right, ref bottomLeft,
                              ref bottomCenter, ref bottomRight, ref escape, ref responseChar, ref moveSelection, ref player1Name, 
                              ref player2Name, ref player1Char, ref player2Char);
                        round = 1;
                        game++;
                    }
                    else
                    {
                        escape = 2;
                    }
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region Reset Sequence
        static void Reset(ref int round, ref char topLeft, ref char topCenter, ref char topRight, ref char left, ref char center, ref char right,
                          ref char bottomLeft, ref char bottomCenter, ref char bottomRight, ref int escape, ref char responseChar, 
                          ref string moveSelection, ref string player1Name, ref string player2Name, ref char player1Char, ref char player2Char)
        {
            #region Reset
            round = 1;
            topLeft = ' ';
            topCenter = ' ';
            topRight = ' ';
            left = ' ';
            center = ' ';
            right = ' ';
            bottomLeft = ' ';
            bottomCenter = ' ';
            bottomRight = ' ';
            moveSelection = player1Name;
            player1Name = player2Name;
            player2Name = moveSelection;
            responseChar = player1Char;
            player1Char = player2Char;
            player2Char = responseChar;
            Console.WriteLine("Player 1 is now {0} and Player 2 is now {1}. The turn order has changed.", player1Name, player2Name);
            escape = 0;
            #endregion
        }
        #endregion
    }
}
