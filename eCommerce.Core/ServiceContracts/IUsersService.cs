using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUsersService
    {
        // LOGIN METHOD 
        Task<AuthenticationResponse?> Login (LoginRequest loginRequest);
    
        Task<AuthenticationResponse?> Register (RegisterRequest registerRequest);
    }
}
