using System.ComponentModel.DataAnnotations.Schema;
using GNIT.Domain.EntityBase;

namespace GNIT.Domain.User
{
    [Table("Corporate_Customer_Tbl")]
    public class Corporate : Entity
    {
        public string CustomerName { get; set; }
        public DateTime MeetingTime { get; set; }
        public string MeetingPlace { get; set; }
        public string Attend { get; set; }
        public string MeetingAgenda { get; set; }
        public string MeetingDiscussion { get; set; }
        public string MeetingDecision { get; set; }
    }
}
