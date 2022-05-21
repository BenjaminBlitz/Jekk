  using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    public GameObject playerObject;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        /*Debug.Log("INTERACT");*/
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);
        Debug.Log(distance.ToString());
        if(distance <= radius)
        {
            if (!hasInteracted)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }


}

