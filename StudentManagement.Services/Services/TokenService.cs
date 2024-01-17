using Microsoft.IdentityModel.Tokens;
using StudentManagement.Services.Interfaces;
using System;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    private readonly byte[] _secretKey;

    public TokenService(byte[] secretKey)
    {
        _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
    }

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                // Add other claims as needed
            }),
            Expires = DateTime.UtcNow.AddHours(10), // Token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_secretKey),
                ValidateIssuer = false, // Set to true if you want to validate the issuer
                ValidateAudience = false, // Set to true if you want to validate the audience
                ValidateLifetime = true
            }, out _);
            return true;
        }
        catch (Exception ex)
        {
            // Handle or log the exception based on your application's requirements
            Console.WriteLine($"Token validation failed: {ex.Message}");
            return false;
        }
    }
}


