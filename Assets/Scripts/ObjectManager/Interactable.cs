  using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    private Vector3 rotation;
    [SerializeField] private float speed;

    bool isFocus = false;
    public GameObject playerObject;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        /*Debug.Log("INTERACT");*/
    }

    private void Update()
    {

        rotation = Vector3.up;
        transform.Rotate(rotation * speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, playerObject.transform.position);
        //Debug.Log(distance.ToString());
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

