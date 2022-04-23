using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private ShopUI _shopUI;

    private const int IndexMainScene = 0;

    private void Awake()
    {
        if (_shopUI)
            _shopUI.gameObject.SetActive(false);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(IndexMainScene);
    }

    public void LoadNext()
    {
        var indexCurrentScene = SceneManager.GetActiveScene().buildIndex;

        if (indexCurrentScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indexCurrentScene + 1);
        }
    }

    public void LoadPrevious()
    {
        var indexCurrentScene = SceneManager.GetActiveScene().buildIndex;

        if (indexCurrentScene > IndexMainScene)
        {
            SceneManager.LoadScene(indexCurrentScene - 1);
        }
    }

    public void LoadScene(int index)
    {
        if (index >= IndexMainScene || index <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }

    public void OpenShop()
    {
        var index = SceneManager.GetActiveScene().buildIndex;

        if (index != IndexMainScene)
            return;

        if (!_shopUI) return;

        if (_shopUI.gameObject.activeSelf)
            return;

        _shopUI.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        var index = SceneManager.GetActiveScene().buildIndex;

        if (index != IndexMainScene)
            return;

        if (!_shopUI) return;

        if (!_shopUI.gameObject.activeSelf)
            return;

        _shopUI.gameObject.SetActive(false);
    }
}
