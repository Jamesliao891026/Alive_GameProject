using UnityEngine.EventSystems;
using UnityEngine;

public class Inventory_PlayerController : MonoBehaviour
{
    public Interactable focus = null;

    [Header("Detaction Field")]
    public Transform detactionPoint;
    public float detactionRadius = 0.2f;
    public LayerMask detactionLayer;


    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(Input.GetKeyDown(KeyCode.B))
        {
            OnTriggerInteract();
        }    
    }
    void OnTriggerInteract()
    {
        Collider2D obj = Physics2D.OverlapCircle(detactionPoint.position, detactionRadius, detactionLayer);
        if (obj == null)
        {
            Debug.Log("No object !");
            RemoveFocus();
        }
        else
        {
            Interactable interactable = obj.GetComponent<Interactable>();
            SetFocus(interactable);
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
            Debug.Log("HI1");
        }
        focus = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(detactionPoint.position, detactionRadius);
    }
}
