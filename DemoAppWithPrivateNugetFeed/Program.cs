namespace DemoAppWithPrivateNugetFeed
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string hello = HelloWorldContainerizedDemo.HelloWorldContainerizedDemo.GetHello();
            System.Console.WriteLine(hello);
           
        }
    }
}
