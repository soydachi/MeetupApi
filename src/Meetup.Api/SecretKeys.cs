namespace Meetup.Api
{
	internal static class SecretKeys
	{
		internal const string ApiKey = "*{Secret}*";
		internal static readonly string ApiKeyUrl = $"key={ApiKey}&sign=true";
	}
}
