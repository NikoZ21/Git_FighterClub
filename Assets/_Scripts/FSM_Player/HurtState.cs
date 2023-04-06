
namespace _Scripts.FSM_Player
{
    public class HurtState : IState
    {
        private StateManager _stateManager;

        public HurtState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.HurtAnimationId, 0, 0);
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