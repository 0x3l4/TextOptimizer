
namespace TextOptimizer
{
	internal class Program
	{
		public static void Main()
		{
			string inputFileName = "russian_nouns.txt";
			string outputFileName = $"filtered_{inputFileName}";
			string binPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			string inputFilePath = Path.Combine(binPath, "Input", $"{inputFileName}");
			string outputFilePath = Path.Combine(binPath, "Output", $"{outputFileName}");

            try
			{
				TextOptimizer.OptimizeFile(inputFilePath, outputFilePath);
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}
	}
}