// <copyright file="CiscoIpPhoneInput.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using System.Xml.Serialization;

namespace CiscoIpPhoneLdapDirectory.Models;

/// <summary>
/// CiscoIPPhoneInput Model as per Cisco IP Phone XML Services SDK.
/// </summary>
[XmlRoot(ElementName = "CiscoIPPhoneInput")]
public class CiscoIpPhoneInput
{
    /// <summary>
    /// Screen Title.
    /// </summary>
    [XmlElement(Order = 1)]
    public string? Title { get; set; }

    /// <summary>
    /// Screen Prompt.
    /// </summary>
    [XmlElement(Order = 2)]
    public string? Prompt { get; set; }

    /// <summary>
    /// URL.
    /// </summary>
    [XmlElement(Order = 3)]
    public string? URL { get; set; }

    /// <summary>
    /// List of Input Items.
    /// </summary>
    [XmlElement(Order = 4)]
    public InputItem[] InputItem { get; set; } = Array.Empty<InputItem>();

    /// <summary>
    /// Soft keys (on-screen) to display.
    /// </summary>
    [XmlElement(Order = 5)]
    public SoftKeyItem[] SoftKeyItem { get; set; } = Array.Empty<SoftKeyItem>();
}