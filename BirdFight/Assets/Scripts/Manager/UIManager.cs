using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

	public GameObject panelReady;
	public GameObject panelInGame;
	public GameObject panelGameOver;

	public Text uiLevelName;
	public Text uiPlayerLife;
	public Text uiCurLife;
	// Use this for initialization
	void Start () {
		this.panelReady.SetActive(true);
	}

	public void UpdateLifeText(int life)
    {
		this.uiPlayerLife.text = life.ToString();
	}

	public void UpdateLevelName(string text)
    {
		this.uiLevelName.text = text;
	}

	public void UpdateLeftLife(int life)
    {
		this.uiCurLife.text = life.ToString();
	}
	
	public void UpdateUI()
    {
		panelReady.SetActive(Game.Instance.Status == Game.GAME_STATUS.Ready);
		panelInGame.SetActive(Game.Instance.Status == Game.GAME_STATUS.InGame);
		if (Game.Instance.Status == Game.GAME_STATUS.GameOver)
		{
			LevelManager.Instance.UnloadCurLevel();
		}
		panelGameOver.SetActive(Game.Instance.Status == Game.GAME_STATUS.GameOver);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
