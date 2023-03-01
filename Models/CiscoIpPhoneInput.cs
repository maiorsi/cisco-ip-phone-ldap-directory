// <copyright file="CiscoIpPhoneInput.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using System.Xml.Serialization;

namespace CiscoIpPhoneLdapDirectory.Models;

[XmlRoot(ElementName = "CiscoIPPhoneInput")]
public class CiscoIpPhoneInput
{
    [XmlElement(Order = 1)]
    public string? Title { get; set; }

    [XmlElement(Order = 2)]
    public string? Prompt { get; set; }

    [XmlElement(Order = 3)]
    public string? URL { get; set; }

    [XmlElement(Order = 4)]
    public InputItem[] InputItem { get; set; } = Array.Empty<InputItem>();

    [XmlElement(Order = 5)]
    public SoftKeyItem[] SoftKeyItem { get; set; } = Array.Empty<SoftKeyItem>();
}