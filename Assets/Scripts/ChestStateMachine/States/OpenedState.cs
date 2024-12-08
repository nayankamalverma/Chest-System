using Assets.Scripts.Chest;

namespace Assets.Scripts.ChestStateMachine
{
    public class OpenedState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;

        public OpenedState(ChestStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new System.NotImplementedException();
        }
    }
}