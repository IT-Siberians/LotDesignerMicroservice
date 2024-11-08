using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;
using LotDesignerMicroservice.Domain.ValueObjects.Constants;
using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.StringObjects
{
    /// <summary>
    /// Represents type of the entity's user name
    /// </summary>
    /// <param name="value"> User name's string value </param>
    public sealed class UserName(string value) : StringValueObject(value, Validate)
    {
        static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new StringObjectEmptyOrWhiteSpacesException(typeof(UserName), value);

            if (value.Length < UserNameConstants.MIN_LENGHT)
                throw new StringObjectMinLenghtException(typeof(UserName), value.Length, UserNameConstants.MIN_LENGHT);

            if (value.Length > UserNameConstants.MAX_LENGHT)
                throw new StringObjectMaxLenghtException(typeof(UserName), value.Length, UserNameConstants.MAX_LENGHT);
        }
    }
}