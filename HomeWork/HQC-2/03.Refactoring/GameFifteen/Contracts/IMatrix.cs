namespace GameFifteen.Contracts
{
    public interface IMatrix
    {
        int Size { get; set; }

        int[,] Matrix { get; }
    }
}
