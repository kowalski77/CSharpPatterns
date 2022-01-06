public record Point(double X, double Y);

public record Segment(Point Start, Point End)
{
    public double GetLength()
    {
        var dx = this.Start.X - this.End.X;
        var dy = this.Start.Y - this.End.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}