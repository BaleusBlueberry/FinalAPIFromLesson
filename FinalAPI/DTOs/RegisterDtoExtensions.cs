using DAL.Models;

namespace FinalAPI.DTOs;

public static class RegisterDtoExtensions
{
    public static AppUser ToUser(this RegisterDto dto)
    {
        return new AppUser()
        {
            Email = dto.Email,
            UserName = dto.Username
        };
    }
}