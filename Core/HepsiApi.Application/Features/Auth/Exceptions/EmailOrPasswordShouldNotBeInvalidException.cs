using HepsiApi.Application.Bases;

namespace HepsiApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseExceptions
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yanlıştır. ") { }
        

    }

   
}
