using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DaJiangManager : MonoBehaviour {

    public static DaJiangManager instance;

   // Transform[] My_dajiang;
    List<Transform> MyFightDaJiang=new List<Transform>();
    List<Transform> EnemyFightDaJiang = new List<Transform>();

    GameObject SelectDaJiang;
    DaJiang DaJiangScript;


    Vector3 StartPoint;
    Vector3 EndPoint;
    public Vector3 EnemyWarPoint;
    public Vector3 MyWarPoint;

    public Transform zhandoubiaozhi;
    public int test;



    bool IsSlectDaJiangStart;
    bool IsSlectDaJiangEnd;
    bool EnimyBanIsDisplay;
    bool IsZheZhao;

    void Awake() {
        instance = this;
    
    }


	// Use this for initialization
	void Start () {

        MyWarPoint = new Vector3(18.8f, -9f, 110f);
        EnemyWarPoint = new Vector3(-19.42f, 7.8f, 110f);
        IsSlectDaJiangStart = false;
        IsSlectDaJiangEnd = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(1))
        {  //测试用
            IsZheZhao = false;
            /*print("***********" + gameObject);
            string a = "Huamulan";
            GameObject b = gameObject.transform.Find(a).gameObject;
            print("***********" +b );*/

        }


        if (Input.GetMouseButtonUp(0))
        {
            if (IsSlectDaJiangEnd)
            {

                Vector3 pos = Input.mousePosition;

                print("Camera pos" + pos);
                pos = new Vector3(pos.x, pos.y, 120);
                
                pos = Camera.main.ScreenToWorldPoint(pos);//这个方法对于透视图下无效，换一个方法


              /*  GameObject tempgamekobject = new GameObject("tempgo");
                tempgamekobject.transform.position = pos;
                tempgamekobject.transform.parent = GameObject.Find("BackGround").transform;
                pos = tempgamekobject.transform.localPosition;
                //把鼠标点击获得的世界坐标转换为本地目标*/

                print("move end" + pos);
               //pos = GameObject.Find("BackGround").transform.localPosition(pos);
                StartCoroutine(MoveTo(pos));///
                return;


            }
        }

	}

    void LateUpdate() {

        IsSlectDaJiangEnd = IsSlectDaJiangStart;
    
    }

   public void print(){
       print("***********" + test);
   }


   public void SetSelectDaJiangStart(bool selectDaJiangStart) {

       IsSlectDaJiangStart = selectDaJiangStart;
   }

   public bool  GetSelectDaJaingEnd() {
       return IsSlectDaJiangEnd;
   }

   

     public void GetSelectDaJiang(string selectdajiang) {
       
        // SelectDaJiang = gameObject.transform.Find(selectdajiang).gameObject;//获得点击对象

         SelectDaJiang = GameObject.Find(selectdajiang);
      
         DaJiangScript = SelectDaJiang.GetComponent<DaJiang>();//获得点击对象的脚本
        
    }




    IEnumerator MoveTo(Vector3 pos)
    {


        /*  if (MoveButtonClick)     //添加一个确定按钮
          {
                                 //未调用下面

              MoveButtonClick = false;
              Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;
              if ((Physics.Raycast(ray, out hit))&&(hit.collider.gameObject != this.gameObject)) {
                  EndPoint = hit.collider.gameObject.transform.position;
            
            
              }*/
        IsSlectDaJiangStart= false;
        DaJiangScript.CancellDisplay();
        StartPoint = SelectDaJiang.transform.position;
        //StartPoint = GameObject.Find("BackGround").transform.transform.TransformPoint(StartPoint);
       print("%%%%StartPoint"+StartPoint);
        EndPoint = pos;
        print("%%%%EndPoint" + EndPoint);
        AnimationClip ret = new AnimationClip();
        ret.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Linear(0, StartPoint.x, 1, EndPoint.x));
        ret.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Linear(0, StartPoint.y, 1, EndPoint.y));
        ret.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Linear(0, StartPoint.z, 1, EndPoint.z));


        SelectDaJiang.animation.AddClip(ret, "Move");
        if (SelectDaJiang.animation)
        {
            SelectDaJiang.animation.Blend("Move", 60);
        }

        yield return new WaitForSeconds(1.1f);
        Vector3 RayPosition = SelectDaJiang.transform.position;  //用于改变选定大将发射射线的位置
        print("%%%%StartPoint" + RayPosition);
        RayPosition.z = 118;
        SelectDaJiang.transform.position = RayPosition;
        RaycastHit hitInfo_forward;
        //RaycastHit hitInfo_back;
        bool IsCollideForward;
        //bool IsCollideBack;

        // EnemyObject=hitInfo.collider.gameObject;
        bool forward= Physics.Raycast(SelectDaJiang.transform.position, Vector3.forward , out hitInfo_forward);
        //bool back = Physics.Raycast(SelectDaJiang.transform.position, Vector3.forward , out hitInfo_back);
     

       // print("*******************03" + hitInfo_forward.collider.gameObject);
       // print("*******************" + hitInfo1.collider.gameObject);
         if (forward)
         {
             print("*******************04" + hitInfo_forward.collider.gameObject);
             IsCollideForward= hitInfo_forward.collider.gameObject.GetComponent<DaJiang>().GetIsDaJiang();
            if (IsCollideForward) 
            {
                print("*******************05" + hitInfo_forward.collider.gameObject);
              BackToWarPosition( hitInfo_forward);

                //
              GameObject enimyban = EnimyBanDisplay();
              
             //
            
             Transform zhanbiaozhi=(Transform)Instantiate(zhandoubiaozhi, hitInfo_forward.collider.gameObject.transform.position, transform.rotation);//生成战斗标志
             zhanbiaozhi.parent = WarSinceManager.instance.WarSinceList[0];

                if(enimyban!=null)
                {
                    enimyban.transform.parent = WarSinceManager.instance.WarSinceList[0];
             //StartCoroutine(BackToWarPosition(hitInfo_forward));
                }
            }
         }
        /*if(back){
            print("*******************04" + hitInfo_back.collider.gameObject);
            IsCollideBack = hitInfo_back.collider.gameObject.GetComponent<DaJiang>().GetIsDaJiang();
            if (IsCollideBack)
            {
                BackToWarPosition( hitInfo_back);
                //StartCoroutine(BackToWarPosition(hitInfo_forward));
            }
        }*/
    }


   void BackToWarPosition(RaycastHit hitinfo)
    {

        RaycastHit hitInfo = hitinfo;
        AnimationClip EnemyRet = new AnimationClip();
        EnemyRet.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Linear(0, hitInfo.collider.gameObject.transform.position.x, 1, EnemyWarPoint.x));
        EnemyRet.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Linear(0, hitInfo.collider.gameObject.transform.position.y, 1, EnemyWarPoint.y));
        EnemyRet.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Linear(0, hitInfo.collider.gameObject.transform.position.z, 1, EnemyWarPoint.z));

        AnimationClip MyRet = new AnimationClip();
        MyRet.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Linear(0, SelectDaJiang.transform.position.x, 1, MyWarPoint.x));
        MyRet.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Linear(0, SelectDaJiang.transform.position.y, 1, MyWarPoint.y));
        MyRet.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Linear(0, SelectDaJiang.transform.position.z, 1, MyWarPoint.z));


        hitInfo.collider.gameObject.animation.AddClip(EnemyRet, "EnemyMoveback");
        SelectDaJiang.animation.AddClip(MyRet, "MyMoveback");
        if ((SelectDaJiang.animation) && (hitInfo.collider.gameObject.animation))
        {
            SelectDaJiang.animation.Blend("MyMoveback", 60);
            hitInfo.collider.gameObject.animation.Blend("EnemyMoveback", 60);
        }
       // yield return new WaitForSeconds(2.5f);
       MyFightDaJiang.Add(SelectDaJiang.transform);  //注意后面要有从该Lsit中取出的情况
       SelectDaJiang.transform.GetComponent<DaJiang>().SetIsDaJiangFighting(true); //设置List中的每一个大将为战斗状态
       SelectDaJiang.transform.GetComponent<DaJiang>().SetMyDaJiang(true);
       EnemyFightDaJiang.Add(hitInfo.collider.gameObject.transform);
       hitInfo.collider.gameObject.transform.GetComponent<DaJiang>().SetIsDaJiangFighting(true);//设置List中的每一个大将为战斗状态
       // FightDaJiangPositionChange();
        StartCoroutine(FightDaJiangPositionChange());

    }

   IEnumerator FightDaJiangPositionChange()
   {
      // DaJiangScript.SetIsDaJiangFighting(true);  //还有敌人没有设置该功能
       yield return new WaitForSeconds(1.2f);
        int Mx=0;
        int Ex = 0;
        print("+++++++++++++ 01" + MyFightDaJiang.Count);
        foreach (Transform t in MyFightDaJiang) {  //后面参考炉石代码调节一下动画
           /*Vector3 p = t.localPosition;
            p.x = MyWarPoint.x+ x* 2;
            t.localPosition = p;*/

            iTween.MoveBy(t.gameObject, Vector3.left * 2f * Mx, 1);
            Mx++;
        }
       //print("+++++++++++++ 01")
        foreach (Transform t in EnemyFightDaJiang)
        {  
            iTween.MoveBy(t.gameObject, Vector3.right * 2f * Ex, 1);
            Ex++;
        }
        IsZheZhao = true;
    }

   GameObject EnimyBanDisplay() 
   {
       GameObject enimyban=null;
       if (!EnimyBanIsDisplay)
       {
            enimyban = this.gameObject.transform.Find("EnimyBan").gameObject;
            enimyban.SetActive(true);
           EnimyBanIsDisplay = true;
       }
       return enimyban ;

   }

   /*void OnGUI()
   {
       if (IsZheZhao)
       {
           
           GUI.Button(new Rect((Screen.width / 2) - 180, (Screen.height / 2) -120, (Screen.width / 2) + 10, (Screen.height / 2) + 5), "");

       }
       

   }*/



}
