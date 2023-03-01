// <copyright file="BaseController.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace CiscoIpPhoneLdapDirectory.Controllers;

public class BaseController : ControllerBase
{
    public readonly string INPUT_FLAG_PLAIN_ASCII_TEXT = "A";
    public readonly string INPUT_FLAG_TELEPHONY_NUMBER = "T";
    public readonly string INPUT_FLAG_NUMERIC = "N";
    public readonly string INPUT_FLAG_UPPER_CASE = "U";
    public readonly string INPUT_FLAG_LOWER_CASE = "L";
    public readonly string SOFTKEY_BACK = "SoftKey:Back";

    /* Allowed on
    * - CiscoIPPhoneInput
    * - CiscoIPPhoneDirectory
    */
    public readonly string SOFTKEY_CANCEL = "SoftKey:Cancel";
    public readonly string SOFTKEY_EXIT = "SoftKey:Exit";

    /* Allowed on
    * - CiscoIPPhoneDirectory
    */
    public readonly string SOFTKEY_NEXT = "SoftKey:Next";
    public readonly string SOFTKEY_DIAL = "SoftKey:Dial";
    public readonly string SOFTKEY_EDIT_DIAL = "SoftKey:EditDial";

    /* Allowed on
    * - CiscoIPPhoneInput
    */
    public readonly string SOFTKEY_SEARCH = "SoftKey:Search";
    public readonly string SOFTKEY_SELECT = "SoftKey:Select";
    public readonly string SOFTKEY_SUBMIT = "SoftKey:Submit";
    public readonly string SOFTKEY_UPDATE = "SoftKey:Update";
    public readonly string SOFTKEY_LESS_THAN_LESS_THAN = "SoftKey:<<";
}