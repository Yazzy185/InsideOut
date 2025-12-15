using UnityEditor.U2D;
using UnityEngine;

public class SimpleSliceable : MonoBehaviour
{
    public GameObject[] slices;
	
	public void OnMouseDown()
    {
		if (!enabled) { return; }
		
        foreach (var obj in slices)
        {
            Instantiate(obj, transform.TransformPoint(obj.transform.position), transform.rotation * obj.transform.rotation);
        }
		Destroy(gameObject);
    }
}