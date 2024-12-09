using Assets.Scripts.Chest;

namespace Assets.Scripts.ChestStateMachine
{
    public class UnlockedState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;

        public UnlockedState(ChestStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            Owner.chestView.SetChestImage(Owner.chestModel.GetOpenedChestSprite);
            Owner.chestView.SetTimeToUnlock("Tap to Open");
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