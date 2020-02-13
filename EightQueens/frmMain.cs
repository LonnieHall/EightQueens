using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EightQueens
{
    public partial class frmMain : Form
    {
        private const int Rows = 8;
        private const int Columns = 8;
        int TotalSolutions = 0;        
        List<char[,]> WinningGameBoards = new List<char[,]>();

        //O = valid space, X = invalid space, Q = queen

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSolutions_Click(object sender, EventArgs e)
        { SolveThePuzzle(); }

        private void SolveThePuzzle()
        {            
            TryValidSpaces(GetClearGameBoard(), 0);
            RecordWinningGameBoards();
            //PrintWinningGameBoards();
            MessageBox.Show("Finished!", "8 Queens");
        }

        private char[,] GetClearGameBoard()
        {
            char [,] board = new char[Rows, Columns];
            for(int r = 0; r < Rows; r++)
            {
                for(int c = 0; c < Columns; c++)
                {
                    board[r, c] = 'O';
                }
            }
            return board;
        }

        private void TryValidSpaces(char [,] board, int queensPlaced )
        {
            for (int r = 0; r < Rows; r++)
            {
                //No possible solution without a Queen on first row
                //This will prevent unnecessary process time
                if (r > 0 && queensPlaced < 1) { return; } 
                for (int c = 0; c < Columns; c++)
                {
                    if(board[r,c] == 'O') //Valid space to try a Queen
                    {
                        if (queensPlaced < 7)
                        { TryValidSpaces(PlaceQueen(board, r, c), queensPlaced + 1); }
                        else if(!ExistsInWinningGameBoardList(PlaceQueen(board,r,c)))
                        {
                            ++TotalSolutions;
                            WinningGameBoards.Add(PlaceQueen(board, r, c));
                            ShowGameBoard(PlaceQueen(board, r, c), queensPlaced+1);
                            txtGameBoard.Text = "Total Solutions: " + TotalSolutions.ToString() +
                                Environment.NewLine + txtGameBoard.Text;
                            txtGameBoard.Update();                            
                        }
                    }                    
                }
            }            
        }

        private char[,] PlaceQueen(char [,] board, int row, int column)
        {
            char [,] returnBoard = new char[Rows,Columns];            
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    returnBoard[r, c] = board[r, c];
                }
            }

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    //Put an X if it's horizontal vertical or diagonal from the square
                    if (r == row && returnBoard[r, c] != 'Q') { returnBoard[r, c] = 'X'; }
                    if (c == column && returnBoard[r, c] != 'Q') { returnBoard[r, c] = 'X'; }
                    if (Math.Abs(r - row) == Math.Abs(c - column) && returnBoard[r, c] != 'Q') 
                    { returnBoard[r, c] = 'X'; }
                }
            }
            returnBoard[row, column] = 'Q';
            return returnBoard;
        }

        private void PrintBoard(char [,] board)
        { MessageBox.Show(GameBoardToString(board), "Chess Board"); }

        private void PrintWinningGameBoards()
        {
            for (int i = 0; i < WinningGameBoards.Count; i++)
            { PrintBoard(WinningGameBoards[i]); }            
        }

        private void RecordWinningGameBoards()
        {
            StreamWriter sw = new StreamWriter("8Queens.txt");
            for (int i = 0; i < WinningGameBoards.Count; i++)
            {
                sw.WriteLine(GameBoardToString(WinningGameBoards[i]));
                sw.Flush();
            }
        }

        private string GameBoardToString(char [,] board)
        {
            string BoardText = "";
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    BoardText += board[r, c];
                }
                BoardText += Environment.NewLine;
            }
            return BoardText;
        }

        private void ShowGameBoard(char [,] board, int queensPlaced)
        {
            txtGameBoard.Text = "Queens Placed: " + queensPlaced.ToString() + Environment.NewLine
                + GameBoardToString(board);
            txtGameBoard.Update();
        }

        private bool ExistsInWinningGameBoardList(char [,] board)
        {
            bool differentBoard;
            for (int i = 0; i < WinningGameBoards.Count; i++)
            {
                differentBoard = false;
                for (int r = 0; r < Rows; r++)
                { 
                    for (int c = 0; c < Columns; c++)
                    {
                        if (WinningGameBoards[i][r,c] != board[r, c]) { differentBoard = true; }
                    }
                }
                if (!differentBoard) { return true; }                
            }
            return false;
        }
    }
}

//Scrap Heap:

//if (queensPlaced > 6)
//{
//    ShowGameBoard(board, queensPlaced);
//    //PrintBoard(board);
//}

//MessageBox.Show("Unaltered Board: " + queensPlaced.ToString());
//PrintBoard(board);

//PrintBoard(PlaceQueen(board, r, c));

//public char[,][] WinningGameBoard = new char[Rows, Columns][];

// if (queensPlaced > 8) { return; } //Might not be needed

//using (FileStream fs = new FileStream("C:\\4Queens.txt",))