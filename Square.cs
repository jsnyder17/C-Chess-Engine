using System;

public class Square {
    private Piece piece;
    private CoordinateSet coordinateSet;

    public Square() {
        piece = new Piece();
        coordinateSet = new CoordinateSet();
    }
    public Square(int xCoord, int yCoord) {
        piece = new Piece();
        coordinateSet = new CoordinateSet(xCoord, yCoord);
    }

    public void setPiece(Piece piece) {
        this.piece = piece;
    }
    public Piece getPiece() {
        return piece;
    }

    public CoordinateSet getCoordinateSet() {
        return coordinateSet;
    }

    public string getPieceString() {
        if (piece != null) {
            return piece.getName() + " ";
        }
        else {
            return "*  ";
        }
    }
}