using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class FistDoublePunch : IState
    {
        private StateManager _stateManager;
        private bool _isGoingToUpperCut;

        public FistDoublePunch(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.DoublePunchAnimationId, 0, 0);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                _isGoingToUpperCut = true;
            }

            if (!CheckIfAnimDonePlaying()) return;

            if (_isGoingToUpperCut)
            {
                Exit(new FistUpperCutState(_stateManager));
                return;
            }

            Exit(new IdleState(_stateManager));
        }

        public void Exit(IState nextState)
        {
            _isGoingToUpperCut = false;
            _stateManager.ChangeState(nextState);
        }

        private bool CheckIfAnimDonePlaying()
        {
            return _stateManager.MyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
        }
    }
}