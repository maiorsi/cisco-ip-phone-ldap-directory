// <copyright file="CiscoIpPhoneDirectory.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using System.Xml.Serialization;

namespace CiscoIpPhoneLdapDirectory.Models;

/// <summary>
/// CiscoIPPhoneDirectory Model as per Cisco IP Phone XML Services SDK.
/// </summary>
[XmlRoot(ElementName = "CiscoIPPhoneDirectory")]
public class CiscoIpPhoneDirectory : CiscoIpPhoneObject
{
    /// <summary>
    /// Screen title.
    /// </summary>
    [XmlElement(Order = 1)]
    public string? Title { get; set; }

    /// <summary>
    /// Screen prompt.
    /// </summary>
    [XmlElement(Order = 2)]
    public string? Prompt { get; set; }

    /// <summary>
    /// Directory entries (Search Results).
    /// </summary>
    [XmlElement(Order = 3)]
    public DirectoryEntry[] DirectoryEntry { get; set; } = Array.Empty<DirectoryEntry>();

    /// <summary>
    /// Soft keys (on-screen) to display.
    /// </summary>
    [XmlElement(Order = 4)]
    public SoftKeyItem[] SoftKeyItem { get; set; } = Array.Empty<SoftKeyItem>();
}