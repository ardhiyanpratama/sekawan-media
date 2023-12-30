using System.Linq;

#nullable enable
namespace CustomLibrary.Helper
{
    public class UriHelper
    {
        public static string? GetValueFromQuery(string requestUrl, string key)
        {
            var query = requestUrl.Substring(requestUrl.IndexOf('?')).ToLower();
            var queryValues = query.Split('&')
                .Select(q => q.Split('='))
                .ToDictionary(k => k[0], v => v[1]);

            if (queryValues.TryGetValue(key, out string? value))
            {
                return value;
            }
            return null;
        }
    }
}
