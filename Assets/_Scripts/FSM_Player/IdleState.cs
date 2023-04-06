using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class IdleState : IState
    {
        private StateManager _stateManager;

        public IdleState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.IdleAnimationId, 0, 0);
        }

        public void Update()
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                Exit(new HoverState(_stateManager));
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Exit(new FistDoublePunch(_stateManager));
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Exit(new RangedAttackState(_stateManager));
            }

            else if (Input.GetKeyDown(KeyCode.K))
            {
                Exit(new LegKickState(_stateManager));
            }

            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Exit(new DodgeState(_stateManager));
            }
            else if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Exit(new JumpState(_stateManager));
            }
        }

        public void Exit(IState nextState)
        {
            _stateManager.ChangeState(nextState);
        }
    }
}