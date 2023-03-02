// <copyright file="SoftKeyItem.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

namespace CiscoIpPhoneLdapDirectory.Models;

/// <summary>
/// Soft Key (on-screen) Item as per Cisco IP Phone XML Services SDK.
/// </summary>
public class SoftKeyItem
{
    /// <summary>
    /// Position (index) on screen.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// URL.
    /// </summary>
    public string? URL { get; set; }
}