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
            Owner.chestView.SetChestImage(Owner.chestModel.GetLockedChestSprite);
            Owner.chestView.SetChestName(Owner.chestModel.GetChestName);
            Owner.chestView.SetChestStatus(Owner.GetChestCurrentState().ToString());
            Owner.chestView.SetTimeToUnlock(Owner.chestModel.GetUnlockTimeString);
        }

        public void Update()
        {
        }

        public void OnStateExit()
        {
        }
    }
}
