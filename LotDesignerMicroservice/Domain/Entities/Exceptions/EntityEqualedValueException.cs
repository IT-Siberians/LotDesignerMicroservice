namespace LotDesignerMicroservice.Domain.Entities.Exceptions
{
    /// <summary>
    /// Exception for alredy set entity property
    /// </summary>
    internal class EntityEqualedValueException(Type type, string paramName)
        : ArgumentNullException("paramName", $"Received {type.Name} {paramName} value is equals to current value");
}
