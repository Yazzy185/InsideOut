using UnityEditor.U2D;
using UnityEngine;

public class Sliceable : MonoBehaviour
{
    public GameObject[] cutSteps;
    public event System.Action<GameObject> OnSelected;

    public enum State { Waiting = 0, BusyCutting, FullyCut, Pan }
    public State state = State.Waiting;

	public int currentCutStep = 0;

	public GameObject [] knifeCutPositions;
	public GameObject knifeSpawnPos;
	public GameObject knife;

	void Awake()
	{
		if (knifeCutPositions.Length + 1 != cutSteps.Length)
		{
			Debug.LogError($"You need {cutSteps.Length-1} knife cut positions but you only have {knifeCutPositions.Length}!!!", gameObject);
		}
		for (int i = 0; i < cutSteps.Length; i++)
		{
			cutSteps[i].SetActive(i == 0);
		}
	}
	 
	private void OnMouseDown()
    {
        switch (state)
        {
            case State.Waiting:

                state = State.BusyCutting;
                OnSelected?.Invoke(gameObject);
                break;
            case State.BusyCutting:
				var knifeCutGameObject = knifeCutPositions[currentCutStep];

				

                cutSteps[currentCutStep].SetActive(false);
				currentCutStep += 1;
                cutSteps[currentCutStep].SetActive(true);

				if (knifeCutGameObject)
				{
					var knifeSpawnPos = knifeCutGameObject.transform.position + new Vector3(0, 1f, 0);
					var knifeSpawnRotation = knifeCutGameObject.transform.rotation;
					var thething = Instantiate(knife, knifeSpawnPos, knifeSpawnRotation);
					Destroy(thething, 0.2f);
				}
				

				if (currentCutStep + 1 >= cutSteps.Length)
				{
					state = State.FullyCut;
				}
                break;
            case State.FullyCut:

                break;
            case State.Pan:

                break;

        }
    }

}