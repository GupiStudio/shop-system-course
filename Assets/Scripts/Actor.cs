using UnityEngine;
using TMPro;

public class Actor : MonoBehaviour
{
	public float speed = 1f;

	[SerializeField]
	private SpriteRenderer _playerImage;

	[SerializeField]
	private TMP_Text _playerName;

	private Rigidbody2D rigidbody;

	private float x;
	private float y;
	
	private bool moving = false;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();

		ApplyActorData();
	}

	private void Update()
	{
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		moving = (x != 0 || y != 0);
	}

	private void ApplyActorData()
	{
		var act = DataManager.GetSelectedCharacter();

		_playerName.text = act.name;
		_playerImage.sprite = act.sprite;
	}

	private void FixedUpdate() 
	{
		if (!moving)
		{
			return;
		}

		rigidbody.position += new Vector2(x, y) * speed * Time.fixedDeltaTime;
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
}
