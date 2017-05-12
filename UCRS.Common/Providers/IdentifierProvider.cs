using System;
using System.Text;

using UCRS.Common.Contracts;

namespace UCRS.Common.Providers
{
    public class IdentifierProvider : IIdentifierProvider
    {
        /// <summary>
        /// Decodes the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The decoded id
        /// </returns>
        /// <exception cref="System.ArgumentNullException">urlId is null</exception>
        public Guid DecodeId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Id is null");
            }

            byte[] base64EncodedBytes = Convert.FromBase64String(id);
            string bytesAsString = Encoding
                                    .UTF8
                                    .GetString(base64EncodedBytes);

            if (bytesAsString.EndsWith(GlobalConstants.Salt))
            {
                return new Guid(bytesAsString.Replace(GlobalConstants.Salt, string.Empty));
            }

            return new Guid();
        }

        /// <summary>
        /// Encodes the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Encoded id
        /// </returns>
        public string EncodeId(Guid id)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(id + GlobalConstants.Salt);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
