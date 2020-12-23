public class Position : EntityData {

    public double3 Value;

    public Position () {

        Value = new double3 (0, 0, 0);

    }

    public Position (double x, double y, double z) {

        Value = new double3 (x, y, z);

    }

    public Position (double3 position) {

        Value = position;

    }

}
