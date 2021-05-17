using System;
using System.Collections.Generic;

public class Pawn : Piece {
    private bool firstTurn;

    public Pawn() {

    }
    public Pawn(string name, int color, int xCoord, int yCoord) {
        this.name = name;
        this.color = color;
        this.coordinateSet = new CoordinateSet(xCoord, yCoord);
        this.firstTurn = true;
    }

    public bool getFirstTurn() {
        return firstTurn;
    }

    public void setFirstTurn(bool firstTurn) {
        this.firstTurn = firstTurn;
    }
}