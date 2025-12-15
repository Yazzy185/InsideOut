using UnityEngine;

public class KnifeAnimationScript : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * 5, 0);
    }
}
