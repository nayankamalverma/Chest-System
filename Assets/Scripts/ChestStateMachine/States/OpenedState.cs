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
            Owner.GenerateChestReward();
        }

        public void Update()
        {
        }

        public void OnStateExit()
        {
          
        }
    }
}