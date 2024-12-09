using System.Collections;
using Assets.Scripts.Chest;
using NUnit.Framework.Interfaces;
using UnityEngine;

namespace Assets.Scripts.ChestStateMachine
{
    public class UnlockingState: IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;

        public UnlockingState(ChestStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            Owner.chestView.StartCoroutine(StartUnlockTimer());
        }

        public void Update()
        {
        }

        public void OnStateExit()
        {
            Owner.chestView.StopAllCoroutines();
        }
        private IEnumerator StartUnlockTimer()
        {
            float remainingTime = Owner.chestModel.GetUnlockTime;
            while (remainingTime > 0)
            {
                 int hours = Mathf.FloorToInt(remainingTime / 3600);
                int minutes = Mathf.FloorToInt((remainingTime % 3600) / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);

                Owner.chestView.SetChestStatus( $"{hours:D2}:{minutes:D2}:{seconds:D2}");
                yield return new WaitForSeconds(1);
                remainingTime -= 1;
            }
            Owner.ChangeChestState(State.Unlocked);
        }
    }
}