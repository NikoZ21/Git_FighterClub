namespace _Scripts.FSM_Player
{
    public class FistSmashState : IState
    {
        private StateManager _stateManager;

        public FistSmashState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.SmashAnimationId, 0, 0);
        }

        public void Update()
        {
            if (!CheckIfAnimDonePlaying()) return;

            Exit(new IdleState(_stateManager));
        }

        public void Exit(IState nextState)
        {
            _stateManager.ChangeState(nextState);
        }

        private bool CheckIfAnimDonePlaying()
        {
            return _stateManager.MyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
        }
    }
}