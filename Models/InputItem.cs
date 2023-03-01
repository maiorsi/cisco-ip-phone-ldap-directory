// <copyright file="InputItem.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

namespace CiscoIpPhoneLdapDirectory.Models;

public class InputItem
{
    public string? DisplayName { get; set; }
    public string? QueryStringParam { get; set; }
    public string? InputFlags { get; set; }
    public string? DefaultValue { get; set; }
}