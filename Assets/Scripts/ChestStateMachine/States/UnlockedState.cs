using Assets.Scripts.Chest;
using Assets.Scripts.Event;

namespace Assets.Scripts.ChestStateMachine
{
    public class UnlockedState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;
        private EventService eventService;

        public UnlockedState(ChestStateMachine stateMachine, EventService eventService)
        {
            this.stateMachine = stateMachine;
            this.eventService = eventService;
        }

        public void OnStateEnter()
        {
            eventService.OnUnlockFinishWithTime.Invoke();
            Owner.chestView.SetChestImage(Owner.chestModel.GetOpenedChestSprite);
            Owner.chestView.SetTimeToUnlock("Tap to Open");
        }

        public void Update()
        {
        }

        public void OnStateExit()
        {
        }
    }
}