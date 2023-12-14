namespace sharedFunctions;

public interface IDoTheMath
{
  public bool AmIEven (decimal value);
}
public class DoTheMath : IDoTheMath
{
    public bool AmIEven(decimal value)
    {
        return value != 0 && value % 2 == 0;
    }
}
