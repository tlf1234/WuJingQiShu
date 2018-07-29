using UnityEngine;
using System.Collections;

public class JiangJunLing : MonoBehaviour {

	// Use this for initialization
    bool IsDisplay;
    public Vector3 OreginScale;
    public Vector3 OreginPosition;
    public Vector3 BiggerScale;
    public Vector3 BiggerPosition;
	void Start () {
        OreginScale = new Vector3(0.6F, 0.5F, 0);
        OreginPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        BiggerScale = new Vector3(1.2f, 1f, 0);
        BiggerPosition = new Vector3(OreginPosition.x + 1.2f, OreginPosition.y + 2f, OreginPosition.z-2f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp() 
    {
        print("************* 01");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

           // Vector3 OreginPosition = hit.collider.gameObject.transform.position;
           // Vector3 BiggerPosition = new Vector3(OreginPosition.x + 1.2f, OreginPosition.y + 3f, OreginPosition.z);
            if (IsDisplay)
            {
                print("************* 02");
                this.gameObject.transform.position = OreginPosition;
                this.gameObject.transform.localScale = OreginScale;
                IsDisplay=false;
                return;
            }
            
            if (!IsDisplay) 
            {
                print("************* 03");
                this.gameObject.transform.position = BiggerPosition;
                this.gameObject.transform.localScale = BiggerScale;
                IsDisplay = true;
                return;
            }
        
        
        }
    
    }
}
