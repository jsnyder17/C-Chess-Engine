public class Rook : Piece {
    public Rook() {

    }
    public Rook(string name, int color, int xCoord, int yCoord) {
        this.name = name;
        this.color = color;
        this.coordinateSet = new CoordinateSet(xCoord, yCoord);
    }
}