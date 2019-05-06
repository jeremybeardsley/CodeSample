using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace AlgorithmAnalysis
{
    class Algorithms4
    {
        // Save all file lines that start with the first letter of the alphabet to a new file
        // Must be able to handle VERY large files.
        public void SaveLines(string inputFilePath, string outputFilePath)
        {
            var inputFile = System.IO.File.ReadAllLines(inputFilePath);
            var output = new List<string>();
            
            foreach (string line in inputFile)
            {
                if (line.StartsWith("A") || line.StartsWith("a"))
                {
                    output.Add(line);
                }
            }
            System.IO.File.WriteAllLines(outputFilePath, output); 
        }
    }
}
