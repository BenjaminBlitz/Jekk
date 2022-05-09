using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] LayerMask m_MyLayerMask;

    private void OnCollisionEnter(Collision collision)
    {
        // Identifier un GameObject
        /*// PAR NOM
        if (collision.gameObject.name.ToUpper().Equals("CUBE"))
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/

        // PAR TAG
        /*if (collision.gameObject.CompareTag("Colorable"))
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/
        // PAR LAYER
        /*if (collision.gameObject.layer == 6 || collision.gameObject.layer == LayerMask.NameToLayer("Colorable"))
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/

        /*if ((m_MyLayerMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/

        // PAR FONCTION ->on récupère un component du GameObject
        /*if (collision.gameObject.GetComponent<Colorable>())
        {
            Tools.SetRandomColor(collision.gameObject);
        }*/


        // PAR INTERFACE
        /*IColorize colorize = collision.gameObject.GetComponent<IColorize>();

        if (colorize != null)
        {
            colorize.RecolorizeRandom();
        }*/

        EventManager.Instance.Raise(new BallHasCollidedEvent() { eCollidedGO = collision.gameObject });
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
