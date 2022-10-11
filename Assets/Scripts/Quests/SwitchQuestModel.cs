using Scripts.Interfaces;
using Scripts.Player;
using UnityEngine;

namespace Scripts.Quests
{
    public class SwitchQuestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.GetComponent<CharacterView>();
        }
    }
}