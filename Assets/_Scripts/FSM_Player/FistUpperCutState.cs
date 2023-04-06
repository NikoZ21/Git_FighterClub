using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class FistUpperCutState : IState
    {
        private StateManager _stateManager;
        private bool _isGoingToSmash;

        public FistUpperCutState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.UpperCutAnimationId, 0, 0);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                _isGoingToSmash = true;
            }

            if (!CheckIfAnimDonePlaying()) return;

            if (_isGoingToSmash)
            {
                Exit(new FistSmashState(_stateManager));
                return;
            }

            Exit(new IdleState(_stateManager));
        }

        public void Exit(IState nextState)
        {
            _isGoingToSmash = false;
            _stateManager.ChangeState(nextState);
        }

        private bool CheckIfAnimDonePlaying()
        {
            return _stateManager.MyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
        }
    }
}