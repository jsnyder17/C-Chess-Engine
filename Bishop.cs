public class Bishop : Piece {
    public Bishop() {

    }
    public Bishop(string name, int color, int xCoord, int yCoord) {
        this.name = name;
        this.color = color;
        this.coordinateSet = new CoordinateSet(xCoord, yCoord);
    }
}