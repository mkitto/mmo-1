using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
using Services;
using SkillBridge.Message;


public class UICharacterSelect : MonoBehaviour {

	public GameObject panelCreate;
	public GameObject panelSelect;

	CharacterClass charClass;

	private Image[] titles = new Image[3];
	public Text desc; 
	private Text[] names = new Text[3];

	public Text charName;

	public Button btnWarrior;
	public Button btnWizard;
	public Button btnArch;

	public Button btnOK;
	public Button btnPlay;
	public Button btnNew;

	public List<GameObject> uiChars = new List<GameObject>();

	public UICharacterView CharacterView;

	public GameObject uiCharInfo;
	public Transform uiCharList;

	private int selectCharacterIdx = -1;

	// Use this for initialization
	void Start () {
		initUI();
		InitCharacterSelect(true);
		UserService.Instance.OnCharacterCreate = OnCharacterCreate;
		OnSelectCharClass(1);
	}

	public void InitCharacterSelect(bool init)
    {
		panelCreate.SetActive(!init);
		panelSelect.SetActive(init);

		if (init)
        {
			foreach (var old in uiChars)
            {
				Destroy(old);
            }
			uiChars.Clear();

			Debug.LogFormat("Character count: {0}", User.Instance.Info.Player.Characters.Count);

			for(int i = 0; i < User.Instance.Info.Player.Characters.Count; ++i)
            {
				GameObject go = Instantiate(uiCharInfo, this.uiCharList);
				UICharInfo chrInfo = go.GetComponent<UICharInfo>();
				chrInfo.info = User.Instance.Info.Player.Characters[i];

				Button button = go.GetComponent<Button>();
				int idx = i;
				button.onClick.AddListener(() =>
				{
					OnSelectCharacter(idx);
				});

				uiChars.Add(go);
				go.SetActive(true);
            }				
        }
	}

	public void OnSelectCharacter(int idx)
    {
		this.selectCharacterIdx = idx;
		var cha = User.Instance.Info.Player.Characters[idx];
		Debug.LogFormat("Select Char:[{0}]{1}[{2}]", cha.Id, cha.Name, cha.Class);
		User.Instance.CurrentCharacter = cha;
		CharacterView.CurrentCharacter = ((int)cha.Class - 1);

		for(int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
        {
			UICharInfo ci = this.uiChars[i].GetComponent<UICharInfo>();
			ci.Selected = idx == i;
        }
    }

	public void OnClickPlay()
    {
		Debug.LogFormat("------OnClickPlay: {0}", selectCharacterIdx);
		if(selectCharacterIdx >= 0)
        {
			UserService.Instance.SendGameEnter(selectCharacterIdx);
        }
    }

	public void OnClickNew()
	{
		Debug.Log("------OnClickNew");
		this.InitCharacterSelect(false);
	}

	public void OnSelectCharClass(int charClass)
    {
		Debug.LogFormat("------OnSelectCharClass", charClass);
		this.charClass = (CharacterClass)charClass;
		CharacterView.CurrentCharacter = charClass - 1;
		for (int i = 0; i < 3; ++i)
        {
			titles[i].gameObject.SetActive(i == charClass - 1);
			names[i].text = DataManager.Instance.Characters[i+1].Name;
        }
		desc.text = DataManager.Instance.Characters[charClass].Description;
    }

	public void OnClickCreate()
    {
		if(string.IsNullOrEmpty(this.charName.text))
        {
			MessageBox.Show("请输入角色名称");
			return;
        }

		Debug.LogFormat("------OnClickCreate{0}", this.charClass);

		UserService.Instance.SendCharacterCreate(this.charName.text, this.charClass);
    }

	void initUI()
    {
		GameObject root = GameObject.Find("UICharacterSelect");
		panelCreate = root.transform.Find("PanelCreate").gameObject;
		panelSelect = root.transform.Find("PanelSelect").gameObject;
		titles[0] = root.transform.Find("PanelCreate/Titles/Warrior").GetComponent<Image>();
		titles[1] = root.transform.Find("PanelCreate/Titles/Wizard").GetComponent<Image>();
		titles[2] = root.transform.Find("PanelCreate/Titles/Arch").GetComponent<Image>();
		names[0] = root.transform.Find("PanelCreate/BtnWarrior/Text").GetComponent<Text>();
		names[1] = root.transform.Find("PanelCreate/BtnWizard/Text").GetComponent<Text>();
		names[2] = root.transform.Find("PanelCreate/BtnArch/Text").GetComponent<Text>();
		desc = root.transform.Find("PanelCreate/ImageDesc/Text").GetComponent<Text>();
		btnWarrior = root.transform.Find("PanelCreate/BtnWarrior").GetComponent<Button>();
		btnWizard = root.transform.Find("PanelCreate/BtnWizard").GetComponent<Button>();
		btnArch = root.transform.Find("PanelCreate/BtnArch").GetComponent<Button>();
		charName = root.transform.Find("PanelCreate/InputField/Text").GetComponent<Text>();
		btnOK = root.transform.Find("PanelCreate/ButtonOK").GetComponent<Button>();
		btnPlay = root.transform.Find("PanelSelect/ButtonPlay").GetComponent<Button>();
		btnNew = root.transform.Find("PanelSelect/ButtonNew").GetComponent<Button>();
		uiCharList = root.transform.Find("PanelSelect/ScrollView/Viewport/Content").transform;
		uiCharInfo = root.transform.Find("PanelSelect/ScrollView/Viewport/Content/CharInfo").gameObject;


		GameObject chrViewRoot = GameObject.Find("CharacterView");
		CharacterView = chrViewRoot.transform.GetComponent<UICharacterView>();

		btnWarrior.onClick.AddListener(() => { OnSelectCharClass(1); });
		btnWizard.onClick.AddListener(() => { OnSelectCharClass(2); });
		btnArch.onClick.AddListener(() => { OnSelectCharClass(3); });
		btnOK.onClick.AddListener(OnClickCreate);
		btnPlay.onClick.AddListener(OnClickPlay);
		btnNew.onClick.AddListener(OnClickNew);
	}

	void OnCharacterCreate(Result result, string message)
    {
		if (result == Result.Success)
        {
			InitCharacterSelect(true);
        }
        else
        {
			MessageBox.Show(message, "错误", MessageBoxType.Error);
        }
    }
}
