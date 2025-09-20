using Newtonsoft.Json;

namespace _2048ClassLibrary;

public static class UsersResultStorage
{
    private const string FileName = "UserResults.json";

    public static void Append(User user)
    {
        var userResults = GetUserResults();
        userResults.Add(user);
        Save(userResults);
    }

    public static List<User> GetUserResults()
    {
        if (!FileProvider.Exists(FileName))
        {
            return [];
        }

        string fileData = FileProvider.Get(FileName);
        var userResults = JsonConvert.DeserializeObject<List<User>>(fileData);
        return userResults;
    }

    private static void Save(List<User> userResults)
    {
        string jsonData = JsonConvert.SerializeObject(userResults, Formatting.Indented);
        FileProvider.Replace(FileName, jsonData);
    }
}