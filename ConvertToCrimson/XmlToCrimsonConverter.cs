using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Crimson.Models;

namespace ConvertToCrimson
{
    /// <summary>
    /// Класс для преобразования xml файла в C# код.
    /// </summary>
    internal class XmlToCrimsonConverter
    {

        /// <summary>
        /// Создаёт новый объект <see cref="XmlToCrimsonConverter"/> .
        /// </summary>
        internal XmlToCrimsonConverter()
        {

        }

        /// <summary>
        /// Конвертирует указанный файл в строку формата C#.
        /// </summary>
        /// <returns>Строка макроса формата C#</returns>
        internal string Convert(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException(nameof(filePath));

            Console.WriteLine($"Конвертация файла {filePath}");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            Console.WriteLine($"...");

            var sb = new StringBuilder();
            // Начало документа.
            sb.Append("new Macro()\r\n                        {\r\n                            #region Python Initialization\r\n\r\n                            Name = \"\",");

            XmlElement? xRoot = xDoc.DocumentElement;

            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    if (xnode.Name == "DefaultMacro")
                    {
                        Console.WriteLine("DefaultMacro...");
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "Description")
                            {
                                Console.WriteLine("Description...");

                                sb.AppendLine($"Description = \"{childnode.InnerText}\",");
                            }

                            if (childnode.Name == "KeyDown")
                            {
                                Console.WriteLine("KeyDown...");

                                var firstChild = childnode.FirstChild;
                                if (firstChild?.Name == "Syntax")
                                {
                                    Console.WriteLine("Syntax...");

                                    sb.AppendLine("Instructions = new List<IInstruction>()");
                                    sb.AppendLine("{");

                                    var script = firstChild.InnerText;
                                    string[] lines = script.Split(
                                        new string[] { Environment.NewLine },
                                        StringSplitOptions.None
                                        );

                                    foreach (string line in lines)
                                    {
                                        Console.WriteLine($"{line}");

                                        if (line.Contains("MoveR"))
                                        {
                                            var parts = line.Split(' ');
                                            if(parts.Length > 2)
                                            {
                                                if(!int.TryParse(parts[1], out var dx))
                                                {
                                                    Console.WriteLine($"Не удалость распарсить {parts[1]}");
                                                }

                                                if(!int.TryParse(parts[2], out var dy))
                                                {
                                                    Console.WriteLine($"Не удалость распарсить {parts[2]}");
                                                }

                                                sb.AppendLine($"new MouseShiftInstruction({dx}, {dy}),");
                                            }
                                        }

                                        if (line.Contains("Delay"))
                                        {
                                            var parts = line.Split(' ');
                                            if (parts.Length > 2)
                                            {
                                                if (!int.TryParse(parts[1], out var delay))
                                                {
                                                    Console.WriteLine($"Не удалость распарсить {parts[1]}");
                                                }

                                                sb.AppendLine($"new DelayInstruction({delay}),");
                                            }
                                        }
                                    }

                                    sb.AppendLine("},");
                                }
                            }
                        }
                    }
                }
            }
            sb.AppendLine("},");
            sb.AppendLine("#endregion");
            sb.AppendLine("},");

            return sb.ToString();
        }
    }
}
