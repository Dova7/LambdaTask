using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Game : BaseEntity
    {
        public string GameName { get; set; } = null!;
    }
}
