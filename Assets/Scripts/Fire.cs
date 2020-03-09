using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Fire : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public float shootingSpeed = 1;
    private Interactable interactable;
    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void OnHandOverBegin(Hand hand)
    {

    }

    private void OnHandOverEnd(Hand hand)
    {

    }

    private void HandOverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        // Grab Object
        if (interactable.attachedToHand == null  &&  grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
        }
        // Release Object
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            // after release then shoot
            Shoot();
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (interactable.attachedToHand != null) // bullet has been grabbed
    //     {
    //         SteamVR_Input_Sources source = interactable.attachedToHand.handType; // type of source

    //         if (fireAction[source].stateDown) // fire is triggered on controller
    //         {
    //             Shoot();
    //         }
    //     }
    // }

    void Shoot()
    {
        Debug.Log("Pew Pew");
        m_rigidbody.velocity = transform.forward * shootingSpeed;
    }
}
