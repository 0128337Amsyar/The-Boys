 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool GroundCheck;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            GroundCheck = true; 
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            GroundCheck = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            GroundCheck = false;
        }
    }
}
