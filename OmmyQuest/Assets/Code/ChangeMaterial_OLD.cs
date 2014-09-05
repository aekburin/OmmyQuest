using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeMaterial_OLD : MonoBehaviour
{
    public List<GameObject> ObjectOrgan;
    public List<Material> Material;
    public int defaultMaterial;
    public int currentMaterial;
	// Use this for initialization
	void Start () {
        currentMaterial = defaultMaterial;

        foreach (GameObject item in ObjectOrgan)
        {
            item.renderer.material = Material[defaultMaterial];

        }
	}

    public void NextMaterial()
    {
        if ((currentMaterial + 1) > Material.Count - 1)
        {
            currentMaterial = 0;

            foreach (GameObject item in ObjectOrgan)
            {
                item.renderer.material = Material[currentMaterial];

            }
        }
        else
        {
            currentMaterial += 1;
            foreach (GameObject item in ObjectOrgan)
            {
                item.renderer.material = Material[currentMaterial];
            }
        }

       
    }
    public void PrevioussMaterial()
    {
        if ((currentMaterial - 1) < 0)
        {
            currentMaterial = Material.Count - 1;

            foreach (GameObject item in ObjectOrgan)
            {
                item.renderer.material = Material[currentMaterial];
            }

        }
        else
        {
            currentMaterial -= 1;

            foreach (GameObject item in ObjectOrgan)
            {
                item.renderer.material = Material[currentMaterial];
            }
        }

    }
    public void SaveMeterial()
    {
        /*indexDefaultMeterial = currentIndexMaterial;
        renderer.material = Meterial[indexDefaultMeterial];
        PlayerPrefs.SetInt("IndexMaterialPlayer", indexDefaultMeterial);*/
    }
    public void ResetToBeginMeterial()
    {
        //renderer.material = Meterial[indexDefaultMeterial];
    }
	// Update is called once per frame
	void Update () {
	
	}

    /*void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 100), "Next"))
        {
            NextMaterial();
        }

        if (GUI.Button(new Rect(100, 200, 100, 100), "Previous"))
        {
            PreviousMaterial();
        }

        if (GUI.Button(new Rect(100, 300, 100, 100), "Back"))
        {
            ResetToBeginMeterial();
        }
        if (GUI.Button(new Rect(200, 100, 100, 100), "Save"))
        {
            SaveMeterial();
        }
    }*/
}
