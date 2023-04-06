using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace _Scripts.FSM_Enemy
{
    public class NPCHoverState : NPCState
    {
        public NPCHoverState(NPCStateManager npcStateManager) : base(npcStateManager)
        {
        }

        public override void Enter()
        {
            _NPCStateManager.GetMyAnimator().CrossFade(_NPCStateManager.HoverAnimationId, 0, 0);
        }

        public override void Update()
        {
            if (CheckIfInRange())
            {
                if (CheckIfTargetIsOnGround())
                {
                    Exit(new NPCIdleState(_NPCStateManager));
                    return;
                }

                Exit(new NPCIdleState(_NPCStateManager));
                return;
            }

            int randomNumber = Random.Range(1, 1000);

            if (CheckIfIsShootingRange() && randomNumber == 20)
            {
                Exit(new NPCRangedAttack(_NPCStateManager));
            }

            _NPCStateManager.transform.position = Vector3.MoveTowards(_NPCStateManager.transform.position,
             new Vector2(_NPCStateManager.GetTarget().position.x, -2.985f), _NPCStateManager.GetSpeed() * Time.deltaTime);

            _NPCStateManager.transform.localScale = new Vector3(
                -Mathf.Sign(_NPCStateManager.transform.position.x - _NPCStateManager.GetTarget().position.x), 1, 1);
        }

        private bool CheckIfIsShootingRange()
        {
            return Mathf.Abs(_NPCStateManager.GetTarget().position.x - _NPCStateManager.transform.position.x) >=
                   _NPCStateManager.GetMinRangeShoot();
        }

        private bool CheckIfTargetIsOnGround()
        {
            return _NPCStateManager.GetTarget().position.y >= -1.5;
        }

        private bool CheckIfInRange()
        {
            return Mathf.Abs(_NPCStateManager.GetTarget().position.x - _NPCStateManager.transform.position.x) <=
                   _NPCStateManager.GetRange();
        }
    }
}