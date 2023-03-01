// <copyright file="UrlHelperExtensions.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace CiscoIpPhoneLdapDirectory.Extensions;

public static class UrlHelperExtensions
{
    public static string? AbsoluteAction(this IUrlHelper url, string? actionName, string? controllerName, object? routeValues = null) => url.Action(actionName, controllerName, routeValues, url.ActionContext.HttpContext.Request.Scheme);
}