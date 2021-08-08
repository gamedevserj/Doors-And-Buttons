using UnityEngine;

namespace DoorsAndButtons
{
    public class DoorButtonHold : DoorButtonBase
    {

        public float timeToHold = 3;
        public float sliderUpdateRate = 0.01f;
        public UnityEngine.UI.Slider slider;

        float secondsHeld;
        bool isRunningCoroutine;

        void Start()
        {
            slider.maxValue = timeToHold;
            slider.value = 0;
            base.SetupOnStart();
        }

        void CountTime()
        {
            isRunningCoroutine = true;
            if (IsActivated) { secondsHeld += sliderUpdateRate; } // increase time held if player is on the button
            else { secondsHeld -= sliderUpdateRate; }// decrease time held if player is off the button
            slider.value = secondsHeld;

            if (secondsHeld >= timeToHold || secondsHeld <= 0)
            {
                //button was held long enough, disable button and set it to be activated
                if (secondsHeld >= timeToHold)
                {
                    IsActivated = true;
                    GetComponent<Collider>().enabled = false;
                    for (int i = 0; i < doorManagers.Count; i++)
                    {
                        doorManagers[i].CheckButtonsState();
                    }
                }
                //reset slider to 0 to prevent going into negative numbers
                if (secondsHeld <= 0)
                {
                    secondsHeld = 0;
                }
                isRunningCoroutine = false;
                CancelInvoke();
            }
        }

        public override void Interact()
        {
            IsActivated = !IsActivated;
            ChangeVisualState(IsActivated);
            if (!isRunningCoroutine)
            {
                InvokeRepeating("CountTime", 0, sliderUpdateRate);
            }
        }
    }
}