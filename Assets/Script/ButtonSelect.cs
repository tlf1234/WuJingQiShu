using UnityEngine;
using System.Collections;

public class ButtonSelect : MonoBehaviour {


    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

      
	
	}

    void OnMouseUpAsButton()
    {
        
       // print(this.gameObject.transform.Find("Display_button").gameObject);//注意该方法是不行的，因为没有相应的实例对象，如果改成标签应该可以
        if (this.gameObject.name.CompareTo("Display_button") == 0)
            print("click Display_button");//根据所选择的按钮执行相应的动作
        else {
          // D.SendMessage("SetMoveButtonClick",true);
            DaJiangManager.instance.SetSelectDaJiangStart(true);
            print("click Move_button");
        }
    }


}
