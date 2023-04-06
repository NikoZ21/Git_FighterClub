using System.Reflection;
using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class FallState : IState
    {
        private StateManager _stateManager;

        public FallState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.FallAnimationId, 0, 0);
        }

        public void Update()
        {
            if (_stateManager.GetRigidBody2D().velocity.y == 0)
            {
                Exit(new IdleState(_stateManager));
                return;
            }

            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                _stateManager.GetRigidBody2D().velocity = new Vector2(Input.GetAxis("Horizontal") * 2,
                    _stateManager.GetRigidBody2D().velocity.y);
            }
        }

        public void Exit(IState nextState)
        {
            _stateManager.ChangeState(nextState);
        }
    }
}