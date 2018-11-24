using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Board Board;

	public Player Player;

	public static GameManager Instance { get; private set; }

	public System.Random Random = new System.Random();

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	// Use this for initialization
	void Start()
	{
		Board.InitializeBoard();
		Player = new Player{Health = new Health{Value = 100}};
	}

	// Update is called once per frame
	void Update()
	{

	}
}
