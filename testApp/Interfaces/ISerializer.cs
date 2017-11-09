using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
    /// <summary>
    /// Represents objects that can be used for serializer loan payment result.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Converts the Object to its JSON string representation.
        /// </summary>
        /// <param name="obj">The Object to convert.</param>
        /// <returns>A JSON string representation of the Object.</returns>
        string SerializeObjectToJson(object obj);
    }
}
