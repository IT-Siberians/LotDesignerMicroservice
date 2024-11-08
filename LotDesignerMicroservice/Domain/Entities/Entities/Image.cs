using LotDesignerMicroservice.Domain.Entities.Base;

namespace LotDesignerMicroservice.Domain.Entities.Entities
{
    /// <summary>
    /// Represents image entities
    /// </summary>
    public class Image : Entity<Guid>
    {
        /// <summary>
        /// Get image source url
        /// </summary>
        public Uri Url { get; }

        /// <summary>
        /// Get image lot card
        /// </summary>
        public LotCard LotCard { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="Image"></see> class
        /// </summary>
        /// <param name="url"> Image source url </param>
        public Image(Uri url, LotCard lotCard)
        {
            Url = url;
            LotCard = lotCard;
        }

        /// <summary>
        /// EF constructor of a <see cref="Image"></see> class
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Image() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
