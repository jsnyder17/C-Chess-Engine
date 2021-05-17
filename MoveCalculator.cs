using System;
using System.Collections.Generic;

public class MoveCalculator {
    private Square[,] squares;

    public List<CoordinateSet> calcPossibleMoves(Piece piece, Square[,] squares) {
        List<CoordinateSet> csList = new List<CoordinateSet>();

        this.squares = squares;
        
        if (piece.GetType() == typeof(Pawn)) {
            csList = calcPossiblePawnMoves(piece, squares);
        }
        else if (piece.GetType() == typeof(Knight)) {
            csList = calcPossibleKnightMoves(piece, squares);
        }
        else if (piece.GetType() == typeof(Bishop)) {
            csList = calcPossibleBishopMoves(piece, squares);
        }
        else if (piece.GetType() == typeof(Rook)) {
            csList = calcPossibleRookMoves(piece, squares);
        }
        else if (piece.GetType() == typeof(Queen)) {
            csList = calcPossibleQueenMoves(piece, squares);
        }
        else if (piece.GetType() == typeof(King)) {
            csList = calcPossibleKingMoves(piece, squares);
        }  

        return csList;
    }
    public List<CoordinateSet> calcPossiblePawnMoves(Piece piece, Square[,] squares) {
        List<CoordinateSet> csList = new List<CoordinateSet>();

        Pawn pawn = (Pawn)piece;

        //Console.WriteLine("Calculating Pawn moves for Pawn at X: " + piece.getXCoord() + ", " + piece.getYCoord());

        if (piece.getColor() == 0) {
            // Determine vertical moves

            CoordinateSet cs1 = new CoordinateSet(piece.getXCoord(), piece.getYCoord() - 1);
            if (findSquare(cs1, false)) {
                if (squares[piece.getYCoord() - 1, piece.getXCoord()].getPiece() == null) {
                    //Console.WriteLine("Found vertical move. ");
                    csList.Add(cs1);
                }
            }

            if (pawn.getFirstTurn()) {
                CoordinateSet cs2 = new CoordinateSet(piece.getXCoord(), piece.getYCoord() - 2);
                if (findSquare(cs2, false)) {
                    if (squares[piece.getYCoord() - 2, piece.getXCoord()].getPiece() == null && squares[piece.getYCoord() - 1, piece.getXCoord()].getPiece() == null) {
                        //Console.WriteLine("Found vertical move. ");
                        csList.Add(cs2);
                    }
                }
            }    
            

            // Determine diagonal/ capture moves
            CoordinateSet cs3 = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() - 1);
            if (findSquare(cs3, false)) {
                if (squares[piece.getYCoord() - 1, piece.getXCoord() + 1].getPiece() != null) {
                    if (squares[piece.getYCoord() - 1, piece.getXCoord() + 1].getPiece().getColor() != piece.getColor()) {
                        //Console.WriteLine("Is " + squares[piece.getXCoord() + 1, piece.getYCoord() - 1].getPiece().getColor() + " == " + piece.getColor() + "? ");
                        //Console.WriteLine("Found diagonal capture move. ");
                        csList.Add(cs3);
                    }
                }
            }
            CoordinateSet cs4 = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() - 1);
            if (findSquare(cs4, false)) {
                if (squares[piece.getYCoord() - 1, piece.getXCoord() - 1].getPiece() != null) {
                    if (squares[piece.getYCoord() - 1, piece.getXCoord() - 1].getPiece().getColor() != piece.getColor()) {
                        //Console.WriteLine("Found diagonal capture move. ");
                        csList.Add(cs4);
                    }
                }
            }
        }


        
        else {
            // Determine vertical moves

            CoordinateSet cs5 = new CoordinateSet(piece.getXCoord(), piece.getYCoord() + 1);
            if (findSquare(cs5, false)) {
                if (squares[piece.getYCoord() + 1, piece.getXCoord()].getPiece() == null) {
                    //Console.WriteLine("Found vertical move. ");
                    csList.Add(cs5);
                }
            }

            if (pawn.getFirstTurn()) {
                CoordinateSet cs6 = new CoordinateSet(piece.getXCoord(), piece.getYCoord() + 2);
                if (findSquare(cs6, false)) {
                    if (squares[piece.getYCoord() + 2, piece.getXCoord()].getPiece() == null && squares[piece.getYCoord() + 1, piece.getXCoord()].getPiece() == null) {
                        //Console.WriteLine("Found vertical move. ");
                        csList.Add(cs6);
                    }
                }
            }    
            

            // Determine diagonal/ capture moves
            CoordinateSet cs7 = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() + 1);
            if (findSquare(cs7, false)) {
                if (squares[piece.getYCoord() + 1, piece.getXCoord() + 1].getPiece() != null) {
                    if (squares[piece.getYCoord() + 1, piece.getXCoord() + 1].getPiece().getColor() != piece.getColor()) {
                        //Console.WriteLine("Found diagonal capture move. ");
                        csList.Add(cs7);
                    }
                }
            }
            CoordinateSet cs8 = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() + 1);
            if (findSquare(cs8, false)) {
                if (squares[piece.getYCoord() + 1, piece.getXCoord() - 1].getPiece() != null) {
                    if (squares[piece.getYCoord() + 1, piece.getXCoord() - 1].getPiece().getColor() != piece.getColor()) {
                        //Console.WriteLine("Found diagonal capture move. ");
                        csList.Add(cs8);
                    }
                }
            }
        }

        return csList;
    }












    public List<CoordinateSet> calcPossibleKnightMoves(Piece piece, Square[,] squares) {
        //Console.WriteLine("Calculating Knight moves ... ");

        List<CoordinateSet> csList = new List<CoordinateSet>();

        // Determine vertical moves 
        CoordinateSet cs1 = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() - 2);
        if (findSquare(cs1, false)) {
            if (squares[piece.getYCoord() - 2, piece.getXCoord() - 1].getPiece() == null) {
                csList.Add(cs1);
            }
            else {
                if (squares[piece.getYCoord() - 2, piece.getXCoord() - 1].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs1);
                }
            }
        }

        CoordinateSet cs2 = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() - 2);
        if (findSquare(cs2, false)) {
            if (squares[piece.getYCoord() - 2, piece.getXCoord() + 1].getPiece() == null) {
                csList.Add(cs2);   
            }
            else {
                if (squares[piece.getYCoord() - 2, piece.getXCoord() + 1].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs2);   
                }
            }
        }
        
        CoordinateSet cs3 = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() + 2);
        if (findSquare(cs3, false)) {
            if (squares[piece.getYCoord() + 2, piece.getXCoord() - 1].getPiece() == null) {
                csList.Add(cs3); 
            }
            else {
                if (squares[piece.getYCoord() + 2, piece.getXCoord() - 1].getPiece().getColor() != piece.getColor()) {
                csList.Add(cs3); 
                } 
            }
        }

        CoordinateSet cs4 = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() + 2);
        if (findSquare(cs4, false)) {
            if (squares[piece.getYCoord() + 2, piece.getXCoord() + 1].getPiece() == null) {
                csList.Add(cs4);
            }
            else {
                if (squares[piece.getYCoord() + 2, piece.getXCoord() + 1].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs4);
                }
            }
        }
        



        // Determine horizontal moves
        CoordinateSet cs5 = new CoordinateSet(piece.getXCoord() + 2, piece.getYCoord() - 1);
        if (findSquare(cs5, false)) {
            if (squares[piece.getYCoord() - 1, piece.getXCoord() + 2].getPiece() == null) {
                csList.Add(cs5);
            }
            else {
                if (squares[piece.getYCoord() - 1, piece.getXCoord() + 2].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs5);
                }
            }
        }
        
        CoordinateSet cs6 = new CoordinateSet(piece.getXCoord() - 2, piece.getYCoord() - 1);
        if (findSquare(cs6, false)) {
            if (squares[piece.getYCoord() - 1, piece.getXCoord() - 2].getPiece() == null) {
                csList.Add(cs6);
            }
            else {
                if (squares[piece.getYCoord() - 1, piece.getXCoord() - 2].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs6);
                }
            }
        }
        
        CoordinateSet cs7 = new CoordinateSet(piece.getXCoord() + 2, piece.getYCoord() + 1);
        if (findSquare(cs7, false)) {
            if (squares[piece.getYCoord() + 1, piece.getXCoord() + 2].getPiece() == null) {
                csList.Add(cs7);
            }
            else {
                if (squares[piece.getYCoord() + 1, piece.getXCoord() + 2].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs7);
                }
            }
        }
        
        CoordinateSet cs8 = new CoordinateSet(piece.getXCoord() - 2, piece.getYCoord() + 1);
        if (findSquare(cs8, false)) {
            if (squares[piece.getYCoord() + 1, piece.getXCoord() - 2].getPiece() == null) {
                csList.Add(cs8);
            }
            else {
                if (squares[piece.getYCoord() + 1, piece.getXCoord() - 2].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs8);
                }
            }
        }
        

        return csList;
    }











    private List<CoordinateSet> calcPossibleBishopMoves(Piece piece, Square[,] squares) {
        //Console.WriteLine("Calculating Bishop moves ... ");

        List<CoordinateSet> csList = new List<CoordinateSet>();
        bool pieceCollision = false;

        // Loop through squares diagonal from the piece 
        
        // North west
        CoordinateSet cs = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() - 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() + 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() - 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        
        // North east
        cs = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() - 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() + 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() - 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }


        // South west
        cs = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() + 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() - 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() + 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }


        // South east
        cs = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() + 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() - 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        } 
                    }    
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() + 1);
        }

        return csList;
    }












    private List<CoordinateSet> calcPossibleRookMoves(Piece piece, Square[,] squares) {
        List<CoordinateSet> csList = new List<CoordinateSet>();
        CoordinateSet cs;

        bool pieceCollision = false;

        // North
        cs = new CoordinateSet(piece.getXCoord(), piece.getYCoord() - 1);

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() + 1);

                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() - 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        // South
        cs = new CoordinateSet(piece.getXCoord(), cs.getYCoord() + 1);

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() - 1);

                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() + 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        // East
        cs = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord());

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord());

                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord());
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        // West
        cs = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord());

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord());

                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord());
        }

        return csList;
    }








    private List<CoordinateSet> calcPossibleQueenMoves(Piece piece, Square[,] squares) {
        List<CoordinateSet> csList = new List<CoordinateSet>();
        CoordinateSet cs;
        bool pieceCollision = false;

        // North
        cs = new CoordinateSet(piece.getXCoord(), piece.getYCoord() - 1);

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() + 1);
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() - 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        
        // South
        cs = new CoordinateSet(piece.getXCoord(), piece.getYCoord() + 1);

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() - 1);
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord(), cs.getYCoord() + 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        // East
        cs = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord());

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord());

                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord());
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        // West
        cs = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord());

        while (findSquare(cs, false) && !pieceCollision) {
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord());

                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord());
        }

        // North west
        cs = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() - 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() + 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() - 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }

        
        // North east
        cs = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() - 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() + 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() - 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }


        // South west
        cs = new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() + 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() - 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        }
                    }
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() + 1);
        }
        if (pieceCollision) {
            pieceCollision = false;
        }


        // South east
        cs = new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() + 1);

        while (findSquare(cs, false) && !pieceCollision) {
            //Console.WriteLine("running loop. ");
            if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                csList.Add(cs);
            }
            else {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                    csList.Add(cs);
                }
                else {
                    cs = new CoordinateSet(cs.getXCoord() - 1, cs.getYCoord() - 1); // If the same color, end the possible moves to the square before the opposite color square. End the loop here if so 
                    if (findSquare(cs, false)) {
                        if (!cs.equals(piece.getCoordinateSet())) {
                            csList.Add(cs);
                        } 
                    }    
                }

                pieceCollision = true;
            }

            cs = new CoordinateSet(cs.getXCoord() + 1, cs.getYCoord() + 1);
        }

        return csList;
    }







    private List<CoordinateSet> calcPossibleKingMoves(Piece piece, Square[,] squares) {
        List<CoordinateSet> csList = new List<CoordinateSet>();
        List<CoordinateSet> tempList = new List<CoordinateSet>();

        tempList.Add(new CoordinateSet(piece.getXCoord(), piece.getYCoord() - 1));
        tempList.Add(new CoordinateSet(piece.getXCoord(), piece.getYCoord() + 1));
        tempList.Add(new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord()));
        tempList.Add(new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord()));
        tempList.Add(new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() - 1));
        tempList.Add(new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() - 1));
        tempList.Add(new CoordinateSet(piece.getXCoord() + 1, piece.getYCoord() + 1));
        tempList.Add(new CoordinateSet(piece.getXCoord() - 1, piece.getYCoord() + 1));

        foreach (CoordinateSet cs in tempList) {
            if (findSquare(cs, false)) {
                if (squares[cs.getYCoord(), cs.getXCoord()].getPiece() == null) {
                    csList.Add(cs);
                }
                else {
                    if (squares[cs.getYCoord(), cs.getXCoord()].getPiece().getColor() != piece.getColor()) {
                        csList.Add(cs);
                    }
                }
            }
        }

        return csList;
    }







    private bool findSquare(CoordinateSet cs, bool checkNull) {
        int i = 0;
        bool found = false;

        //Console.WriteLine("Determine validity of " + cs.getXCoord() + ", " + cs.getYCoord());

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
}
