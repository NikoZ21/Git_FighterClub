using UnityEditor.UIElements;
using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class JumpState : IState
    {
        private StateManager _stateManager;

        public JumpState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.JumpAnimationId, 0, 0);

            _stateManager.GetRigidBody2D().velocity =
                new Vector2(_stateManager.GetRigidBody2D().velocity.x,
                    _stateManager.JumpForce);
        }

        public void Update()
        {
            if (_stateManager.GetRigidBody2D().velocity.y > 0) return;

            if (_stateManager.GetRigidBody2D().velocity.y < 0) Exit(new FallState(_stateManager));
        }

        public void Exit(IState nextState)
        {
            _stateManager.ChangeState(nextState);
        }
    }
}