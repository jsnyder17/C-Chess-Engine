public class Knight : Piece {
    public Knight() {
        
    }
    public Knight(string name, int color, int xCoord, int yCoord) {
        this.name = name;
        this.color = color;
        this.coordinateSet = new CoordinateSet(xCoord, yCoord);
    }
}