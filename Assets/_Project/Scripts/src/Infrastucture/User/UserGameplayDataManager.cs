public class UserGameplayDataManager
{
    private const string GameplayDataFileName = "gameplay-data.txt";

    public static UserData Load()
    {
        return BinarySerializer.Load<UserData>(GameplayDataFileName);
    }

    public static void Save(UserData userData)
    {
        BinarySerializer.Save<UserData>(userData, GameplayDataFileName);
    }
}