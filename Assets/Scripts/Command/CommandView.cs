﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CommandView : MonoBehaviour
{
    public static CommandView Instance;
    List<string> contentList = new List<string>();

    public Text textView;
    public RectTransform content;
    private void Awake()
    {
        Instance = this;
        content = this.transform.Find("Content").GetComponent<RectTransform>();
        textView = content.transform.Find("Text").GetComponent<Text>();


    }


    public void setCommand(string value)
    {

        contentList.Add("System call: "+value+"\n");
        contentList.Add("System do:    " + value + "\n");

    }

    public void setCommandWithoutPrefix(string value)
    {
        textView.text +=  value + "\n";

    }


    string tempStr;
    
    public void setDynamicData(string value)
    {
        textView.text = value;

    }
    bool allowWriteCommand;
    string tep2 = "";
    string tep3 = "";
    public string dynamicStr = "";

    
    private void Update()
    {

       
        tempStr = "";
        tep3 = "";
        foreach (string key in contentList)
        {

            tempStr += key;

         
        }


        if (allowWriteCommand == false)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {


                tep2 = "System call：";



                allowWriteCommand = true;






            }
        }
        


        if (allowWriteCommand == true)
        {

          


            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode)&& keyCode != KeyCode.Return && keyCode != KeyCode.CapsLock )
                    {
                        //Debug.LogError("Current Key is : " + keyCode.ToString());


                        if (Input.GetKeyDown(KeyCode.Alpha1))
                        {
                            dynamicStr += "1";
                            continue;
                        }


                        if (Input.GetKeyDown(KeyCode.Alpha2))
                        {
                            dynamicStr += "2";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha3))
                        {
                            dynamicStr += "3";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha4))
                        {
                            dynamicStr += "4";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha5))
                        {
                            dynamicStr += "5";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha6))
                        {
                            dynamicStr += "6";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha7))
                        {
                            dynamicStr += "7";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha8))
                        {
                            dynamicStr += "8";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha9))
                        {
                            dynamicStr += "9";
                            continue;
                        }
                        if (Input.GetKeyDown(KeyCode.Alpha0))
                        {
                            dynamicStr += "0";
                            continue;
                        }

                        if (Input.GetKeyDown(KeyCode.Tab))
                        {
                            dynamicStr += ":";
                            continue;
                        }

                        if (keyCode == KeyCode.Space)
                        {
                            dynamicStr += " ";
                           
                            continue;
                        }
                        
                        dynamicStr += keyCode.ToString();
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Return)&& dynamicStr != "")
            {

                Debug.Log("命令键入完毕");


               // setDynamicData();

                LocalMoveManager.Instance.strategy = new MoveStrategy(LocalPlayer.player.gameObject, dynamicStr, LocalMoveManager.Instance);

                //SkillReleaseManager.Instance.touch(LocalPlayer.player.gameObject);

               // contentList.Add(tep2 + dynamicStr + "\n");
                content.localPosition += new Vector3(0, 15);
               
               

                contentList.Add("System do:    " + dynamicStr + "\n");
                tep2 = "";
                dynamicStr = "";
                allowWriteCommand = false;
            }

        }


        textView.text = tempStr + tep2 + dynamicStr;
    }


}