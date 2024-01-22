using HepsiApi.Application.Bases;

namespace HepsiApi.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir") { }

    }





}
