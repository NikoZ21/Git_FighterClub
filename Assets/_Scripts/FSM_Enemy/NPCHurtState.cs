using UnityEngine;

namespace _Scripts.FSM_Enemy
{
    public class NPCHurtState : NPCState
    {
        private float _timer = 0.2f;

        public NPCHurtState(NPCStateManager npcStateManager) : base(npcStateManager)
        {
        }

        public override void Enter()
        {
            _NPCStateManager.GetMyAnimator().CrossFade(_NPCStateManager.HurtAnimationId, 0, 0);
        }

        public override void Update()
        {
            if (!CheckIfAnimDonePlaying()) return;
            _timer -= Time.deltaTime;

            if (_timer > 0) return;

            Exit(new NPCIdleState(_NPCStateManager));
        }

        protected override void Exit(NPCState state)
        {
            _timer = 0.2f;
            base.Exit(state);
        }
    }
}