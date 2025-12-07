using System.ComponentModel.DataAnnotations;

namespace bai3lab8.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên người dùng không được để trống.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}