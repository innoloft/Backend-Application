namespace ProductAPI.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(int userId);        
    }
}