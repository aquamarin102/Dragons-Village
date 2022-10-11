using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Quests
{
    [CreateAssetMenu(menuName = "Create QuestConfig", fileName = "QuestConfig", order = 0)]
    public class QuestItemsConfig : ScriptableObject
    {
        public int id;
        public List<int> questItemIdCollection;
    }
}