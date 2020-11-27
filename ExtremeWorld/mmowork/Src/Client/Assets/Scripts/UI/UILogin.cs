using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillBridge.Message;

public class UILogin : MonoBehaviour {

	public InputField username;
	public InputField password;
	public Button buttonLogin;

	// Use this for initialization
	void Start () {
		initUI();
		UserService.Instance.OnLogin = this.OnLogin;
	}

	void OnLogin(Result result, string msg)
	{
		if(result == Result.Success)
        {
			MessageBox.Show(msg, "成功", MessageBoxType.Information);
        }
		else
        {
			MessageBox.Show(msg, "错误", MessageBoxType.Error);
		}
	}

	void initUI()
	{
		GameObject root = GameObject.Find("LoginPanel");
		username = root.transform.Find("InputUsername").GetComponent<InputField>();
		password = root.transform.Find("InputPassword").GetComponent<InputField>();
		buttonLogin = root.transform.Find("BtnLogin").GetComponent<Button>();
		buttonLogin.onClick.AddListener(OnClickLogin);
	}

    private void OnClickLogin()
    {
		// 判空
		if (string.IsNullOrEmpty(this.username.text))
		{
			MessageBox.Show("请输入账号");
        }
		if (string.IsNullOrEmpty(this.password.text))
		{
			MessageBox.Show("请输入密码");
		}

		UserService.Instance.SendLogin(this.username.text, this.password.text);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
