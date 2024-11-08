using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;
using LotDesignerMicroservice.Domain.ValueObjects.Constants;
using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.StringObjects
{
    /// <summary>
    /// Represents type of the entity's title
    /// </summary>
    /// <param name="value"> Title's string value </param>
    public sealed class Title(string value) : StringValueObject(value, Validate)
    {
        static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new StringObjectEmptyOrWhiteSpacesException(typeof(Title), value);

            if (value.Length < TitleConstants.MIN_LENGHT)
                throw new StringObjectMinLenghtException(typeof(Title), value.Length, TitleConstants.MIN_LENGHT);

            if (value.Length > TitleConstants.MAX_LENGHT)
                throw new StringObjectMaxLenghtException(typeof(Title), value.Length, TitleConstants.MAX_LENGHT);
        }
    }
}