using UnityEngine;

namespace Scripts.Interfaces
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}