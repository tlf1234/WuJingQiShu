using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JiangJunLingManager : MonoBehaviour {

   public List<Transform> LingList = new List<Transform>();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    AnimationClip moveto(Vector3 start, Vector3 end)
    {
        AnimationClip ret = new AnimationClip();
        ret.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Linear(0, start.x, 2, end.x));
        ret.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Linear(0, start.y, 2, end.y));
        ret.SetCurve("", typeof(Transform), "localPositin.z", AnimationCurve.Linear(0, start.z, 2, end.z));
        return ret;
    
    }

    /*IEnumerator firstdraw()
    { 
    Vector3 [] fpoint =new Vector3[4];
    fpoint[0] = new Vector3(-11f,1.5f,118);
    
    
    
    
    }*/



}
