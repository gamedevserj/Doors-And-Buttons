using UnityEngine;

namespace DoorsAndButtons
{
    public class Door : MonoBehaviour
    {

        [Tooltip("Is the door open at start?")]
        public bool openAtStart; // true - door is open at start, false - door is closed
        public string animatorParameter = "Open";
        private Animator anim;
        private bool currentState;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            anim.SetBool(animatorParameter, openAtStart);
            currentState = openAtStart;
        }

        /// <summary>
        /// Changes door status
        /// </summary>
        /// <param name="change">true - change state, false - revert to state at start</param>
        public void ChangeState(bool change)
        {
            currentState = !currentState;
            anim.SetBool(animatorParameter, currentState);
        }
    }
}