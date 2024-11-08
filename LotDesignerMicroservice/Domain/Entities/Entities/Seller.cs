using LotDesignerMicroservice.Domain.Entities.Base;
using LotDesignerMicroservice.Domain.Entities.Exceptions;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;

namespace LotDesignerMicroservice.Domain.Entities.Entities
{
    /// <summary>
    /// Represents seller entities
    /// </summary>
    public class Seller : Entity<Guid>
    {
        /// <summary>
        /// Get seller username
        /// </summary>
        public UserName UserName { get; private set; }

        /// <summary>
        /// Get seller owned lot cards
        /// </summary>
        public IReadOnlyCollection<LotCard> LotCards => _lotCards.AsReadOnly();

        /// <summary>
        /// Stores seller owned lot cards
        /// </summary>
        private readonly List<LotCard> _lotCards = [];

        /// <summary>
        /// Initializes a new instance of a <see cref="Seller"></see> class
        /// </summary>
        /// <param name="userName"> Seller's username </param>
        public Seller(Guid id, UserName userName) : base()
        {
            Id = id;
            UserName = userName;
        }

        /// <summary>
        /// EF constructor of a <see cref="Seller"></see> class
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Seller() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Creates new lot card
        /// </summary>
        /// <param name="newLotCard"> New seller lot card </param>
        public void CreateLotCard(LotCard newLotCard)
        {
            if (_lotCards.Contains(newLotCard))
                throw new EntityEqualedValueException(GetType(), nameof(LotCard));

            _lotCards.Add(newLotCard);
        }

        /// <summary>
        /// Changes seller user name
        /// </summary>
        /// <param name="newUserName"> New seller user name </param>
        public void ChangeUserName(UserName newUserName)
        {
            if (UserName.Equals(newUserName))
                throw new EntityEqualedValueException(GetType(), nameof(UserName));

            UserName = newUserName;
        }
    }
}