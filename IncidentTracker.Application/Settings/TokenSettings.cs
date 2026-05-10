namespace IncidentTracker.Application.Settings;
public class TokenSettings {
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string IssuerSigningKey { get; set; }
    public int LifeTime { get; set; }
}
