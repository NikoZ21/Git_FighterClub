namespace _Scripts.FSM_Player
{
    public interface IState
    {
        void Enter();

        void Update();

        void Exit(IState nextState);
    }
}