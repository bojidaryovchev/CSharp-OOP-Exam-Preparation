using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Estates.Data;

namespace Estates.Engine
{
    class EstatesAgency
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var estateEngine = EstateFactory.CreateEstateEngine();
            var result = new List<string>();
            var final = new StringBuilder();

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null || commandLine == "end")
                {
                    // End of command sequence reached
                    break;
                }
                if (commandLine != "")
                {
                    string[] commandTokens = commandLine.Split(' ');
                    string cmd = commandTokens[0];
                    string[] cmdArgs = (commandTokens.Skip(1)).ToArray();
                    string resulting = estateEngine.ExecuteCommand(cmd, cmdArgs);
                    result.Add(resulting);
                    final.AppendLine(resulting);
                }
            }

            using (var streamWriter = new StreamWriter("E:/File.txt", false))
            {
                foreach (var line in result)
                {
                    streamWriter.WriteLine(line);
                }
            }
            Console.WriteLine(final.ToString().Trim());
        }
    }
}