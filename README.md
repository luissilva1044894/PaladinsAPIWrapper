# PaladinsAPIWrapper
**PaladinsAPIWrapper** is C#-based wrapper for *[Paladins](https://www.paladins.com)*.

## Example

```csharp

var paladinsAPI = new PaladinsAPI.PaladinsAPI ("YOUR_DEV_ID", "YOUR_AUTH_KEY", PaladinsAPI.Enums.Platform.PC, PaladinsAPI.Enums.ResponseFormat.JSON, PaladinsAPI.Enums.eLanguageCode.Portuguese);
var championsRank = paladinsAPI.GetChampionRanks ("FeyRazzle");

foreach (championRank in championsRank) {
  System.Console.WriteLine (championRank.toString ())
}
```

This example will print the winrate with every [Champions](https://www.paladins.com/champions) of player **[FeyRazzle](https://twitch.tv/FeyRazzle "FeyRazzle")**.
