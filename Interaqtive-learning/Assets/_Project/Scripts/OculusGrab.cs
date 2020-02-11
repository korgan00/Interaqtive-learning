using System.Collections;

using System.Collections.Generic;

using UnityEngine;
public class OculusGrab : MonoBehaviour
{


    // identifying objects

    public GameObject CollidingObject;

    public GameObject objectInHand;

    public TMPro.TextMeshProUGUI debug;


    // trigger functions after adding trigger zones to controllers and adding script to controllers

    public void OnTriggerEnter(Collider other) //picking up objects with rigidbodies

    {
        debug.text = "trigger enter";

        if (other.gameObject.GetComponent<Rigidbody>())

        {

            CollidingObject = other.gameObject;

            if (other.gameObject.GetComponent<OculusButton>())
            {
                other.gameObject.GetComponent<OculusButton>().Action();
            }

        }



    }

    public void OnTriggerExit(Collider other) // releasing those objects with rigidbodies

    {

        CollidingObject = null;

    }


    void Update() // refreshing program confirms trigger pressure and determines whether holding or releasing object

    {

        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") > 0.2f && CollidingObject)
        {
            debug.text = "primary trigger grab";

            GrabObject();

        }

        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") < 0.2f && objectInHand)
        {
            debug.text = "primary trigger release";

            ReleaseObject();

        }

        if (objectInHand)
        {
            objectInHand.GetComponent<Rigidbody>().MovePosition(transform.position);
        }




    }


    public void GrabObject() //create parentchild relationship between object and hand so object follows hand

    {

        objectInHand = CollidingObject;

        

    }


    private void ReleaseObject() //removing parentchild relationship so you drop the object

    {
        objectInHand = null;

    }

}