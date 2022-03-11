using UnityEngine;
using TMPro;

public class Actor : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _imageHolder;

	[SerializeField]
	private TMP_Text _nameHolder;

	[HideInInspector]
	public ActorData Data;

	private void Awake()
	{
		Data = new ActorData();
		//ApplyActorData();
	}

	// this method should be called somewhere else where all data load things are happening
	private void ApplyActorData()
	{
		var act = DataManager.GetSelectedCharacter();

		SetImage(act.sprite);
		SetName(act.name);
	}

	private void OnCollisionEnter2D(Collision2D other) 
	{
		if (!other.gameObject.CompareTag("coin"))
		{
			return;
		}

		DataManager.AddCoins(5);

		SharedUI.instance.UpdateCoinsUITexts();

		Destroy(other.gameObject);
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
}
