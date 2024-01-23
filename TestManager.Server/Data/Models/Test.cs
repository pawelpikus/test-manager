using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TestManager.Server.Data.Models
{
    public class Test
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50), Column(TypeName = "nvarchar(50)")]
        public string FwVersion { get; set; } = string.Empty;

        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string RackName { get; set; } = string.Empty;

        [MaxLength(300), Column(TypeName = "nvarchar(300)")]
        public string Title { get; set; } = "Title";

        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string Status { get; set; } = "Status";

        [AllowNull]
        public DateTime KickOffTimeStamp { get; set; } = DateTime.Now;
        [AllowNull]
        public DateTime LastModifiedTimeStamp { get; set;} = DateTime.Now;
        
        [MaxLength(10), Column(TypeName = "nvarchar(10)")]
        public string Time { get; set; } = "12:30";


    }
}
