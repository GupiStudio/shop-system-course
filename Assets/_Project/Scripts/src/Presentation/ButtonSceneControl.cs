using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneControl : MonoBehaviour
{
    enum TargetScene
    {
        MainMenu,
        PreviousLevel,
        NextLevel
    }

    [SerializeField]
    TargetScene targetScene;

    private Button button;

    private void Awake() 
    {
        button = GetComponent<Button>();

        button.onClick.RemoveAllListeners();

        switch(targetScene)
        {
            case TargetScene.MainMenu:
                button.onClick.AddListener(() => SceneController.LoadMain());
                break;
            case TargetScene.PreviousLevel:
                button.onClick.AddListener(() => SceneController.LoadPrevious());
                break;
            case TargetScene.NextLevel:
                button.onClick.AddListener(() => SceneController.LoadNext());
                break;
            default:
                break;
        }
    }
}
