namespace _Scripts.FSM_Enemy
{
    public abstract class NPCState
    {
        protected NPCStateManager _NPCStateManager;

        public NPCState(NPCStateManager npcStateManager)
        {
            _NPCStateManager = npcStateManager;
        }

        public abstract void Enter();

        public abstract void Update();

        protected virtual void Exit(NPCState state)
        {
            _NPCStateManager.ChangeState(state);
        }

        protected bool CheckIfAnimDonePlaying()
        {
            return _NPCStateManager.GetMyAnimator().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
        }
    }
}