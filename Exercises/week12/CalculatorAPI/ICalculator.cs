namespace CalculatorAPI
{
    public interface ICalculator
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="start">The first number.</param>
        /// <param name="by">The second number.</param>
        /// <returns>The result of the addition.</returns>
        int Add(int start, int by);



        /// <summary>
        /// Subtracts one number from another.
        /// </summary>
        /// <param name="start">The number to subtract from.</param>
        /// <param name="by">The number to subtract.</param>
        /// <returns>The result of the subtraction.</returns>
        int Subtract(int start, int by);


        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="start">The first number.</param>
        /// <param name="by">The second number.</param>
        /// <returns>The result of the multiplication.</returns>
        int Multiply(int start, int by);


        /// <summary>
        /// Divides one number by another.
        /// </summary>
        /// <param name="start">The number to be divided.</param>
        /// <param name="by">The divisor.</param>
        /// <returns>The result of the division.</returns>
        int Divide(int start, int by);

    }
}
