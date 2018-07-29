using UnityEngine;
using System.Collections;

public class XiaoDiTu : MonoBehaviour {


    //public Transform xiaoditu;
	// Use this for initialization

    bool XiaoDiTuDisplay;
    bool XiaoDiTuDisplayMap;
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {

        if (XiaoDiTuDisplayMap)
        {

            if (Input.GetMouseButtonUp(0)) //主要功能为实现了大将的行为显示
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
               // Physics.Raycast(ray, out hit);

                Transform parent;
               GameObject xiaoditu;
                parent = this.transform.parent;
                xiaoditu = parent.transform.Find("xiao_di_tu").gameObject;
                if ((!Physics.Raycast(ray, out hit)) || (hit.collider.gameObject != xiaoditu))
                {
                   // print("%%%%%%%%%%% xiaoditu=" + xiaoditu);
                   // print("%%%%%%%%%%% hit=" + hit.collider.gameObject);
                   // if (hit.collider.gameObject != xiaoditu)
                   // {

                        xiaoditu.gameObject.SetActive(false);
                        XiaoDiTuDisplay = false;
                  //  }

                }

                
            }

        }
    }

    void LateUpdate()
    {
        XiaoDiTuDisplayMap = XiaoDiTuDisplay;
    
    
    }

    void OnMouseUpAsButton()
    {
        Transform parent;

       Transform xiaoditu;
       parent = this.transform.parent;
        xiaoditu = parent.transform.Find("xiao_di_tu");

        if (!XiaoDiTuDisplay)
        {
            xiaoditu.gameObject.SetActive(true);

            XiaoDiTuDisplay = true;
        }
       /* else
        {
            xiaoditu.gameObject.SetActive(false);
            XiaoDiTuDisplay = false;
         
        
        
        }*/
        //xiaoditu.Set
    }




}
