﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;

public class UIRegister : MonoBehaviour {

	public InputField username;
	public InputField password;
	public InputField passwordConfirm;
	public Button buttonRegister;

	// Use this for initialization
	void Start () {
		initUI();
		UserService.Instance.OnRegister = this.OnRegister;
	}

	void OnRegister(SkillBridge.Message.Result result, string msg)
    {
		MessageBox.Show(string.Format("结果：{0} msg：{1}", result, msg));
    }

	public void OnClickRegister()
    {
		if (string.IsNullOrEmpty(this.username.text))
        {
			MessageBox.Show("请输入账号");
			return;
        }
		if(string.IsNullOrEmpty(this.password.text))
        {
			MessageBox.Show("请输入密码");
			return;
        }
		if (string.IsNullOrEmpty(this.passwordConfirm.text))
		{
			MessageBox.Show("请输入确认密码");
			return;
		}
		if (this.password.text != this.passwordConfirm.text)
		{
			MessageBox.Show("两次输入的密码不一致");
			return;
		}
		UserService.Instance.SendRegister(this.username.text, this.password.text);
	}

	void initUI()
	{
		GameObject root = GameObject.Find("RegisterPanel");
		username = root.transform.Find("InputUsername").GetComponent<InputField>();
		password = root.transform.Find("InputPassword").GetComponent<InputField>();
		passwordConfirm = root.transform.Find("InputPasswordConfirm").GetComponent<InputField>();
		buttonRegister = root.transform.Find("ButtonRegister").GetComponent<Button>();

		buttonRegister.onClick.AddListener(OnClickRegister);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
