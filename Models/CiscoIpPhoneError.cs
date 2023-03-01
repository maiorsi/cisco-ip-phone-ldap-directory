// <copyright file="CiscoIpPhoneError.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using System.Xml.Serialization;

namespace CiscoIpPhoneLdapDirectory.Models;

[XmlRoot(ElementName = "CiscoIPPhoneError")]
public class CiscoIpPhoneError : CiscoIpPhoneObject
{
    [XmlAttribute("Number")]
    public int ErrorCode { get; set; }

    [XmlText]
    public string? ErrorMessage { get; set; }
}