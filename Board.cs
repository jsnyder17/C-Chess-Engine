using System;
using System.Collections.Generic;

public class Board {
    private List<Piece> pieces;
    private Square[,] squares;
    private MoveCalculator mc;

    public Board() {
        pieces = new List<Piece>();
        squares = new Square[8,8];
        mc = new MoveCalculator();

        initializeSquares();
    }

    private void initializeSquares() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                squares[i,j] = new Square(j, i);
                
                if (i == 0) {
                    if (j == 0 || j == 7) {
                        squares[i,j].setPiece(new Rook("BR", 1, j, i));
                    }
                    else if (j == 1 || j == 6) {
                        squares[i,j].setPiece(new Knight("Bk", 1, j, i));
                    }
                    else if (j == 2 || j == 5) {
                        squares[i,j].setPiece(new Bishop("BB", 1, j, i));
                    }
                    else if (j == 3) {
                        squares[i,j].setPiece(new Queen("BQ", 1, j, i));
                    }
                    else if (j == 4) {
                        squares[i,j].setPiece(new King("BK", 1, j, i));
                    }                
                }
                else if (i == 1) {
                    squares[i,j].setPiece(new Pawn("BP", 1, j, i));
                }
                else if (i == 6) {
                    squares[i,j].setPiece(new Pawn("WP", 0, j, i));
                }
                else if (i == 7) {
                    if (j == 0 || j == 7) {
                        squares[i,j].setPiece(new Rook("WR", 0, j, i));
                    }
                    else if (j == 1 || j == 6) {
                        squares[i,j].setPiece(new Knight("Wk", 0, j, i));
                    }
                    else if (j == 2 || j == 5) {
                        squares[i,j].setPiece(new Bishop("WB", 0, j, i));
                    }
                    else if (j == 3) {
                        squares[i,j].setPiece(new Queen("WQ", 0, j, i));
                    }
                    else if (j == 4) {
                        squares[i,j].setPiece(new King("WK", 0, j, i));
                    }
                }
                else {
                    squares[i,j].setPiece(null);
                }
            }
        }
    }

    public void drawBoard() {
        //Console.WriteLine("drawBoard() called. ");

        for (int i = 0; i < 8; i++) {
            Console.Write(8 - i + "|");
            for (int j = 0; j < 8; j++) {
                Console.Write(squares[i,j].getPieceString());
            }
            Console.WriteLine("");
        }
        Console.WriteLine("  a  b  c  d  e  f  g  h");

        Console.WriteLine("\n\n");
    }

    public bool movePiece(CoordinateSet from , CoordinateSet to, int turnIndex) {
        bool success = false;

        if (findSquare(from, true)) {
            if (findSquare(to, false)) {
                int index = 0;
                bool found = false;
                Square toSquare = squares[to.getYCoord(), to.getXCoord()];
                Square fromSquare = squares[from.getYCoord(), from.getXCoord()];
                
                if (fromSquare.getPiece().getColor() == turnIndex) {
                    List<CoordinateSet> csList = mc.calcPossibleMoves(fromSquare.getPiece(), squares);
                    
                    while (index < csList.Count && !found) {
                        if (csList[index].equals(toSquare.getCoordinateSet())) {
                            found = true;
                            Console.WriteLine("Found. ");
                        }
                        index += 1;
                    }
                    if (found) {
                        Console.WriteLine("Moving from " + convertToChessCoord(from) + " to " + convertToChessCoord(to) + " ... ");
                        Console.WriteLine("Moving " + squares[from.getYCoord(), from.getXCoord()].getPiece().GetType() + " ... ");
                        squares[to.getYCoord(), to.getXCoord()].setPiece(squares[from.getYCoord(), from.getXCoord()].getPiece());
                        
                        // Update the coordinates of the piece
                        squares[to.getYCoord(), to.getXCoord()].getPiece().setXCoord(to.getXCoord());
                        squares[to.getYCoord(), to.getXCoord()].getPiece().setYCoord(to.getYCoord());
                        
                        // Set the piece of the previous square to null
                        squares[from.getYCoord(), from.getXCoord()].setPiece(null);

                        // Ensure pawn's firstTurn is set to false if first move 
                        if (squares[to.getYCoord(), to.getXCoord()].getPiece().GetType() == typeof(Pawn)) {
                            Pawn pawn = (Pawn)squares[to.getYCoord(), to.getXCoord()].getPiece();
                            if (pawn.getFirstTurn()) {
                                pawn.setFirstTurn(false);
                            }
                        }

                        success = true;
                    }
                }
            }
        }

        return success;
    } 

    public bool checkKings() {
        bool allKings = false;
        int kingCount = 0;

        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (squares[i,j].getPiece() != null) {
                    if (squares[i,j].getPiece().GetType() == typeof(King)) {
                        kingCount += 1;
                    }
                }
            }
        }

        if (kingCount == 2) {
            allKings = true;
        }

        return allKings;
    }

    private bool findSquare(CoordinateSet cs, bool checkNull) {
        int i = 0;
        bool found = false;

        while (i < 8 && !found) {
            for (int j = 0; j < 8; j++) {
                if (i == cs.getYCoord() && j == cs.getXCoord()) {
                    if (checkNull) {
                        if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() != null) {
                            found = true;
                        }
                    }
                    else{
                        found = true;
                    }
                }
            }
            i++;
        }

        //Console.WriteLine("findSquare() loop finished. ");

        return found;
    }

    private string convertToChessCoord(CoordinateSet cs) {
        string chessCoord = "";

        switch (cs.getXCoord()) {
            case 0:
                chessCoord += "a";
                break;
            case 1:
                chessCoord += "b";
                break;
            case 2:
                chessCoord += "c";
                break;
            case 3:
                chessCoord += "d";
                break;
            case 4:
                chessCoord += "e";
                break;
            case 5:
                chessCoord += "f";
                break;
            case 6:
                chessCoord += "g";
                break;
            case 7:
                chessCoord += "h";
                break;
        }

        chessCoord += (Math.Abs(cs.getYCoord() - 8)).ToString();

        return chessCoord;
    }
}