
public class AdditionalProperty 
{
    public enum additional
    {
        Color,
        Lift,
        Seats,
        Speed
    }

    public string GetParameterNameByType(additional type)
    {
        string parameterName = (type + ": ");
        return  parameterName;
    }
}


