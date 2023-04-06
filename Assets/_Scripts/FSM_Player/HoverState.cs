using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class HoverState : IState
    {
        private StateManager _stateManager;

        public HoverState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.HoverAnimationId, 0, 0);
        }

        public void Update()
        {
            var horizontalMovement = Input.GetAxis("Horizontal");
            var stateManagerTransform = _stateManager.transform;

            _stateManager.GetRigidBody2D().velocity = new Vector2(horizontalMovement * _stateManager.Speed, 0);

            if (horizontalMovement > 0)
            {
                stateManagerTransform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontalMovement < 0)
            {
                stateManagerTransform.localScale = new Vector3(-1, 1, 1);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                _stateManager.ChangeState(new FistDoublePunch(_stateManager));
            }

            else if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Exit(new JumpState(_stateManager));
            }

            if (horizontalMovement == 0)
            {
                Exit(new IdleState(_stateManager));
            }
        }

        public void Exit(IState nextState)
        {
            _stateManager.ChangeState(nextState);
        }
    }
}