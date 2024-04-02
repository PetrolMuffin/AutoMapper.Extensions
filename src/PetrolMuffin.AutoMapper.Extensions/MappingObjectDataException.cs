using System;
using JetBrains.Annotations;

namespace PetrolMuffin.AutoMapper.Extensions
{
    [PublicAPI]
    [Serializable]
    public class MappingObjectDataException : ArgumentException
    {
        public MappingObjectDataException(string message, string parameterName)
            : base(message, parameterName)
        {
        }
    }
}