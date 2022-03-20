using UnityEngine;
using TMPro;
using Gupi2D.TopDownGame;

[RequireComponent(typeof(ActorMovementController))]
public class ActorController : MonoBehaviour
{
    [SerializeField]
	private SpriteRenderer _imageHolder;

	[SerializeField]
	private TMP_Text _nameHolder;

	[HideInInspector]
	public ActorData Data;

	[SerializeField]
	private ActorMovementController _movementController;

	public void SetData(ActorData actorData)
	{
		SetImage(actorData.Image);
		SetName(actorData.Name);
		SetSpeed((uint)actorData.Speed);
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

	public void SetSpeed(uint amount)
	{
		_movementController.Speed = amount;
	}
}
