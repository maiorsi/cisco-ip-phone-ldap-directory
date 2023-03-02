// <copyright file="CiscoIpPhoneError.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using System.Xml.Serialization;

namespace CiscoIpPhoneLdapDirectory.Models;

/// <summary>
/// CiscoIPPhoneError Model as per Cisco IP Phone XML Services SDK.
/// </summary>
[XmlRoot(ElementName = "CiscoIPPhoneError")]
public class CiscoIpPhoneError : CiscoIpPhoneObject
{
    /// <summary>
    /// Error code.
    /// </summary>
    [XmlAttribute("Number")]
    public int ErrorCode { get; set; }

    /// <summary>
    /// Error message.
    /// </summary>
    [XmlText]
    public string? ErrorMessage { get; set; }
}