namespace UCRS.Common
{
    public static class StringExtention
    {
        /// <summary>
        /// Formats the specified arguments.
        /// </summary>
        /// <param name="formatTemplate">The format template.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formated string</returns>
        public static string Format(this string formatTemplate, params object[] args)
        {
            return string.Format(formatTemplate, args);
        }
    }
}
