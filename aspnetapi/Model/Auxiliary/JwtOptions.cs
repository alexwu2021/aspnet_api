namespace aspnetapp.Model.Auxiliary;

public record class JwtOptions(
    string Issuer,
    string Audience,
    string SigningKey,
    int ExpirationSeconds
);