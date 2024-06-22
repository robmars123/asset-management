namespace AssetManagement.Application.Generics
{
    public class QueryResult<T>
    {
        public bool Successful { get; }
        public IEnumerable<string> Messages { get; }
        public T? Result { get; set; }

        public QueryResult(bool successful, IEnumerable<string> messages)
        {
            Successful = successful;
            Messages = messages;
        }

        public QueryResult(bool successful, T? result)
        {
            Successful = successful;
            Result = result;
        }
    }
}
