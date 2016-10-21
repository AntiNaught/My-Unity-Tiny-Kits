public interface IWorker
{
    void Work();
}

public interface IEventHandler
{
    void OnEventExecute(string type, object data);
}
