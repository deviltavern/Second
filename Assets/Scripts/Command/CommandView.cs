using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class CommandView : MonoBehaviour
{
    public static CommandView Instance;


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
        textView.text += "系统命令：" + value + "\n";

    }
    bool allowWriteCommand;

    public string dynamicStr = "";
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            allowWriteCommand = true;
        }


        if (allowWriteCommand == true)
        {

            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode)&& keyCode != KeyCode.Return && keyCode != KeyCode.CapsLock )
                    {
                        //Debug.LogError("Current Key is : " + keyCode.ToString());
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
                setCommand(dynamicStr);


                LocalMoveManager.Instance.strategy = new MoveStrategy(LocalPlayer.player.gameObject, dynamicStr, LocalMoveManager.Instance);



                dynamicStr = "";
                allowWriteCommand = false;
            }

        }
    }


}