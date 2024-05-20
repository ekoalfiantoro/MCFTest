using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class MsUserDto
    {
        [Key]
        [Column("user_id")] 
        public long UserId { get; set; }

        [Column("user_name")] 
        public string UserName { get; set; }

        [Column("is_active")] 
        public bool IsActive { get; set; }

        [Column("password")] 
        public string Password { get; set; }
    }
}
