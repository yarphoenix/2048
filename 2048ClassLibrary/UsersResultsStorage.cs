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
        // Создаём снимок текущего состояния User
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

            // Пытаемся десериализовать как List<ResultRecord>
            var list = JsonConvert.DeserializeObject<List<ResultRecord>>(fileData);
            if (list != null) return list;

            //// На случай, если старый файл хранил List<User>, попробуем десериализовать как List<User>
            //var oldList = JsonConvert.DeserializeObject<List<User>>(fileData);
            //if (oldList != null)
            //{
            //    // Мигрируем старые записи в новый формат
            //    var migrated = oldList.Select(u =>
            //        new ResultRecord(
            //            playerName: string.IsNullOrEmpty(u.Name) ? "Anonymous" : u.Name,
            //            score: u.Score,
            //            timestamp: DateTime.UtcNow)
            //    ).ToList();

            //    // Сохраним мигрированный список в новом формате
            //    SaveInternal(migrated);
            //    return migrated;
            //}

            //// Если десериализация не удалась — вернём пустой список
            return [];
        }
        catch
        {
            // В случае ошибок чтения/парсинга — вернём пустой список (без бросания исключений)
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