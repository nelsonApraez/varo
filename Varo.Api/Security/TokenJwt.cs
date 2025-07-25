namespace Varo.Api.Security
{
    using Varo.Transversales;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Globalization;
    using System.Security.Claims;

    internal static class TokenJwt
    {
        public static string Generar(string usuario)
        {
            // appsetting for Token JWT
            var secretKey = ParametrosGenerales.JWT_SECRET_KEY;
            var audienceToken = ParametrosGenerales.JWT_AUDIENCE_TOKEN;
            var issuerToken = ParametrosGenerales.JWT_ISSUER_TOKEN;
            var expireTime = ParametrosGenerales.JWT_EXPIRE_MINUTES;

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario) });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime, CultureInfo.CurrentCulture)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
