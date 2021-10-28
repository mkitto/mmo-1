using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterView : MonoBehaviour {

	public GameObject[] Characters = new GameObject[3];

	private int currentCharacter = 0;

	public int CurrentCharacter
    {
        get
        {
			return currentCharacter;
        }
        set
        {
			currentCharacter = value;
			this.UpdateCharacter();
        }
    }
	// Use this for initialization
	void Start () {
		initUI();
		// 如果有角色，默认选中第一个
		if (User.Instance.Info.Player.Characters.Count>0)
        {
			CurrentCharacter = User.Instance.Info.Player.Characters[0].ConfigId;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void initUI()
    {
		GameObject root = GameObject.Find("CharacterView");
		Characters[0] = root.transform.Find("Root/Warrior").gameObject;
		Characters[1] = root.transform.Find("Root/Wizard").gameObject;
		Characters[2] = root.transform.Find("Root/Archer").gameObject;
	}

	void UpdateCharacter()
    {
		for (int i = 0; i < 3; i++)
        {
			Characters[i].SetActive(i == this.currentCharacter);
        }
    }
}
