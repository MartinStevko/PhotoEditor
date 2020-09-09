using System.Threading.Tasks;

namespace PhotoEditor
{
    /// <summary>
    /// Matrix which can be multiplied by constant, vector or other matrix
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Width - Number of matrix columns
        /// Height - Number of matrix rows
        /// </summary>
        protected readonly int Width, Height;

        /// <summary>
        /// Matrix cells values
        /// </summary>
        public readonly double[,] Data;

        /// <summary>
        /// Creates vector with 3 rows and 1 column
        /// </summary>
        /// <param name="x">Matrix[0, 0] value</param>
        /// <param name="y">Matrix[1, 0] value</param>
        /// <param name="z">Matrix[2, 0] value</param>
        public Matrix(double x, double y, double z)
        {
            Width = 1;
            Height = 3;
            Data = new double[,] { { x }, { y }, { z } };
        }

        /// <summary>
        /// Creates matrix with 'height' rows and 'width' columns
        /// </summary>
        /// <param name="width">Number of matrices columns</param>
        /// <param name="height">Number of matrices rows</param>
        /// <param name="data">Values which will be putted into the matrix, array must have 'width' columns and 'height' raws</param>
        public Matrix(int width, int height, double[,] data)
        {
            Width = width;
            Height = height;
            Data = data;
        }

        /// <summary>
        /// Multiplies matrix with a constant
        /// </summary>
        /// <param name="n">Number to multiply matrix with</param>
        /// <returns>Matrix of same dimensions as origin but with multiplied values</returns>
        public Matrix Multiply(double n)
        {
            Parallel.For(0, Height, i =>
            {
                for (int j = 0; j < Width; ++j)
                {
                    Data[i, j] *= n;
                }
            });
            return this;
        }

        /// <summary>
        /// Multiplies matrix with vector from right
        /// </summary>
        /// <param name="x">Vector[0, 0] value</param>
        /// <param name="y">Vector[1, 0] value</param>
        /// <param name="z">Vector[2, 0] value</param>
        /// <returns>Product of matrix and vector with width 1 and height 3</returns>
        public Matrix Multiply(double x, double y, double z)
        {
            double[] vector = new double[] { x, y, z };
            Matrix result = new Matrix(0, 0, 0);
            Parallel.For(0, Height, i =>
            {
                for (int j = 0; j < Width; ++j)
                {
                    result.Data[i, 0] += Data[i, j] * vector[j];
                }
            });
            return result;
        }

        /// <summary>
        /// Multiplies origin matrix with passed matrix from right
        /// </summary>
        /// <param name="matrix">Matrix which will be multiplied with origin matrix from left</param>
        /// <returns>Product of matrices with origin height raws and parameter matrix width columns</returns>
        public Matrix Multiply(Matrix matrix)
        {
            if ((matrix == null) || (Width != matrix.Height))
            {
                throw new System.Exception("Matrices can not be multiplied due to it's dimensions!");
            }

            Matrix result = new Matrix(matrix.Width, Height, new double[Height, matrix.Width]);
            Parallel.For(0, Height, i =>
            {
                for (int j = 0; j < Width; ++i)
                {
                    for (int k = 0; k < Width; ++k)
                    {
                        result.Data[i, j] += Data[i, k] * matrix.Data[k, j];
                    }
                }
            });
            return result;
        }
    }
}
