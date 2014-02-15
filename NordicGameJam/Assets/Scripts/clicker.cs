using UnityEngine;
using System.Collections;

public class clicker : MonoBehaviour
{

    private Collider col;
    public float moveSpeed;
    RaycastHit hit;
    Ray ray;
    public float hitdist = 0.0f;
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public Transform myTransform;          // this transform
    public Vector3 destinationPosition;       // The destination Point
    public float destinationDistance;      // The distance between myTransform and destinationPosition
    public float smooth = 0.0005F;
    CharacterController controller;

    void Awake()
    {

    }

    void Start()
    {

        var character = GameObject.FindWithTag("Player");
        myTransform = character.transform;


        destinationPosition = myTransform.position;
    }

    void Update()
    {

        //controller = GetComponent<CharacterController>();
        // keep track of the distance between this gameObject and destinationPosition
        destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);


        // Moves the Player if the Left Mouse Button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform)
                {
                    destinationPosition = hit.point;
                    if (destinationDistance > .5f)
                    {
                        transform.Translate(transform.forward * speed);
                        //controller.SimpleMove(destinationPosition);
                    }
                }
            }
        }

    }
}