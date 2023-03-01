namespace CiscoIpPhoneLdapDirectory.Settings;

public class LdapSettings
{
    public string? RoomLdapQueryFormat { get; set; }
    public string? RoomLdapQueryBase { get; set; }
    public string? StaffLdapQueryFormat { get; set; }
    public string? StaffLdapQueryBase { get; set; }
    public int PageSize { get; set; }
    public int Limit { get; set; }
}
