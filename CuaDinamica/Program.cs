using CuaDinamica;

internal class Program
{
    private static void Main(string[] args)
    {
        Cua<int> ints = new Cua<int>();
        ints.Encua(1);
        ints.Encua(2);
        ints.Encua(3);
        ints.Encua(4);
        ints.Encua(5);
        ints.Encua(6);
        Console.WriteLine(ints);
        ints.Desencua();
        ints.Desencua();
        Console.WriteLine(ints);
    }
}