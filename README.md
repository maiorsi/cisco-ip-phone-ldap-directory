# Cisco IP Phone LDAP Directory
DotNet Cisco IP Phone LDAP Directory XML API

This web api provides LDAP searching via Cisco IP Phone XML Services.

See [Cisco Unified IP Phone Services Application Development Notes, Release 7.1(2)](https://www.cisco.com/c/en/us/td/docs/voice_ip_comm/cuipph/all_models/xsi/7_1_2/english/programming/guide/712xsi/xsi712ovr.html)

It uses the [directory-services](https://github.com/maiorsi/directory-services) project for an LDAP wrapper.

## Getting Started

### Installation

Use the DotNet CLI package manager [dotnet](https://learn.microsoft.com/en-us/dotnet/core/tools/) to build the project.

```bash
dotnet restore
dotnet build
```

### Usage

#### App Settings
```json
{
    "Ldap": {
        "BindDistinguishedName": "DN here",
        "BindPassword": "Password here",
        "DefaultLdapUsersSearchBase": "DN search base here",
        "DefaultLdapGroupsSearchBase": "DN search base here",
        "DistinguishedNameEscapeCharactersString": "\\,:\\5C\\2C|\\*:\\5C\\2A|\\(:\\5C\\28|\\):\\5C\\29|\\\\:\\5C\\5C",
        "Domain": "local",
        "LdapConnectionFallback": "LDAP://ldap.local.domain",
        "LdapConnectionOverride": "",
        "LdapConnectionUrl": "ldap.local.domain",
        "LdapFollowReferrals": true,
        "LdapKerberosBind": false,
        "LdapSecure": false
    }
}
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
