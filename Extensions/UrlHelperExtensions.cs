// <copyright file="UrlHelperExtensions.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace CiscoIpPhoneLdapDirectory.Extensions;

/// <summary>
/// URL Helper Extensions class
/// </summary>
public static class UrlHelperExtensions
{
    /// <summary>
    /// [DEPRECATED] - don't think this is used.
    /// </summary>
    /// <param name="url">Url Hlper</param>
    /// <param name="actionName">Action (route) name</param>
    /// <param name="controllerName">Controller name</param>
    /// <param name="routeValues">Arbitrary route values</param>
    /// <returns></returns>
    public static string? AbsoluteAction(this IUrlHelper url, string? actionName, string? controllerName, object? routeValues = null) => url.Action(actionName, controllerName, routeValues, url.ActionContext.HttpContext.Request.Scheme);
}