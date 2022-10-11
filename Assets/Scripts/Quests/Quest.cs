using System;
using Scripts.Interfaces;
using Scripts.Player;

namespace Scripts.Quests
{
    public class Quest : IQuest, IDisposable
    {
        private readonly QuestObjectView _view;
        private readonly IQuestModel _model;

        private bool _active;
        
        public event Action<IQuest> Completed;
        public bool IsCompleted { get; private set; }

        public Quest(QuestObjectView view, IQuestModel model)
        {
            _view = view;
            _model = model;
        }

        private void Complete()
        {
            if(!_active)
                return;

            _active = false;
            IsCompleted = true;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this);
        }

        private void OnContact(CharacterView obj)
        {
            var completed = _model.TryComplete(obj.gameObject);
            
            if(completed)
                Complete();
        }

        public void Reset()
        {
            if (_active)
                return;
            _active = true;
            IsCompleted = false;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActive();
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
    }
}