using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool VaccineExit;
    private bool MachineExit;
    private bool NourishmentExit;
    private GameObject Object;
    void Update()
    {
        if (MachineExit)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Use Machine");
            }
        }
        if (VaccineExit)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Pick up Vaccine");
                Destroy(Object);
            }
        }
        if (NourishmentExit)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Pick up Nourishment");
                Destroy(Object);
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Machine")
        {
            MachineExit = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Machine")
        {
            MachineExit = false;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Vaccine")
        {
            VaccineExit = true;
            Object = collider.gameObject;
        }
        else if(collider.gameObject.tag == "Nourishment")
        {
            NourishmentExit = true;
            Object = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Vaccine")
        {
            VaccineExit = false;
        }
        else if (collider.gameObject.tag == "Nourishment")
        {
            NourishmentExit = false;
        }
    }
}
