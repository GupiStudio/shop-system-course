using UnityEngine.SceneManagement;

public static class SceneController
{
    public const int indexMainScene = 0;

    public static void LoadMain()
    {
        SceneManager.LoadScene(indexMainScene);
    }

    public static void LoadNext()
    {
        int indexCurrentScene = SceneManager.GetActiveScene().buildIndex;

        if (indexCurrentScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indexCurrentScene + 1);
        }
    }

    public static void LoadPrevious()
    {
        int indexCurrentScene = SceneManager.GetActiveScene().buildIndex;

        if (indexCurrentScene > indexMainScene)
        {
            SceneManager.LoadScene(indexCurrentScene - 1);
        }
    }

    public static void LoadScene(int index)
    {
        if (index >= indexMainScene || index <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }
}
