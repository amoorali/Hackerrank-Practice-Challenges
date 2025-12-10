class Result
{

    /*
     * Complete the 'flippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int flippingMatrix(List<List<int>> matrix)
    {
        // n*n matrix
        int n = matrix.Count;
        int half = n / 2;
        int sum = 0;

        for (int i = 0; i < half; i++)
        {
            for (int j = 0; j < half; j++)
            {
                int topLeft = matrix[i][j];
                int topRight = matrix[i][n - j - 1];
                int bottomLeft = matrix[n - i - 1][j];
                int bottomRight = matrix[n - i - 1][n - j - 1];

                
                sum += Math.Max(Math.Max(topLeft, topRight), Math.Max(bottomLeft, bottomRight));
            }
        }

        return sum;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < 2 * n; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            int result = Result.flippingMatrix(matrix);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
