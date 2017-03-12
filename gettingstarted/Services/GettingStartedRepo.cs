namespace gettingstarted.Services
{
    public class GettingStartedRepo : IGettingStartedRepo
    {
        string[] IGettingStartedRepo.FetchAll()
        {
            string[] values = new string[3] { "pippo", "pluto", "paperino" };
            return values;
        }
    }
}