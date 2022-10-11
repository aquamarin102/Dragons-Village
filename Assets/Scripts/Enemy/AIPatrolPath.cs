using System;
using Pathfinding;

namespace Scripts.Enemy
{
    public class AIPatrolPath : AIPath

    {

        public event Action TargetReached;

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispatchTargetReached();
        }

        protected virtual void DispatchTargetReached()
        {
            TargetReached?.Invoke();
        }
    }
}