using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a random 20x20 matrix of 0s and 1s
        int[,] matrix = GenerateRandomMatrix(200, 200);

        // Convert the matrix to a 20x20 image
        Bitmap image = ConvertMatrixToImage(matrix);

        // Get the path to the desktop
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Specify the full path where the image will be saved
        string imagePath = Path.Combine(desktopPath, "matrix_image.png");

        // Save the image as a PNG file to the desktop
        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

        Console.WriteLine($"Image saved to {imagePath}");
    }

    // Generates a 20x20 matrix with random 0s and 1s
    static int[,] GenerateRandomMatrix(int rows, int cols)
    {
        Random rand = new Random();
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(2); // Randomly assign 0 or 1
            }
        }

        return matrix;
    }

    // Converts the matrix into a Bitmap image
    static Bitmap ConvertMatrixToImage(int[,] matrix)
    {
        int width = matrix.GetLength(0);
        int height = matrix.GetLength(1);
        Bitmap image = new Bitmap(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Set the color of each pixel based on the matrix value
                Color color = matrix[x, y] == 1 ? Color.Black : Color.White;
                image.SetPixel(x, y, color);
            }
        }

        return image;
    }
}
