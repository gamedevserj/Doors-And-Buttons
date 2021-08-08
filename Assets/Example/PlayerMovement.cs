using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode forward;
    public KeyCode back;

    public float speed = 5;
    public float rotationSpeed = 5;

    public float pushPower = 5;

    public Animator anim;
    public Transform objectToRotate;

    CharacterController controller;

    Vector3 velocity;
    Quaternion targetRotation;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        velocity.y = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(left))
        {
            velocity.x = -1;
        }
        if (Input.GetKey(right))
        {
            velocity.x = 1;
        }
        if (Input.GetKey(back))
        {
            velocity.z = -1;
        }
        if (Input.GetKey(forward))
        {
            velocity.z = 1;
        }

        if(!Input.GetKey(left) && !Input.GetKey(right))
        {
            velocity.x = 0;
        }
        if (!Input.GetKey(forward) && !Input.GetKey(back))
        {
            velocity.z = 0;
        }

        if(!Mathf.Approximately(velocity.x, 0) || !Mathf.Approximately(velocity.z, 0))
        {
            anim.SetBool("run", true);
            targetRotation = Quaternion.LookRotation(new Vector3(velocity.x, 0, velocity.z), Vector3.up);
            objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("run", false);
        }
        controller.Move(velocity.normalized * speed * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Respawn"))
        {
            hit.collider.GetComponent<Rigidbody>().AddForce(hit.moveDirection.normalized * pushPower);
        }
    }
}
