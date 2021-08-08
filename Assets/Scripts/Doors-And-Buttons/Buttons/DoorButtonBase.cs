using UnityEngine;
using System.Collections.Generic;

namespace DoorsAndButtons
{
    public abstract class DoorButtonBase : MonoBehaviour
    {
        public bool IsActivated { get; set; }
        public Collider WhoPressesButton { get; set; } // to prevent change when another player steps on it   

        public string animatorParameter = "On";


        protected List<DoorManager> doorManagers = new List<DoorManager>(); // stores every doorManager that checks this button

        private Animator animator;

        /// <summary>
        /// Adds door manager to the list of managers that control this button
        /// Is called by door managers
        /// </summary>
        /// <param name="dm"></param>
        public void AddDoorManager(DoorManager dm)
        {
            doorManagers.Add(dm);
        }

        public virtual void SetupOnStart()
        {
            animator = GetComponent<Animator>();
            ChangeVisualState(IsActivated);
        }

        /// <summary>
        /// Visualizes change in button state
        /// </summary>
        /// <param name="buttonState"></param>
        protected void ChangeVisualState(bool buttonState)
        {
            animator.SetBool(animatorParameter, buttonState);
        }

        /// <summary>
        /// Is called when player interacts with the button
        /// </summary>
        public abstract void Interact();

    }
}