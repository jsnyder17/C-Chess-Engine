public class King : Piece {
    public King() {

    }
    public King(string name, int color, int xCoord, int yCoord) {
        this.name = name;
        this.color = color;
        this.coordinateSet = new CoordinateSet(xCoord, yCoord);
    }
}