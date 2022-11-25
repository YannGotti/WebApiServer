namespace Server.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }

        public static void Initialize(AccountsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
