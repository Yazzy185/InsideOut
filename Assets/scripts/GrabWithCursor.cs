using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GrabWithCursor : MonoBehaviour
{

	Camera cam;
	public LayerMask pickUpLayerMask;

	public float rayDistance = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
         Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		 Debug.DrawRay(ray.origin,ray.direction * rayDistance, Color.green, 5);
		 bool hasHitObject = Physics.Raycast(ray, out RaycastHit hit, rayDistance ,pickUpLayerMask);
		 if (hasHitObject && hit.collider.TryGetComponent(out GrabbableItem grabbableItem))
		 	{
				Debug.Log(grabbableItem);
			}
	}
		
}
