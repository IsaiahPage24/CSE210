public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction() {
        _top = 1;
        _bottom = 2;
    }

    public Fraction(int whole_number) {
        _top = whole_number;
        _bottom = 1;
    } 

    public Fraction(int top, int bottom) {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop() {
        return _top;
    }

    public int GetBottom() {
        return _bottom;
    }

    public void SetTop(int top_new) {
        _top = top_new;
    }

    public void DetBottom(int bottom_new) {
        _bottom = bottom_new;
    }
    public string GetFractionString() {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue() {
        double decimal_value = (double)_top/_bottom;
        return decimal_value;
    }
}