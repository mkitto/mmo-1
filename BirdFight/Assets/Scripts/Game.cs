﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : Singleton<Game>
{

	public enum GAME_STATUS
	{
		Ready,
		InGame,
		GameOver
	}

	private GAME_STATUS _status;

	public GAME_STATUS Status
	{
		get
        {
			return _status;
        }
		set
        {
			_status = value;
			UpdateUI();
		}
	}

	public GameObject panelReady;
	public GameObject panelInGame;
	public GameObject panelGameOver;

	public Player player;
	public int score;
	public Text uiScore;
	public Text uiBestScore;
	public Text uiRightScore;
	//public UnitManager unitManager;
	public LevelManager levelManager;
	public int currentLevelID = 1;

	public int Score
    {
		get
        {
			return score;
        }
        set
        {
			this.score = value;
			this.uiScore.text = this.score.ToString();
			this.uiRightScore.text = this.score.ToString();
			if (this.score > Convert.ToInt32(uiBestScore.text))
            {
				uiBestScore.text = this.score.ToString();
			}
        }
    }

	new void Awake()
    {
		base.Awake();
		if (PlayerPrefs.HasKey("maxScore"))
		{
			uiBestScore.text = PlayerPrefs.GetInt("maxScore").ToString();
		}
	}

	// Use this for initialization
	void Start()
	{
		this.panelReady.SetActive(true);
		player.Idle();
		player.OnDeath += Player_OnDeath;
		player.OnScore = OnPlayerScore;
	}

	void OnPlayerScore(int score)
    {
		this.Score += score;
    }

	private void Player_OnDeath()
    {
		this.Status = GAME_STATUS.GameOver;
    }


	// Update is called once per frame
	void Update()
	{

	}

	void OnDestroy()
    {
		Debug.Log("------OnDestroy");
		PlayerPrefs.SetInt("maxScore", Convert.ToInt32(uiBestScore.text));
	}

	public void StartGame()
    {
		this.Status = GAME_STATUS.InGame;
		Debug.LogFormat("StartGame: {0}", this._status);
		player.Fly();
		this.Score = 0;
		this.levelManager.LoadLevel(this.currentLevelID);
	}

	public void UpdateUI()
    {
		panelReady.SetActive(this._status == GAME_STATUS.Ready);
		panelInGame.SetActive(this._status == GAME_STATUS.InGame);
		panelGameOver.SetActive(this._status == GAME_STATUS.GameOver);
	}

	public void Restart()
    {
		this.Status = GAME_STATUS.Ready;
		player.Init();
	}
}
