namespace ConvertToCrimson // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var converter = new XmlToCrimsonConverter();
            var currentDir = Directory.EnumerateFiles(Environment.CurrentDirectory, "*.xml", SearchOption.AllDirectories);
            foreach (string file in Directory.EnumerateFiles(Environment.CurrentDirectory, "*.xml", SearchOption.AllDirectories))
            {
                try
                {
                    var result = converter.Convert(file);
                    File.WriteAllText(Path.ChangeExtension(file,".crimson"), result);
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                finally
                {
                    Console.WriteLine("Файл обоработан!");
                }
            }

            Console.WriteLine("Завершено!");
        }
    }
}