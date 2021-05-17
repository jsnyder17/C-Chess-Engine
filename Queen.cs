public class Queen : Piece {
    public Queen() {

    }
    public Queen(string name, int color, int xCoord, int yCoord) {
        this.name = name;
        this.color = color;
        this.coordinateSet = new CoordinateSet(xCoord, yCoord);
    }
}