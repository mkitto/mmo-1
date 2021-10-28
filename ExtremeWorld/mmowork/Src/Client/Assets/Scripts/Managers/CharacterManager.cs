using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using Common;

using SkillBridge.Message;
using Entities;

namespace Managers
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/1/14 7:37:18
    /// subscribe：XXX
    /// </summary>
    class CharacterManager : Singleton<CharacterManager>, IDisposable
    {
        public Dictionary<int, Character> Characters = new Dictionary<int, Character>();

        public UnityAction<Character> OnCharacterEnter;
        public UnityAction<Character> OnCharacterLeave;

        public CharacterManager()
        {

        }

        public void Dispose()
        {
        }

        public void Init()
        {

        }

        public void Clear()
        {
            int[] keys = this.Characters.Keys.ToArray();
            foreach(var key in keys)
            {
                this.RemoveCharacter(key);
            }
            this.Characters.Clear();
        }

        public void AddCharacter(SkillBridge.Message.NCharacterInfo cha)
        {
            Character character = new Character(cha);
            this.Characters[cha.EntityId] = character;
            EntityManager.Instance.AddEntity(character);

            if (OnCharacterEnter != null)
            {
                OnCharacterEnter(character);
            }
        }

        public void RemoveCharacter(int entityId)
        {
            Debug.LogFormat("RemoveCharacter: {0}", entityId);
            if (this.Characters.ContainsKey(entityId))
            {
                EntityManager.Instance.RemoveEntity(this.Characters[entityId].Info.Entity);
                if (OnCharacterLeave != null)
                {
                    OnCharacterLeave(this.Characters[entityId]);
                }
                this.Characters.Remove(entityId);
            }
        }
    }
}
