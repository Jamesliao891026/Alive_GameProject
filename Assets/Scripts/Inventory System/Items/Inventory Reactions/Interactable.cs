using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 0.8f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;  

    private void Update()
    {
        if (isFocus)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);
            if (!hasInteracted && distance <= radius)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
        Debug.Log("OnDefocused");
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with " + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(interactionTransform.position, radius);
    }
}
