// <copyright file="RoomController.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using CiscoIpPhoneLdapDirectory.Models;
using CiscoIpPhoneLdapDirectory.Settings;

using DirectoryServices.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CiscoIpPhoneLdapDirectory.Controllers;

[ApiController]
[Route("directory/room")]
public class RoomController : BaseController
{
    private readonly ILogger<RoomController> _logger;
    private readonly LdapSettings _ldapSettings;
    private readonly IDirectoryService _directoryService;

    public RoomController(ILogger<RoomController> logger, IOptions<LdapSettings> ldapSettings, IDirectoryService directoryService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _ldapSettings = ldapSettings.Value ?? throw new ArgumentNullException(nameof(ldapSettings));
        _directoryService = directoryService ?? throw new ArgumentNullException(nameof(directoryService));
    }

    [HttpGet]
    [ProducesResponseType(typeof(CiscoIpPhoneInput), StatusCodes.Status200OK)]
    public CiscoIpPhoneInput Get()
    {
        return new CiscoIpPhoneInput
        {
            Title = "Room Directory",
            Prompt = "Enter search parameters...",
            URL = Url.ActionLink("list", "room"),
            InputItem = new InputItem[]
            {
                new InputItem
                {
                    DisplayName = "Name",
                    QueryStringParam = "n",
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

    [HttpGet("list")]
    [ProducesResponseType(typeof(CiscoIpPhoneDirectory), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CiscoIpPhoneError), StatusCodes.Status500InternalServerError)]
    public CiscoIpPhoneObject List([FromQuery] string n = "", [FromQuery] int page = 1, [FromQuery] string searchparam = "")
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
                Title = "Room Search Results",
                Prompt = "Select a Room..."
            };

            if (!string.IsNullOrEmpty(searchparam))
            {
                directory.Title = $"{searchparam} Search";
            }

            var ldapQuery = string.Format(_ldapSettings.RoomLdapQueryFormat!, n).Replace("**", "*");

            var results = _directoryService.SearchUsersByLdapQuery(ldapQuery, page, _ldapSettings.PageSize, _ldapSettings.RoomLdapQueryBase).OrderBy(_ => _.Username);

            foreach (var result in results)
            {
                directoryEntries.Enqueue(new DirectoryEntry
                {
                    Name = result.DisplayName,
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
                    Response.Headers.Add("Refresh", $"0;url={Url.ActionLink("list", "room")}?page={page + 1}&n={n}&searchparam={searchparam}");

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
                    URL = $"{Url.ActionLink("list", "room")}?page={page - 1}&n={n}&searchparam={searchparam}",
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