using Assets.Scripts.Chest;

namespace Assets.Scripts.ChestStateMachine
{
    internal class LockedState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;

        public LockedState(ChestStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {

        }

        public void Update()
        {
        }

        public void OnStateExit()
        {
        }
    }
}
