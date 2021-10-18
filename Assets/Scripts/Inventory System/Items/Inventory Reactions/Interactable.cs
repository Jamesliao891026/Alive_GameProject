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
            if (!hasInteracted )
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

public interface InteractableInterface
{
    void Update();
    void Interact();
}
