using System.Globalization;

namespace GlobalTestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var culture in cultures)
            {
                System.Console.WriteLine(culture.Name);
            }
            
        }
    }
}
