using P01_StudentSystem.Data;

namespace P01StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            // ALTER AUTHORIZATION ON DATABASE::[StudentSystem] TO sa
            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.SaveChanges();
        }
    }
}
