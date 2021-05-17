using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class GameManager {
    private Board board;
    private int turnIndex;

    public GameManager() {
        board = new Board();
        turnIndex = 0;

        startGame();
    }

    private void startGame() {
        bool end = false;
        Random rand = new Random();
        bool legalMove = false;

        while (!end) {
            while (!legalMove) {
                legalMove = board.movePiece(new CoordinateSet(rand.Next(0, 8), rand.Next(0, 8)), new CoordinateSet(rand.Next(0, 8), rand.Next(0, 8)), turnIndex);
            }
            board.drawBoard();

            if (!board.checkKings()) {
                end = true;
            }
            
            if (turnIndex == 0) {
                turnIndex = 1;
            }
            else {
                turnIndex = 0;
            }
            legalMove = false;

            Thread.Sleep(2000);
        }

        Console.WriteLine("*** GAME OVER ***");
    }
}