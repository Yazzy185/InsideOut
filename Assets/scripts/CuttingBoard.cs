using System;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{

	//jasper heeft 99% gedaan, i learned, i watched	
	public Transform[] VegetablePosition;
	public List<GameObject> vegetablesOnCuttingBoard;
	public Sliceable[] prefabs;
	public Transform vegetablesSpawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int i = 0;
		foreach(var prefab in prefabs)
		{
			Sliceable slicer = Instantiate (prefab, vegetablesSpawnPosition.position + new Vector3(i, 0, 0), prefab.transform.rotation);
			slicer.OnSelected += Slicer_OnSelected;
			i++;
		}
    }

	private void Slicer_OnSelected (GameObject obj)
	{
		vegetablesOnCuttingBoard.Add(obj);
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vegetablesOnCuttingBoard.Count; i++)
		{
			var currentVegetable = vegetablesOnCuttingBoard[i];
			var targetPos = VegetablePosition[0].position;
			if (i < vegetablesOnCuttingBoard.Count - 1)
			{
				targetPos = VegetablePosition[1 + i].position;
			}
			var offset = targetPos-currentVegetable.transform.position;
			offset.y = 0;
			targetPos.y += offset.magnitude;
			currentVegetable.transform.position = Vector3.Lerp(targetPos, currentVegetable.transform.position, Mathf.Pow(0.05f, Time.deltaTime));
		}
    }
}
