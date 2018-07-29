using UnityEngine;
using System.Collections;

public class HideButton : MonoBehaviour {

    private bool IsHide;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUpAsButton() 
    {
        int index = WarSinceManager.instance.GetDisIndex();
        print("############# IsHide" + IsHide);
        if (!IsHide)
        {
            if (index == 0)
            {
                foreach (Transform t in WarSinceManager.instance.DaJiangList_0)
                {
                    if (t != null)
                    {
                        t.gameObject.SetActive(false);
                    }


                }
            }

            if (index == 1)
            {
                foreach (Transform t in WarSinceManager.instance.DaJiangList_1)
                {
                    if (t != null)
                    {
                        t.gameObject.SetActive(false);
                    }


                }
            }

            if (index == 2)
            {
                foreach (Transform t in WarSinceManager.instance.DaJiangList_2)
                {
                    if (t != null)
                    {
                        t.gameObject.SetActive(false);
                    }


                }
            }



           /* GameObject enimyban = this.gameObject.transform.Find("EnimyBan").gameObject;
            enimyban.SetActive(false);*/
            
            IsHide = true;


        }

        else
        {
            if (index == 0)
            {
                foreach (Transform t in WarSinceManager.instance.DaJiangList_0)
                {
                    if (t != null)
                    {
                        t.gameObject.SetActive(true);
                    }


                }
            }

            if (index == 1)
            {
                foreach (Transform t in WarSinceManager.instance.DaJiangList_1)
                {
                    if (t != null)
                    {
                        t.gameObject.SetActive(true);
                    }


                }
            }

            if (index == 2)
            {
                foreach (Transform t in WarSinceManager.instance.DaJiangList_2)
                {
                    if (t != null)
                    {
                        t.gameObject.SetActive(true);
                    }


                }
            }
            IsHide = false;


        }
    }
}
