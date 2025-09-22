using Newtonsoft.Json;

namespace _2048ClassLibrary;

public static class UsersResultStorage
{
    private const string FileName = "UserResults.json";
    private static readonly object _lock = new();

    /// <summary>
    /// Принимает User и сохраняет снимок (ResultRecord) в файл.
    /// </summary>
    public static void Append(User user)
    {
        var record = new ResultRecord(
            user.Name,
            user.Score
            );

        lock (_lock)
        {
            var list = ReadAllInternal();
            list.Add(record);
            SaveInternal(list);
        }
    }

    /// <summary>
    /// Возвращает список всех сохранённых записей (ResultRecord).
    /// </summary>
    public static List<ResultRecord> GetUserResults()
    {
        lock (_lock)
        {
            return ReadAllInternal();
        }
    }

    /// <summary>
    /// Полезно для тестирования/очистки.
    /// </summary>
    public static void Clear()
    {
        lock (_lock)
        {
            if (FileProvider.Exists(FileName))
                FileProvider.Replace(FileName, string.Empty);
        }
    }

    #region Внутренние хелперы

    private static List<ResultRecord> ReadAllInternal()
    {
        try
        {
            if (!FileProvider.Exists(FileName))
                return [];

            string fileData = FileProvider.Get(FileName);
            if (string.IsNullOrWhiteSpace(fileData))
                return [];

            var list = JsonConvert.DeserializeObject<List<ResultRecord>>(fileData);
            return list ?? [];
        }
        catch
        {
            return [];
        }
    }

    private static void SaveInternal(List<ResultRecord> list)
    {
        string jsonData = JsonConvert.SerializeObject(list, Formatting.Indented);
        FileProvider.Replace(FileName, jsonData);
    }

    #endregion
}