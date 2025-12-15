using UnityEditor.U2D;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public event System.Action<GameObject> OnSelected;
	
	public void OnMouseDown()
    {
        OnSelected?.Invoke(gameObject);
    }
}