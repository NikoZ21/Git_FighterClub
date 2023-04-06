namespace _Scripts.FSM_Enemy
{
    public class NPCSmashState : NPCState
    {
        public NPCSmashState(NPCStateManager npcStateManager) : base(npcStateManager)
        {
        }

        public override void Enter()
        {
            _NPCStateManager.GetMyAnimator().CrossFade(_NPCStateManager.SmashAnimationId, 0, 0);
        }

        public override void Update()
        {
            if (CheckIfAnimDonePlaying())
            {
                Exit(new NPCIdleState(_NPCStateManager));
            }
        }
    }
}