// <copyright file="BaseController.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>
#pragma warning disable 1591

using Microsoft.AspNetCore.Mvc;

namespace CiscoIpPhoneLdapDirectory.Controllers;

/// <summary>
/// Abstract class with common constants (readonly strings)
/// </summary>
public abstract class BaseController : ControllerBase
{
    protected readonly string INPUT_FLAG_PLAIN_ASCII_TEXT = "A";
    protected readonly string INPUT_FLAG_TELEPHONY_NUMBER = "T";
    protected readonly string INPUT_FLAG_NUMERIC = "N";
    protected readonly string INPUT_FLAG_UPPER_CASE = "U";
    protected readonly string INPUT_FLAG_LOWER_CASE = "L";
    protected readonly string SOFTKEY_BACK = "SoftKey:Back";

    /* Allowed on
    * - CiscoIPPhoneInput
    * - CiscoIPPhoneDirectory
    */
    protected readonly string SOFTKEY_CANCEL = "SoftKey:Cancel";
    protected readonly string SOFTKEY_EXIT = "SoftKey:Exit";

    /* Allowed on
    * - CiscoIPPhoneDirectory
    */
    protected readonly string SOFTKEY_NEXT = "SoftKey:Next";
    protected readonly string SOFTKEY_DIAL = "SoftKey:Dial";
    protected readonly string SOFTKEY_EDIT_DIAL = "SoftKey:EditDial";

    /* Allowed on
    * - CiscoIPPhoneInput
    */
    protected readonly string SOFTKEY_SEARCH = "SoftKey:Search";
    protected readonly string SOFTKEY_SELECT = "SoftKey:Select";
    protected readonly string SOFTKEY_SUBMIT = "SoftKey:Submit";
    protected readonly string SOFTKEY_UPDATE = "SoftKey:Update";
    protected readonly string SOFTKEY_LESS_THAN_LESS_THAN = "SoftKey:<<";
}