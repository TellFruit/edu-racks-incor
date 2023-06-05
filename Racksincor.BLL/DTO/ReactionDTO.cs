using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO
{
    public class ReactionDTO : BaseDTO<int>
    {
        public bool IsPositive { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }
    }
}
