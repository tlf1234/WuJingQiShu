using UnityEngine;
using System.Collections;

public class DaJiang : MonoBehaviour
{

    private int Solsiers;
    private int AttackPower;
    private int DefenPower;
    private int LiangCao;
    //private Skill skill;
    bool IsMine;
    bool IsCanAttack;

    Transform Position;
                          //要被消灭时状态
                          //攻击者
                          //被攻击者
    bool IsArrive;    //大将是否到达目的地
   

    SpriteRenderer DaJiang_income; //注意SpriteRenderer是渲染器，Sprite是精灵

    Transform move_button; //获得对像可用两种方法，一个是Transform,另一个是gameobject,
    Transform display_btton;
    
    enum DaJiangAction { 
       
         ScaleDisplay,
         Move

    }


    bool IsDaJiang;  //用于碰撞时判断是否为大将对象
    bool Isdisplay;
    bool IsDaJiangFighting;//大将是否在战斗位置
   // bool MoveButtonClick;
   // static bool MoveEnable;  //每一个实例对象都会共用同一个静态变量
    public Vector3 OreginScale;
    public  Vector3 BiggerScale;

    
    
   // GameObject EnemyObject;
    void Start() {
        Isdisplay = false;
        OreginScale=new Vector3(0.56F,0.48F,0);
        BiggerScale = new Vector3(1f, 0.8f, 0);
        
       // MoveButtonClick = false;
       // MoveEnable = false;
        IsDaJiang = true;
        IsDaJiangFighting = false;
        //TempCamera = this.transform.Find("Camera").gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        //尽量做到不用update函数看能否实现

        if (Input.GetMouseButtonUp(1)) {  //测试用

           // GameObject c = this.gameObject.transform.Find("Huamulan").gameObject;
           // print("&&&&&&&&&&&&&" + c);
           // string a = "Huamulan";
           // GameObject b = gameObject.transform.Find(a).gameObject;
        
        }

        
       if (Isdisplay)  //先用条件进行判断，使得鼠标按下时不会轻易执行下面动作
        {
                 //这些应该都放到大将管理器中进行，这样就不会由于大将的多个导致这些函数多次执行
           if (Input.GetMouseButtonUp(0)) //主要功能为实现了大将的行为显示
            {
                   
              Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                   RaycastHit hit;
             //看如何添加一个对象的识别后再进行下述操作
            
                
                   //print("MoveButtonClick" + hit.collider.gameObject.name+MoveButtonClick);
                  // print("Isdisplay" + hit.collider.gameObject.name + Isdisplay);

                   if (!Physics.Raycast(ray, out hit))
                   {
                       CancellDisplay();
                       
                   }
                   else 
                   {

                       if ((hit.collider.gameObject != this.gameObject)&&(hit.collider.gameObject != this.gameObject.transform.Find("Display_button").gameObject)
                           && (hit.collider.gameObject != this.gameObject.transform.Find("Move_button").gameObject))//以后看看gameOgject或者name比较的效率更高
                       {
                           //print(hit.collider.gameObject);
                          // print(this.gameObject.transform.Find("Display_button").gameObject);
                           CancellDisplay();
                          
                       }
                   }
            }
           
        }
    }

    public void SetMyDaJiang(bool ismine) {
        IsMine = ismine;
    }
   



    void OnMouseUp() {  //注意该函数只在 
                       //是否对点击对象做一个认定？？
        if (Isdisplay && !(DaJiangManager.instance.GetSelectDaJaingEnd()))// && !MoveEnable
        {

           CancellDisplay();
        }
        else if (!DaJiangManager.instance.GetSelectDaJaingEnd())           //该条件使被挑战大将在点击时不显示  if(!MoveEnable) 
        {
           // print("########" +this.gameObject.name);

            DaJiangManager.instance.GetSelectDaJiang( this.gameObject.name.ToString());          //把该选中的大将上报到管理器中

           DisPlayAction();
        }
    }
    
    public void AddSolsier()
    {


    }
    
   

    private void print(string p1, float p2)
    {
        throw new System.NotImplementedException();
    }


