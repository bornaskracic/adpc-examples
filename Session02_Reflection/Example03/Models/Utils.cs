namespace Example03.Models
{
    public static class Utils
    {
        public static string ToDDMMYYYY(DateTime datetime) => $"{datetime.Day}/{datetime.Month}/{datetime.Year}";   
    }
}
