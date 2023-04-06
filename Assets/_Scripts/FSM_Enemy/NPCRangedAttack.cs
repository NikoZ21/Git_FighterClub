namespace _Scripts.FSM_Enemy
{
    public class NPCRangedAttack : NPCState
    {
        public NPCRangedAttack(NPCStateManager npcStateManager) : base(npcStateManager)
        {
        }

        public override void Enter()
        {
            _NPCStateManager.GetMyAnimator().CrossFade(_NPCStateManager.RangedAttackAnimationId, 0, 0);
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