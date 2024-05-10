namespace DemoAppWithPrivateNugetFeed
{
    using HelloWorldAerensDemo

    internal class Program
    {
        static void Main(string[] args)
        {
            var HelloWorld = new helloWord();
            System.Console.WriteLine(HelloWorld.GetHello());
        }
    }
}
