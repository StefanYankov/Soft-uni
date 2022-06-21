namespace P01InitialSetup
{
    public static class Configuration
    {
        public const string ConnectionString =
            @"Server=.,1433;Database={0};User Id=sa;Password=SoftUn!2021;TrustServerCertificate=True;";
        public const string databaseName = "MinionsDB";
        public const string ProcedureName = "usp_GetOlder";
    }
}