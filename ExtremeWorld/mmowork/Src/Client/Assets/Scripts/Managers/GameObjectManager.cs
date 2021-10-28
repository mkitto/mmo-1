﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entities;
using Services;
using SkillBridge.Message;
using Models;
using Managers;
using System.Linq;

public class GameObjectManager : MonoSingleton<GameObjectManager>
{
    Dictionary<int, GameObject> Characters = new Dictionary<int, GameObject>();
    // Use this for initialization
    protected override void OnStart()
    {
        StartCoroutine(InitGameObjects());
        CharacterManager.Instance.OnCharacterEnter += OnCharacterEnter;
        CharacterManager.Instance.OnCharacterLeave += OnCharacterLeave;
    }

    private void OnDestory()
    {
        CharacterManager.Instance.OnCharacterEnter = null;
    }

    void OnCharacterEnter(Character cha)
    {
        CreateCharacterObject(cha);
    }

    void OnCharacterLeave(Character character)
    {
        Debug.Log("------OnCharacterLeave" + Characters.Keys.ToArray() + ", " + character.entityId.ToString());
        if (!Characters.ContainsKey(character.entityId))
        {
            return;
        }

        if (Characters[character.entityId] != null)
        {
            Destroy(Characters[character.entityId]);
            this.Characters.Remove(character.entityId);
        }
    }

    IEnumerator InitGameObjects()
    {
        foreach (var cha in CharacterManager.Instance.Characters.Values)
        {
            CreateCharacterObject(cha);
            yield return null;  // 下一帧再执行后续代码
        }
    }

    private void CreateCharacterObject(Character character)
    {
        if (!Characters.ContainsKey(character.entityId) || Characters[character.entityId] == null)
        {
            Object obj = Resloader.Load<Object>(character.Define.Resource);  // 加载资源
            if (obj == null)
            {
                Debug.LogErrorFormat("Character[{0}] Resource[{1}] not existed.", character.Define.TID, character.Define.Resource);
                return;
            }
            GameObject go = (GameObject)Instantiate(obj, this.transform);
            go.name = "Character_" + character.Id + "_" + character.Name;
            Characters[character.entityId] = go;
            UIWorldElementManager.Instance.AddCharacterNameBar(go.transform, character);
        }
        this.InitGameObject(Characters[character.entityId], character);
    }

    private void InitGameObject(GameObject go, Character character) 
    {
        go.transform.position = GameObjectTool.LogicToWorld(character.position);
        go.transform.forward = GameObjectTool.LogicToWorld(character.direction);
        EntityController ec = go.GetComponent<EntityController>();
            if (ec != null)
            {
                ec.entity = character;
                ec.isPlayer = character.IsCurrentPlayer;
            }

            PlayerInputController pc = go.GetComponent<PlayerInputController>();
            if (pc != null)
            {
                if (character.IsCurrentPlayer)
                {
                    User.Instance.CurrentCharacterObject = go;
                    MainPlayerCamera.Instance.player = go;
                    pc.enabled = true;
                    pc.character = character;
                    pc.entityController = ec;
                }
                else
                {
                    pc.enabled = false;
                }
            }
    }
}