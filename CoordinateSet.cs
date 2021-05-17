using System;

public class CoordinateSet {
    private int xCoord;
    private int yCoord;

    public CoordinateSet() {
        xCoord = 0;
        yCoord = 0;
    }
    public CoordinateSet(int xCoord, int yCoord) {
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }

    public int getXCoord() {
        return xCoord;
    }
    public int getYCoord() {
        return yCoord;
    }

    public void setXCoord(int xCoord) {
        this.xCoord = xCoord;
    }
    public void setYCoord(int yCoord) {
        this.yCoord = yCoord;
    }

    public bool equals(CoordinateSet cs) {
        //Console.WriteLine("X Coord: Is " + this.xCoord + "==" + cs.xCoord);
        //Console.WriteLine("Y Coord: Is " + this.yCoord + "==" + cs.yCoord);
        return (this.xCoord == cs.xCoord && this.yCoord == cs.yCoord);
    }
}