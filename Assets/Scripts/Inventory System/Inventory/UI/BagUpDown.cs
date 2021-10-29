using UnityEngine;

public class BagUpDown : MonoBehaviour
{
    public bool bagIsUp = false;
    public GameObject bag;

    private void Start()
    {
        bagIsUp = false;
        bag.transform.localPosition = new Vector2(0, -570);
    }

    public void PanelMove()
    {
        Debug.Log("left mouse");
        if (bagIsUp == false)
        {
            bag.transform.localPosition = new Vector2(0, -450);
            bagIsUp = true;
            Debug.Log("open");
            return;
        }
        if (bagIsUp == true)
        {
            bag.transform.localPosition = new Vector2(0, -570);
            bagIsUp = false;
            Debug.Log("close");
            return;
        }
    }
}
