// <copyright file="DirectoryEntry.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

namespace CiscoIpPhoneLdapDirectory.Models;

/// <summary>
/// Directory entry - search result.
/// </summary>
public class DirectoryEntry
{
    /// <summary>
    /// Name to display.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Telephony number.
    /// </summary>
    public string? Telephone { get; set; }
}