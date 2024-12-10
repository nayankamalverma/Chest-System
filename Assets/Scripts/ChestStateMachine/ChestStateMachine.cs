using Assets.Scripts.Chest;
using Assets.Scripts.Event;
using System.Collections.Generic;

namespace Assets.Scripts.ChestStateMachine
{
    public class ChestStateMachine
    {
        private ChestController Owner;
        private IState currentState;
        public Dictionary<State, IState> States = new Dictionary<State, IState>();
        private State currState;
        private EventService eventService;

        public ChestStateMachine(ChestController chestController,EventService eventService)
        {
            Owner = chestController;
            this.eventService = eventService;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(State.Locked, new LockedState(this));
            States.Add(State.Unlocking, new UnlockingState(this));
            States.Add(State.Unlocked, new UnlockedState(this, eventService));
            States.Add(State.Opened, new OpenedState(this));
        }

        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public State GetCurrentState()=>currState;
        public void ChangeChestState(State newState)
        {
            ChangeState(States[newState]);
            currState = newState;
        }
    }
}