using Racksincor.DAL.Models.Abstract;

namespace Racksincor.DAL.Models
{
    public class Record : BaseEntity
    {
        public DateTime BeginningTime { get; set; }
        public DateTime EndingTime { get; set; }
        public TimeSpan Duration { get; set; }

        // One-to-Many relation: Device and Record
        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
