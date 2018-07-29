using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarSinceManager : MonoBehaviour {


    public static WarSinceManager instance;
    // Use this for initialization
    //List<SpriteRenderer> SinceList=new List<SpriteRenderer>();

    
    public List<Transform> DaJiangList_0 = new List<Transform>();
    public List<Transform> DaJiangList_1 = new List<Transform>();
    public List<Transform> DaJiangList_2 = new List<Transform>();
    public List<Transform> WarSinceList = new List<Transform>();
    //GameObject gameobjecttemp;

    private int DisIndex;
   

    void Awake()
    {

        instance = this;

    }
	// Use this for initialization
	void Start () {

        //DaJiangObject.Add
        DisIndex = 0;
        CancleDisSince();
        DisPlaySince();
	
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}

     public void SetDisIndex(int index)
    {

        DisIndex = index;
        CancleDisSince();
        DisPlaySince();
    
    }

     public int GetDisIndex() {
         return DisIndex;
     
     }


     void DisPlaySince() 
     {

         if (DisIndex == 0) {
             GameObject gameobjecttemp = WarSinceList[0].gameObject;
             if (gameobjecttemp != null)
             {
                 gameobjecttemp.SetActive(true);
             }
             foreach (Transform t in DaJiangList_0)
             {
                 if (t != null)
                 {
                     t.gameObject.SetActive(true);
                 }


             }
         
         }

         if (DisIndex == 1)
         {
             GameObject gameobjecttemp = WarSinceList[1].gameObject;
             if (gameobjecttemp != null)
             {
                 gameobjecttemp.SetActive(true);
             }
             foreach (Transform t in DaJiangList_1)
             {
                 if (t != null)
                 {
                     t.gameObject.SetActive(true);
                 }


             }

         }

         if (DisIndex == 2)
         {
             GameObject gameobjecttemp = WarSinceList[2].gameObject;
             if (gameobjecttemp != null)
             {
                 gameobjecttemp.SetActive(true);
             }
             foreach (Transform t in DaJiangList_2)
             {
                 if (t != null)
                 {
                     t.gameObject.SetActive(true);
                 }


             }

         }

     
     
     }


     void CancleDisSince() {
         for (int i = 0; i <= 2; i++)
         {

             GameObject gameobjecttemp = WarSinceList[i].gameObject;
             if (gameobjecttemp != null)
             {
                 gameobjecttemp.SetActive(false);
             }
             

         }

         foreach (Transform t in DaJiangList_0)
         {
             if (t != null)
             {
                 t.gameObject.SetActive(false);
             }


         }

         foreach (Transform t in DaJiangList_1)
         {
             if (t != null)
             {
                 t.gameObject.SetActive(false);
             }


         }

         foreach (Transform t in DaJiangList_2)
         {
             if (t != null)
             {
                 t.gameObject.SetActive(false);
             }


         }
     
     
     }


}
