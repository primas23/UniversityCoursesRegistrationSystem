using System;

namespace UCRS.Common.Contracts
{
    public interface IIdentifierProvider
    {
        /// <summary>
        /// Decodes the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The decoded id
        /// </returns>
        /// <exception cref="System.ArgumentNullException">urlId is null</exception>
        Guid DecodeId(string id);

        /// <summary>
        /// Encodes the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Encoded id
        /// </returns>
        string EncodeId(Guid id);
    }
}
