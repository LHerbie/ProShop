namespace ProShop.Core.Application;

public class ModelNotFoundException : Exception
{
    public ModelNotFoundException() : base("Cannot find model in context.")
    {
        
    }
}