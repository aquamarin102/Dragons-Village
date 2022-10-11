using System;

namespace Scripts.Interfaces
{
    public interface IQuest
    {
        event Action<IQuest> Completed;
        bool IsCompleted { get; }
        
        void Reset();
    }
}