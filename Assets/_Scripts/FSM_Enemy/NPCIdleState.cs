using UnityEngine;

namespace _Scripts.FSM_Enemy
{
    public class NPCIdleState : NPCState
    {
        public NPCIdleState(NPCStateManager npcStateManager) : base(npcStateManager)
        {
        }

        public override void Enter()
        {
            _NPCStateManager.GetMyAnimator().CrossFade(_NPCStateManager.IdleAnimationId, 0, 0);
        }

        public override void Update()
        {
            if (CheckIfInRange())
            {
                Exit(new NPCFistDoublePunch(_NPCStateManager));
                return;
            }

            Exit(new NPCHoverState(_NPCStateManager));
        }

        private bool CheckIfInRange()
        {
            return Mathf.Abs(_NPCStateManager.GetTarget().position.x - _NPCStateManager.transform.position.x) <=
                   _NPCStateManager.GetRange();
        }
    }
}