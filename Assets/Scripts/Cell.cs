using UnityEngine;

public class Cell : MonoBehaviour
{
	public Sprite Visual;

	public enum CellType
	{
		Enter,
		Back,
		Empty,
		Monster,
		Key,
		HealthPotion,
		ManaPotion,
		Money,
		Item,
		Weapon,
		IncreaseAttack
	}

	public CellType Type { get; set; }


	private void OnMouseDown()
	{
		GetComponent<SpriteRenderer>().sprite = Visual;
	}

	internal void SetCellType()
	{
		if (HasChance(60, GameManager.Instance.Random))
		{
			Type = CellType.Empty;
			return;
		}
		if (HasChance(40, GameManager.Instance.Random))
		{
			Type = CellType.Monster;
			return;
		}
		if (HasChance(20, GameManager.Instance.Random))
		{
			Type = CellType.HealthPotion;
			return;
		}
		if (HasChance(10, GameManager.Instance.Random))
		{
			Type = CellType.IncreaseAttack;
			return;
		}
		if (HasChance(40, GameManager.Instance.Random))
		{
			Type = CellType.Item;
			return;
		}
		if (HasChance(20, GameManager.Instance.Random))
		{
			Type = CellType.ManaPotion;
			return;
		}
		if (HasChance(30, GameManager.Instance.Random))
		{
			Type = CellType.Weapon;
		}
		else
		{
			Type = CellType.Money;
		}
	}

	private bool HasChance(int percent, System.Random random)
	{
		int randomNumber = random.Next(1, 1000);
		return randomNumber <= percent * 10;
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
