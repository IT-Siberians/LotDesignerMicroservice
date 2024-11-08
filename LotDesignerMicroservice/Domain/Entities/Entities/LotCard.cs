using LotDesignerMicroservice.Domain.Entities.Base;
using LotDesignerMicroservice.Domain.Entities.Enums;
using LotDesignerMicroservice.Domain.Entities.Exceptions;
using LotDesignerMicroservice.Domain.ValueObjects.DateTimeObjects;
using LotDesignerMicroservice.Domain.ValueObjects.NumericObjects;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;

namespace LotDesignerMicroservice.Domain.Entities.Entities
{
    public class LotCard : Entity<Guid>
    {
        public DateTime CreationDateTime { get; }
        public DateTime? LastModifiedDateTime { get; private set; }

        /// <summary>
        /// Get lot card title
        /// </summary>
        public Title Title { get; private set; }

        /// <summary>
        /// Get lot card description
        /// </summary>
        public Text Description { get; private set; }

        /// <summary>
        /// Get lot card starting price
        /// </summary>
        public Price StartingPrice { get; private set; }

        /// <summary>
        /// Get lot card price step on new bid
        /// </summary>
        public Price PriceStep { get; private set; }

        /// <summary>
        /// Get lot card price to immideatly buying
        /// </summary>
        public Price? RepurchasePrice { get; private set; }

        /// <summary>
        /// Get lot card trade duration
        /// </summary>
        public TradeDuration TradeDuration { get; private set; }

        /// <summary>
        /// Get lot card state
        /// </summary>
        public LotCardState State { get; private set; }

        /// <summary>
        /// Get lot card images
        /// </summary>
        public IReadOnlyCollection<Image> Images => _images.AsReadOnly();

        /// <summary>
        /// Get lot card owner and seller
        /// </summary>
        public Seller Seller { get; }

        /// <summary>
        /// Stores lot card images
        /// </summary>
        private readonly List<Image> _images = [];

        /// <summary>
        /// Initializes a new instance of a <see cref="LotCard"></see> class
        /// </summary>
        /// <param name="url"> Image source url </param>
        public LotCard(
            Title title,
            Text description,
            Price startingPrice,
            Price priceStep,
            Price? repurchasePrice,
            TradeDuration tradeTime,
            LotCardState state,
            Seller seller)
        {
            Title = title ?? throw new EntityNullValueException(GetType(), nameof(Title));
            Description = description ?? throw new EntityNullValueException(GetType(), nameof(Description));
            StartingPrice = startingPrice ?? throw new EntityNullValueException(GetType(), nameof(StartingPrice));
            PriceStep = priceStep ?? throw new EntityNullValueException(GetType(), nameof(PriceStep));
            RepurchasePrice = repurchasePrice;
            TradeDuration = tradeTime ?? throw new EntityNullValueException(GetType(), nameof(TradeDuration));
            State = state;
            Seller = seller ?? throw new EntityNullValueException(GetType(), nameof(Seller));
        }

        /// <summary>
        /// EF constructor of a <see cref="LotCard"></see> class
        /// </summary>
        /// <param name="url"> Image source url </param>
        /// <param name="id"> Image entity identifier </param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected LotCard()
        {

        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Set lot card title
        /// </summary>
        /// <param name="newTitle"> New lot card title </param>
        /// <exception cref="EntityNullValueException"></exception>
        public void SetTitle(Title newTitle)
        {
            if (newTitle == null)
                throw new EntityNullValueException(GetType(), nameof(Title));
            if (newTitle.Equals(Title))
                throw new EntityEqualedValueException(GetType(), nameof(Title));

            Title = newTitle;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Set lot card description
        /// </summary>
        /// <param name="newDescription"> New lot card description </param>
        /// <exception cref="EntityNullValueException"></exception>
        public void SetDescription(Text newDescription)
        {
            if (newDescription == null)
                throw new EntityNullValueException(GetType(), nameof(Description));
            if (newDescription.Equals(Description))
                throw new EntityEqualedValueException(GetType(), nameof(Description));

            Description = newDescription;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Set lot card starting price
        /// </summary>
        /// <param name="newStartingPrice"> New lot card starting price </param>
        /// <exception cref="EntityNullValueException"></exception>
        public void SetStartingPrice(Price newStartingPrice)
        {
            if (newStartingPrice == null)
                throw new EntityNullValueException(GetType(), nameof(StartingPrice));
            if (newStartingPrice.Equals(StartingPrice))
                throw new EntityEqualedValueException(GetType(), nameof(StartingPrice));

            StartingPrice = newStartingPrice;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Set lot card price step on new bid
        /// </summary>
        /// <param name="newPriceStep"> New lot card price step </param>
        /// <exception cref="EntityNullValueException"></exception>
        public void SetPriceStep(Price newPriceStep)
        {
            if (newPriceStep == null)
                throw new EntityNullValueException(GetType(), nameof(PriceStep));
            if (newPriceStep.Equals(PriceStep))
                throw new EntityEqualedValueException(GetType(), nameof(PriceStep));

            PriceStep = newPriceStep;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Set lot card price to immideatly buying
        /// </summary>
        /// <param name="newRepurchasePrice"> New lot card repurchase price </param>
        /// <exception cref="EntityNullValueException"></exception>
        public void SetRepurchasePrice(Price newRepurchasePrice)
        {
            if (newRepurchasePrice == null)
                throw new EntityNullValueException(GetType(), nameof(RepurchasePrice));
            if (newRepurchasePrice.Equals(RepurchasePrice))
                throw new EntityEqualedValueException(GetType(), nameof(RepurchasePrice));

            RepurchasePrice = newRepurchasePrice;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Set lot card trade duration
        /// </summary>
        /// <param name="newTradeDuration"> New lot card trade duration </param>
        /// <exception cref="EntityNullValueException"></exception>
        public void SetTradeDuration(TradeDuration newTradeDuration)
        {
            if (newTradeDuration == null)
                throw new EntityNullValueException(GetType(), nameof(TradeDuration));
            if (newTradeDuration.Equals(TradeDuration))
                throw new EntityEqualedValueException(GetType(), nameof(TradeDuration));

            TradeDuration = newTradeDuration;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Set lot card state
        /// </summary>
        /// <param name="newState"> New lot card state </param>
        /// <exception cref="EntityNullValueException"></exception>
        public void SetState(LotCardState newState)
        {
            if (newState.Equals(State))
                throw new EntityEqualedValueException(GetType(), nameof(TradeDuration));

            State = newState;
            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Add new lot card image
        /// </summary>
        /// <param name="newImage"> New lot card image </param>
        public void AddImage(Image newImage)
        {
            if (_images.Contains(newImage))
                throw new EntityEqualedValueException(GetType(), nameof(Image));

            _images.Add(newImage);

            LastModifiedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Remove existing lot card image
        /// </summary>
        /// <param name="image"> Removing lot card image </param>
        public void RemoveImage(Image image)
        {
            if (!_images.Contains(image))
                throw new EntityNullValueException(GetType(), nameof(Image));

            _images.Remove(image);

            LastModifiedDateTime = DateTime.UtcNow;
        }
    }
}