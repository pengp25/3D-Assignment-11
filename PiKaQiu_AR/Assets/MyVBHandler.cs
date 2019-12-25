using UnityEngine;
using System.Collections;
using Vuforia;
using System;
 
public class MyVBHandler : MonoBehaviour, IVirtualButtonEventHandler{
    Material m1;
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        print("按下放大"+vb.VirtualButton.Area.leftTopX);
        Vector3 v3 = transform.localScale;
         transform.localScale = new Vector3(v3.x*1.2f, v3.y*1.2f, v3.z*1.2f);
    }
 
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        print("释放按钮"+vb.VirtualButton.Area.leftTopX);
    }
   
    // Use this for initialization
    void Start () {
        m1 = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
             vbs[i].RegisterEventHandler(this);//把ImageTarget下所有含有VirtualButtonBehaviour组件的物体注册过来（使用前面写的Pressed和Released方法处理）。
        }
    }
 
}