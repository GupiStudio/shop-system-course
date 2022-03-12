using UnityEngine;
using TMPro;

public class Actor : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _imageHolder;

	[SerializeField]
	private TMP_Text _nameHolder;

	public ActorData Data;

	private void Awake()
	{
		// below codes should be called somewhere else where all data load things are happening
		SetImage(Data.Image);
		SetName(Data.Name);
	}

	// this method should be called somewhere else where all data load things are happening
	private void ApplyActorData()
	{
		var act = DataManager.GetSelectedCharacter();

		SetImage(act.sprite);
		SetName(act.name);
	}

	public void SetImage(Sprite sprite)
	{
		Data.Image = sprite;
		_imageHolder.sprite = sprite;
	}

	public void SetName(string newName)
	{
		Data.Name = newName;
		_nameHolder.text = newName;
	}

	public void CollectCoin()
	{
		DataManager.AddCoins(5);

		SharedUI.instance.UpdateCoinsUITexts();
	}
}
