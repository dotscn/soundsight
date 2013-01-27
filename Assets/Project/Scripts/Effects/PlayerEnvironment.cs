using UnityEngine;
using System.Collections;
using Assets.Scripts.Singleton;

public class PlayerEnvironment : MonoBehaviour
{
    public float Proximity = 25;
    public Color WallColor = Color.white;
    public Material SightMaterial;
    public Material SightGroundMaterial;

	// Use this for initialization
	void Start () 
    {
        if(SightMaterial == null)
            Debug.LogError("Sight Material has nothing attached!");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Proximity))
        {
            if(hit.collider.gameObject.tag=="Wall")
            {
                SightMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * 20)));
                SightGroundMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * 20)));
            }
                
        }
        else
        {
            SightMaterial.SetColor("_Color", Color.black);
        }
	}
}
