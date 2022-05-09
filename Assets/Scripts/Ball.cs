using SDD.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] LayerMask m_MyLayerMask;



    private void OnCollisionEnter(Collision collision)
    {
        // Identification d'un GameObject
        //PAR NOM
        /*
        if (collision.gameObject.name.Equals("Cube"))
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/
        //PAR TAG
        /*
        if (collision.gameObject.CompareTag("Colorable"))
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/
        //PAR LAYER
        //if (collision.gameObject.layer==6)
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Colorable"))
        /*if ((m_MyLayerMask.value & (1<< collision.gameObject.layer))!=0)
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/

        //PAR FONCTION
        //if(null != collision.gameObject.GetComponent<Colorable>())
        IColorize colorize = collision.gameObject.GetComponent<IColorize>();
        if(colorize !=null)
        {
            colorize.RecolorizeRandom();
            //Tools.SetRandomColor(collision.gameObject);
        }
        EventManager.Instance.Raise(new BallHasCollidedEvent() { eCollidedGO = collision.gameObject });
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}