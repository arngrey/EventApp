using System.ComponentModel.DataAnnotations;

namespace EventApp.InterfaceAdapters.RestApi.Dtos
{
    public class SignInDto
    {
        /// <summary>
        /// Задает или получает логин, указанный пользователем при регистрации.
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Задает или получает пароль, указанный пользователем при регистрации.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