    void DisPlayAction()  //显示行为按钮 //对于手机改为touch方法
    {
        Isdisplay = true;
        //后面要加上是否为自己的大将的判断条件。
        //可采用点一下就放大，并出现行军按钮，对于别人的点一下只进行放大。
        print("+++++++++++02 IsDaJiangFighting" + IsDaJiangFighting);
        if (!IsDaJiangFighting)//大将在战斗时点击不显示按钮
        {
            display_btton = this.transform.FindChild("Display_button");
            move_button = this.transform.Find("Move_button");

            

            if (display_btton != null && move_button != null)
            {   
                display_btton.gameObject.SetActive(true);
                //transform.FindChild("DispPlsy_button").gameObject.SetActive(true);
                move_button.gameObject.SetActive(true);

            }
            
        }
        if (IsDaJiangFighting)
        {
            //在战争状态时显示情况
            if (!IsMine)
            {
                Vector3 forwaedPositionFight = this.gameObject.transform.position;
                //forwaedPositionFight.z = 108;//向上移动

                Vector3 BiggerPosition = new Vector3(forwaedPositionFight.x + 2f, forwaedPositionFight.y - 2.4f, 108);
                this.gameObject.transform.position = BiggerPosition;
                this.gameObject.transform.localScale = BiggerScale;
                //
                return;

            }
            if (IsMine) {

                Vector3 forwaedPositionFight = this.gameObject.transform.position;
                //forwaedPositionFight.z = 108;//向上移动

                Vector3 BiggerPosition = new Vector3(forwaedPositionFight.x -1.8f, forwaedPositionFight.y +1.7f, 108);
                this.gameObject.transform.position = BiggerPosition;
                this.gameObject.transform.localScale = BiggerScale;
                //
                return;
            
            
            }
            
        }
        Vector3 forwaedPosition = this.gameObject.transform.position;
        print("%%%%%%%%%%%% 04 forwaedPosition" + forwaedPosition);
        forwaedPosition.z = 118;//向上移动
        this.gameObject.transform.position = forwaedPosition;
        print("%%%%%%%%%%%% 05 forwaedPosition" + forwaedPosition);
        this.gameObject.transform.localScale = BiggerScale;
        //需再添加一个放大步骤
        
        
    }

    public void CancellDisplay()
    {
        
        Isdisplay = false;
        if (display_btton!=null){
           display_btton.gameObject.SetActive(false);
           move_button.gameObject.SetActive(false);

        }
        if (IsDaJiangFighting)
        {
            //在战争状态时显示情况
            if (!IsMine)
            {
                Vector3 backPositionFight = this.gameObject.transform.position;
                // backPositionFight.z = 110;//向上移动
                Vector3 OreginPosition = new Vector3(backPositionFight.x - 2f, backPositionFight.y + 2.4f, 110);
                this.gameObject.transform.position = OreginPosition;
                this.gameObject.transform.localScale = OreginScale;
                //
                return;


            }
            
            if (IsMine)
            {

                Vector3 backPositionFight = this.gameObject.transform.position;
                // backPositionFight.z = 110;//向上移动

                Vector3 OreginPosition = new Vector3(backPositionFight.x + 1.8f, backPositionFight.y - 1.7f, 110);
                this.gameObject.transform.position = OreginPosition;
                this.gameObject.transform.localScale = OreginScale;
                //
                return;


            }
        }

        Vector3 backPosition = this.gameObject.transform.position; //返回到原来的位置
        backPosition.z = 120;
        this.gameObject.transform.position= backPosition;
        this.gameObject.transform.localScale = OreginScale;
       // MoveButtonClick = false;
      
    }

    public void SetIsDaJiangFighting(bool Isfighting)
    {
        print("++++++++++++03 Isfihting" + Isfighting);
        IsDaJiangFighting = Isfighting;
    }

    
    /*IEnumerator MoveTo(Vector3 pos)
    {


       // if (MoveButtonClick)     //添加一个确定按钮
        {
                               //未调用下面

            MoveButtonClick = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit))&&(hit.collider.gameObject != this.gameObject)) {
                EndPoint = hit.collider.gameObject.transform.position;
            
            
            }//

            CancellDisplay();
            StartPoint = this.gameObject.transform.localPosition;
            print(StartPoint);
            print(EndPoint);
            EndPoint = pos;
            AnimationClip ret = new AnimationClip();
            ret.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Linear(0, StartPoint.x, 2, EndPoint.x));
            ret.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Linear(0, StartPoint.y, 2, EndPoint.y));
            ret.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Linear(0, StartPoint.z, 2, EndPoint.z));


            this.gameObject.animation.AddClip(ret, "Move");
            if (this.gameObject.animation)
            {
                this.gameObject.animation.Blend("Move", 60);
            }

            yield return new WaitForSeconds(2.1f);
            RaycastHit hitInfo;
           // EnemyObject=hitInfo.collider.gameObject;
            if (Physics.Raycast(this.gameObject.transform.position, Vector3.forward, out hitInfo) && hitInfo.collider.gameObject.GetComponent<DaJiang>().IsDaJiang)
            {

                print("*******************");//返回到各自的战争位置  
                BackToWarPosition( ref hitInfo);
                
            }


    }*/

    /*public  bool GetMoveEnable(){
    return MoveEnable;
    
    }*/

    public bool GetIsDaJiang() {

        return IsDaJiang;
    }

  /*  void SetMoveButtonClick(bool Click)
    {
        MoveButtonClick = Click;
                                //增加颜色改变提示
    }*/
   

}

