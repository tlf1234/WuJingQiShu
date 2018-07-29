using UnityEngine;
using System.Collections;

public class ZuoBiaoDian : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUpAsButton()
    {
        print("%%%%%%%%%%%%% 01");
        if (this.gameObject.name.CompareTo("zuobiaodian_TongGuan") == 0)
        {
            WarSinceManager.instance.SetDisIndex(0);
            


        }
        if (this.gameObject.name.CompareTo("zuobiaodian_XiangYang") == 0)
        {
            WarSinceManager.instance.SetDisIndex(1);
            print("%%%%%%%%%%%%% zuobiaodian_XiangYang");
        
        
        }
        if (this.gameObject.name.CompareTo("zuobiaodian_DaTong") == 0)
        {
            WarSinceManager.instance.SetDisIndex(2);
           


        }



    }




}
