using _Scripts.Combat;
using UnityEngine;

namespace _Scripts.FSM_Player
{
    public class DeathState : IState
    {
        private StateManager _stateManager;

        public DeathState(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void Enter()
        {
            _stateManager.MyAnimator.CrossFade(_stateManager.DeathAnimationId, 0, 0);
            _stateManager.GetComponent<Health>().enabled = false;
            _stateManager.enabled = false;
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Exit(IState nextState)
        {
            throw new System.NotImplementedException();
        }
    }
}