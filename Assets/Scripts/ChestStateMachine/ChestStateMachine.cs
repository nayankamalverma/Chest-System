﻿using Assets.Scripts.Chest;
using System.Collections.Generic;

namespace Assets.Scripts.ChestStateMachine
{
    public class ChestStateMachine
    {
        private ChestController Owner;
        private IState currentState;
        public Dictionary<State, IState> States = new Dictionary<State, IState>();

        public ChestStateMachine(ChestController chestController)
        {
            Owner = chestController;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(State.Locked, new LockedState(this));
            States.Add(State.Unlocking, new UnlockedState(this));
            States.Add(State.Unlocked, new UnlockingState(this));
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

        public State GetCurrentState()
        {
            foreach (KeyValuePair<State, IState> key in States)
            {
                if (EqualityComparer<IState>.Default.Equals(key.Value, currentState))
                {
                    return key.Key;
                }
            }
            throw new KeyNotFoundException("The specified value was not found in the dictionary.");
        }
        public void ChangeChestState(State newState) => ChangeState(States[newState]);
    }
}