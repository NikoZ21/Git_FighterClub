namespace _Scripts.FSM_Enemy
{
    public class NPCFistDoublePunch : NPCState
    {
        public NPCFistDoublePunch(NPCStateManager npcStateManager) : base(npcStateManager)
        {
        }

        public override void Enter()
        {
            _NPCStateManager.GetMyAnimator().CrossFade(_NPCStateManager.DoublePunchAnimationId, 0, 0);
        }

        public override void Update()
        {
            if (CheckIfAnimDonePlaying())
            {
                Exit(new NPCSmashState(_NPCStateManager));
            }
        }
    }
}