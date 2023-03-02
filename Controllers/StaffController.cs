// <copyright file="StaffController.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using CiscoIpPhoneLdapDirectory.Models;
using CiscoIpPhoneLdapDirectory.Settings;

using DirectoryServices.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CiscoIpPhoneLdapDirectory.Controllers;

/// <summary>
/// Controller for /staff api endpoints.
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class StaffController : BaseController
{
    private readonly ILogger<StaffController> _logger;
    private readonly LdapSettings _ldapSettings;
    private readonly IDirectoryService _directoryService;

    /// <summary>
    /// Standard constructor.
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="ldapSettings">LDAP Settings</param>
    /// <param name="directoryService">DI - Directory Service</param>
    /// <exception cref="ArgumentNullException">Exception thrown if any argument is null</exception>
    public StaffController(ILogger<StaffController> logger, IOptions<LdapSettings> ldapSettings, IDirectoryService directoryService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _ldapSettings = ldapSettings.Value ?? throw new ArgumentNullException(nameof(ldapSettings));
        _directoryService = directoryService ?? throw new ArgumentNullException(nameof(directoryService));
    }

    /// <summary>
    /// Return the XML for the start search screen.
    /// </summary>
    /// <returns>CiscoIpPhoneInput</returns>
    [HttpGet]
    [ProducesResponseType(typeof(CiscoIpPhoneInput), StatusCodes.Status200OK)]
    public CiscoIpPhoneInput Get()
    {
        return new CiscoIpPhoneInput
        {
            Title = "Staff Directory",
            Prompt = "Enter search parameters...",
            URL = Url.ActionLink("list", "staff"),
            InputItem = new InputItem[]
            {
                new InputItem
                {
                    DisplayName = "First Name",
                    QueryStringParam = "f",
                    InputFlags = INPUT_FLAG_PLAIN_ASCII_TEXT,
                    DefaultValue = string.Empty
                },
                new InputItem
                {
                    DisplayName = "Last Name",
                    QueryStringParam = "l",
                    InputFlags = INPUT_FLAG_PLAIN_ASCII_TEXT,
                    DefaultValue = string.Empty
                },
                new InputItem
                {
                    DisplayName = "Title",
                    QueryStringParam = "tl",
                    InputFlags = INPUT_FLAG_PLAIN_ASCII_TEXT,
                    DefaultValue = string.Empty
                },
                new InputItem
                {
                    DisplayName = "Telephone Number",
                    QueryStringParam = "t",
                    InputFlags = INPUT_FLAG_PLAIN_ASCII_TEXT,
                    DefaultValue = string.Empty
                }
            },
            SoftKeyItem = new SoftKeyItem[]
            {
                new SoftKeyItem
                {
                    Position = 1,
                    Name = "Search",
                    URL = SOFTKEY_SUBMIT
                },
                new SoftKeyItem
                {
                    Position = 2,
                    Name = "<<",
                    URL = SOFTKEY_LESS_THAN_LESS_THAN
                },
                new SoftKeyItem
                {
                    Position = 3,
                    Name = "Cancel",
                    URL = SOFTKEY_CANCEL
                }
            }
        };
    }

    /// <summary>
    /// List (search) for room objects.
    /// </summary>
    /// <param name="f">First name query</param>
    /// <param name="l">Last name query</param>
    /// <param name="tl">Title query</param>
    /// <param name="t">Telephony number query</param>
    /// <param name="page">Page Number</param>
    /// <param name="searchparam">Search Parameter</param>
    /// <returns></returns>
    [HttpGet("list")]
    [ProducesResponseType(typeof(CiscoIpPhoneDirectory), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CiscoIpPhoneError), StatusCodes.Status500InternalServerError)]
    public CiscoIpPhoneObject List([FromQuery] string f = "", [FromQuery] string l = "", [FromQuery] string tl = "", [FromQuery] string t = "", [FromQuery] int page = 1, [FromQuery] string searchparam = "")
    {
        try
        {
            var dialButtonIndex = 1;
            var nextButtonIndex = 2;
            var prevButtonIndex = 2;
            var cancelButtonIndex = 3;
            var directoryEntries = new Queue<DirectoryEntry>();
            var softKeyItems = new Queue<SoftKeyItem>();

            var directory = new CiscoIpPhoneDirectory
            {
                Title = "Staff Search Results",
                Prompt = "Select a Staff Member..."
            };

            if (!string.IsNullOrEmpty(searchparam))
            {
                directory.Title = $"{searchparam} Search";
            }

            var ldapQuery = string.Format(_ldapSettings.StaffLdapQueryFormat!, f, l, tl, t).Replace("**", "*");

            var results = _directoryService.SearchUsersByLdapQuery(ldapQuery, page, _ldapSettings.PageSize, _ldapSettings.RoomLdapQueryBase).OrderBy(_ => _.Username);

            foreach (var result in results)
            {
                directoryEntries.Enqueue(new DirectoryEntry
                {
                    Name = $"{result.FirstName} {result.LastName?.Substring(0, 1)}",
                    Telephone = result.Phone
                });
            }

            softKeyItems.Enqueue(new SoftKeyItem
            {
                Name = "Dial",
                URL = SOFTKEY_DIAL,
                Position = dialButtonIndex
            });

            if (results.Any())
            {
                if (((page + 1) * _ldapSettings.PageSize) < _ldapSettings.Limit && results.Count() == _ldapSettings.PageSize)
                {
                    Response.Headers.Add("Refresh", $"0;url={Url.ActionLink("list", "staff")}?page={page + 1}&f={f}&l={l}&tl={tl}&t={t}&searchparam={searchparam}");

                    softKeyItems.Enqueue(new SoftKeyItem
                    {
                        Name = "Next",
                        URL = SOFTKEY_NEXT,
                        Position = nextButtonIndex
                    });
                }
            }

            if (page > 0)
            {
                prevButtonIndex = 3;
                cancelButtonIndex = 4;

                softKeyItems.Enqueue(new SoftKeyItem
                {
                    Name = "Prev",
                    URL = $"{Url.ActionLink("list", "staff")}?page={page - 1}&f={f}&l={l}&tl={tl}&t={t}&searchparam={searchparam}",
                    Position = prevButtonIndex
                });
            }

            softKeyItems.Enqueue(new SoftKeyItem
            {
                Name = "Cancel",
                URL = SOFTKEY_CANCEL,
                Position = cancelButtonIndex
            });

            directory.DirectoryEntry = directoryEntries.ToArray();
            directory.SoftKeyItem = softKeyItems.ToArray();

            return directory;
        }
        catch (Exception exception)
        {
            return new CiscoIpPhoneError
            {
                ErrorCode = StatusCodes.Status500InternalServerError,
                ErrorMessage = exception.Message
            };
        }
    }
}