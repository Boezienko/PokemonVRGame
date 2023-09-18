using UnityEngine;


/// <summary>
/// Move an object using velocity
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PokemonMovement : MonoBehaviour
{
    [SerializeField]
    public Transform target = null;

    [SerializeField]
    public float speed = 1.0f;
    /*
    [Tooltip("The speed at which the object is moved")]
    public float speed = 1.0f;

    [Tooltip("Controls the direction of movement")]
    public Transform origin = null;

    private Rigidbody rigidBody = null;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Vector3 move_velocity = new Vector3(speed, 0f, 0f);
        Vector3 velocity_change = move_velocity - rigidBody.velocity;
        rigidBody.AddForce(velocity_change, ForceMode.VelocityChange);
    }
    */

    void Update()
    {
        this.MoveToXRRig();
    }

    public void MoveToXRRig()
    {
        // rotate to look at player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, 180, 0)    , Space.Self);

        if(Vector3.Distance(transform.position, target.position) > 0.5 )
        {
            transform.Translate(new Vector3(0,0, -speed * Time.deltaTime));
        }
    }
    

}
