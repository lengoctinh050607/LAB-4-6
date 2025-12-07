using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Email không được để trống.")]
    [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
    [RegularExpression(@"^[^@\s]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được để trống.")]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "Số điện thoại phải từ 10 đến 15 ký tự.")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Số điện thoại chỉ chứa ký tự số.")]
    public string PhoneNumber { get; set; }
}