// <copyright file="CiscoIpPhoneDirectory.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using System.Xml.Serialization;

namespace CiscoIpPhoneLdapDirectory.Models;

[XmlRoot(ElementName = "CiscoIPPhoneDirectory")]
public class CiscoIpPhoneDirectory : CiscoIpPhoneObject
{
    [XmlElement(Order = 1)]
    public string? Title { get; set; }

    [XmlElement(Order = 2)]
    public string? Prompt { get; set; }

    [XmlElement(Order = 3)]
    public DirectoryEntry[] DirectoryEntry { get; set; } = Array.Empty<DirectoryEntry>();

    [XmlElement(Order = 4)]
    public SoftKeyItem[] SoftKeyItem { get; set; } = Array.Empty<SoftKeyItem>();
}