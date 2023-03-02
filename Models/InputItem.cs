// <copyright file="InputItem.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

namespace CiscoIpPhoneLdapDirectory.Models;

/// <summary>
/// Input item as per Cisco IP Phone XML Services SDK.
/// </summary>
public class InputItem
{
    /// <summary>
    /// Display name.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// Query string paramater.
    /// </summary>
    public string? QueryStringParam { get; set; }

    /// <summary>
    /// Input flags.
    /// </summary>
    public string? InputFlags { get; set; }

    /// <summary>
    /// Default value.
    /// </summary>
    public string? DefaultValue { get; set; }
}