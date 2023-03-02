// <copyright file="LdapSettings.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

namespace CiscoIpPhoneLdapDirectory.Settings;

/// <summary>
/// Settings (configuration) for this application.
/// </summary>
public class LdapSettings
{
    /// <summary>
    /// A c# format string for the room LDAP query.
    /// </summary>
    public string? RoomLdapQueryFormat { get; set; }

    /// <summary>
    /// The search base for the room query.
    /// </summary>
    public string? RoomLdapQueryBase { get; set; }

    /// <summary>
    /// A c# format string for the staff LDAP query.
    /// </summary>
    public string? StaffLdapQueryFormat { get; set; }

    /// <summary>
    /// The search base for the staff query.
    /// </summary>
    public string? StaffLdapQueryBase { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Limit - for AD this is 1000.
    /// </summary>
    public int Limit { get; set; }
}