namespace Matrix
{
    public interface IMathCalculator<T>
    {
        T Add(T n1, T n2);
        T Sub(T n1, T n2);
        T Mul(T n1, T n2);
        T Div(T n1, T n2);
    }
}