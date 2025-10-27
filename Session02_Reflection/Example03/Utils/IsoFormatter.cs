
namespace Example03.Utils
{
    public class ISOFormatter : IFormatter
    {
        public string Format(DateTime dateTime)
            => dateTime.ToString("yyyy-MM-dd");
    }
}