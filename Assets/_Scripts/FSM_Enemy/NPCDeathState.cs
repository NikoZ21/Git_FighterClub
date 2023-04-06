using _Scripts.Combat;
using TMPro;
using UnityEngine;

namespace _Scripts.FSM_Enemy
{
    public class NPCDeathState : NPCState
    {
        public NPCDeathState(NPCStateManager npcStateManager) : base(npcStateManager)
        {
        }

        public override void Enter()
        {
            _NPCStateManager.GetMyAnimator().CrossFade(_NPCStateManager.DeathAnimationId, 0, 0);
            _NPCStateManager.GetComponent<Health>().enabled = false;
            _NPCStateManager.GetComponent<CapsuleCollider2D>().enabled = false;
            _NPCStateManager.enabled = false;
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}