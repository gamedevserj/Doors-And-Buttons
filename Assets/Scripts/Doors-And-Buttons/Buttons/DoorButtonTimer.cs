using UnityEngine;
using System.Collections;

namespace DoorsAndButtons
{
    public class DoorButtonTimer : DoorButtonBase, IInteractable
    {

        public int timerButtonTime = 5;
        public TMPro.TMP_Text timer;

        void Start()
        {
            base.SetupOnStart();
            timer.text = "0:00";
        }

        IEnumerator Countdown()
        {
            int seconds = timerButtonTime;
            //counting down
            while (seconds > 0)
            {
                var span = new System.TimeSpan(0, 0, seconds);
                seconds -= 1;
                timer.text = string.Format("{0}:{1:00}", span.Minutes, span.Seconds);
                yield return new WaitForSeconds(1);
            }
            //reset the timer text and turn off the button
            timer.text = "0:00";
            IsActivated = false;
            ChangeVisualState(IsActivated);
            for (int i = 0; i < doorManagers.Count; i++)
            {
                doorManagers[i].CheckButtonsState();
            }
        }

        public override void Interact()
        {
            if (!IsActivated) // prevent pressing while counting down
            {
                IsActivated = true; // activating button
                StartCoroutine(Countdown()); // start countdown
                for (int i = 0; i < doorManagers.Count; i++)
                {
                    doorManagers[i].CheckButtonsState();
                }
                ChangeVisualState(IsActivated);
            }
        }
    }
}