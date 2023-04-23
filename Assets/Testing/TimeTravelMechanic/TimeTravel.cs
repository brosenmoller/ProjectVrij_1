using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] private Transform world1;
    [SerializeField] private Transform world2;

    [Header("Other Settings")]
    [SerializeField] private LayerMask notPlayerLayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Transform currentWorld = transform.parent;

            if (currentWorld == world1) { SwitchWorld(world2); }
            else { SwitchWorld(world1); }
        }
    }

    private void SwitchWorld(Transform targetWorld)
    {
        Vector3 playerRelativePosition = transform.localPosition;
        

        if (Physics.CheckSphere(targetWorld.position + playerRelativePosition, .2f, notPlayerLayer))
        {
            // Maybe we want some code here to find a valid location nearby, but I just disallow it for now
            Debug.Log("Can't switch now");
        }
        else
        {
            transform.parent = targetWorld;
            transform.localPosition = playerRelativePosition;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(world1.position + transform.localPosition, .2f);
        Gizmos.DrawWireSphere(world2.position + transform.localPosition, .2f);
    }
}
