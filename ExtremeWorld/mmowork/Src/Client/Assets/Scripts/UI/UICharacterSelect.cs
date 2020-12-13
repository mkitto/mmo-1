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

	public List<GameObject> uiChars = new List<GameObject>();

	public UICharacterView CharacterView;

	// Use this for initialization
	void Start () {
		Debug.Log("------UICharacterSlect0");
		initUI();
		InitCharacterSelect(false);
		UserService.Instance.OnCharacterCreate = OnCharacterCreate;
		OnSelectCharClass(1);
		Debug.Log("------UICharacterSlect1");
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
        }
	}

	public void OnSelectCharClass(int charClass)
    {
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

		GameObject chrViewRoot = GameObject.Find("CharacterView");
		CharacterView = chrViewRoot.transform.GetComponent<UICharacterView>();

		btnWarrior.onClick.AddListener(() => { OnSelectCharClass(1); });
		btnWizard.onClick.AddListener(() => { OnSelectCharClass(2); });
		btnArch.onClick.AddListener(() => { OnSelectCharClass(3); });
		btnOK.onClick.AddListener(OnClickCreate);
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
