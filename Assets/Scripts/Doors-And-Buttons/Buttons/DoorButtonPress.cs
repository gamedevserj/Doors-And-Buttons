namespace DoorsAndButtons
{
    public class DoorButtonPress : DoorButtonBase, IInteractable
    {

        void Start()
        {
            base.SetupOnStart();
        }

        public override void Interact()
        {
            IsActivated = !IsActivated; // activating button
            for (int i = 0; i < doorManagers.Count; i++)
            {
                doorManagers[i].CheckButtonsState();
            }
            ChangeVisualState(IsActivated);
        }
    }
}