using UnityEngine;
public class UserSavedData : MonoBehaviour, IUserSavedData
{
    private UserData _userData;
    public UserData UserData
    {
        get => UserGameplayDataManager.Load();
        set
        {
            _userData = value;
            UserGameplayDataManager.Save(_userData);
        }
    }
}
