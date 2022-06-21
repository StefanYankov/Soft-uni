namespace DemoRefresher
{
    public static class Configuration
    {
        public const string ConnectionString =
            @"Server={0};Database={1};Integrated Security=True;TrustServerCertificate=True;";
        public const string DatabaseName = "MinionsDB";
        public const string ProcedureName = "usp_GetOlder";
    }
}
