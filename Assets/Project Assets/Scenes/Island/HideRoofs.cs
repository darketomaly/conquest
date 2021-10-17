using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class HideRoofs : MonoBehaviour
{
    //[SerializeField] private NavMeshAgent player;
    [SerializeField] private GameObject roofObject;
    [SerializeField] private GameObject roofMesh;
    // Start is called before the first frame update
    private bool hidden = false;

    void Start()
    {
        Debug.Log("Starting hide roof script");
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 temp = roofObject.transform.position;
        if (Vector3.Distance(temp, GameManager.localPlayer.transform.position) <= 15)
        {
            Debug.Log("Player in range");
            //Mesh mesh = GetComponent<MeshFilter>().mesh;
            if(hidden == false)
            {
                //hide the roof
                hidden = true;
                hideRoof(hidden);
            }

        }
        else //we are further than 15 squares away from the building, so hide it.
        {
            if (hidden == true)
            {
                //show the roof
                hidden = false;
                hideRoof(hidden);
            }
            
        }
    }

    void hideRoof(bool hide)
    {
        Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            Debug.Log(roofMesh.name);
            if (lRenderer.name == "roof")
            {
                lRenderer.enabled = !hide;
            }
        }
    }

}
