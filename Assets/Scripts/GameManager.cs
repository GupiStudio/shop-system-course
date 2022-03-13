using UnityEngine;

[RequireComponent(
    typeof(ActorManager),
    typeof(ShopManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private ActorController _actorController;

    [SerializeField]
    private int _coinWorth = 5;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        LoadSavedData();
    }

    private void Initialize()
    {
        var objectCount = FindObjectsOfType<GameManager>().Length;

        if (objectCount > 1)
        {
            Destroy(gameObject);
            return;
        }

        if (!Instance)
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void LoadSavedData()
    {
        var currentActor = ActorManager.Instance.GetSelectedActor();
        _actorController.SetData(currentActor);

        var actorManager = ActorManager.Instance;
        SharedUI.Instance.UpdateCoinsUITexts(actorManager.GetCurrentCoin());
    }

    public void CollectCoin()
	{
		var actorManager = ActorManager.Instance;

        actorManager.CollectCoin((uint)_coinWorth);

		SharedUI.Instance.UpdateCoinsUITexts(actorManager.GetCurrentCoin());
	}

    private void UpdateActorUI()
	{
		var actor = ActorManager.Instance.GetSelectedActor();

		if (actor.Image != null)
		{
            _actorController.SetImage(actor.Image);
            _actorController.SetName(actor.Name);
		}
	}
}