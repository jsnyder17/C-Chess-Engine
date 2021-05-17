using System;
using System.Collections.Generic;

public class Piece {
    protected string name;
    protected int color;
    protected CoordinateSet coordinateSet;

    public Piece() {
        this.name = "";
        color = 0;
        coordinateSet = new CoordinateSet();
    }
    public Piece(string name, int color, int xCoord, int yCoord) {
        this.name = name;
        this.color = color;
        coordinateSet = new CoordinateSet(xCoord, yCoord);
    }

    public string getName() {
        return name;
    }
    public int getColor() {
        return color;
    }
    public int getXCoord() {
        return coordinateSet.getXCoord();
    }
    public int getYCoord() {
        return coordinateSet.getYCoord();
    }
    public CoordinateSet getCoordinateSet() {
        return coordinateSet;
    }

    public void setName(string name) {
        this.name = name;
    }
    public void setColor(int color) {
        this.color = color;
    }
    public void setXCoord(int xCoord) {
        this.coordinateSet.setXCoord(xCoord);
    }
    public void setYCoord(int yCoord) {
        this.coordinateSet.setYCoord(yCoord);
    }
}