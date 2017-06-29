using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;//引用xml文件
using UnityEngine.SceneManagement;

public class beginDialog : MonoBehaviour {

    public GameObject xhordinaryM;
    public GameObject xhordinary;
    public GameObject xhsurprise;
    public GameObject xhguilty;
    public GameObject majoblackM;
    public GameObject majoblack;
    public GameObject majoordinary;
    public GameObject majosmile;
    public GameObject mengzhong;
    public UITextList roleName;
    public UITextList detail;
    private List<string> dialogues_list;//存放对话的list
    private int dialogue_index = 0;//对话索引
    private int dialogue_count = 0;//对话数量

    private string role;//当前在说话的角色
    private string role_detail;//当前在说话的内容
    // Use this for initialization
    void Start () {
        //不激活对象
        xhordinaryM.SetActive(false);
        xhordinary.SetActive(false);
        xhsurprise.SetActive(false);
        xhguilty.SetActive(false);
        majoblackM.SetActive(false);
        majoblack.SetActive(false);
        majoordinary.SetActive(false);
        majosmile.SetActive(false);
        mengzhong.SetActive(false);

        //新建一个XML“编辑器”并初始化存放对话的list
        XmlDocument xmlDocument = new XmlDocument();
        dialogues_list = new List<string>();

        //载入资源
        string data = Resources.Load("begindialog").ToString();
        xmlDocument.LoadXml(data);

        XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("dialogues").ChildNodes;//选择<dialogues>为根结点并得到旗下所有子节点    
        foreach (XmlNode xmlNode in xmlNodeList)//遍历<dialogues>下的所有节点<dialogue>压入List  
        {
            XmlElement xmlElement = (XmlElement)xmlNode;  
            dialogues_list.Add(xmlElement.ChildNodes.Item(0).InnerText + "," + xmlElement.ChildNodes.Item(1).InnerText);

        }
        dialogue_count = dialogues_list.Count;
        dialogues_handle(0);//载入第一条对话的场景
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))//按下鼠标左键
        {
            dialogue_index++;//对话跳到一下个  
            if (dialogue_index < dialogue_count) 
            {
                detail.Clear();
                roleName.Clear();
                dialogues_handle(dialogue_index);//载入下一条对话  
            }
            else
            { //对话完了  
                SceneManager.LoadScene("Level1");
            }
        }
    }

    private void dialogues_handle(int dialogue_index)
    {
        //切割数组  
        string[] role_detail_array = dialogues_list[dialogue_index].Split(',');
        role = role_detail_array[0];
        role_detail = role_detail_array[1];

        switch (role)//根据角色名  
        {
            case "xhordinaryM":
                xhordinaryM.SetActive(true);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                roleName.Add("艾小红");
                break;
            case "mama":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                roleName.Add("妈妈");
                break;
            case "pangbai":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                mengzhong.SetActive(true);

                roleName.Add("  ");
                break;
            case "xhordinary":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(true);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                roleName.Add("艾小红");
                break;
            case "xhsurprise":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(true);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                roleName.Add("艾小红");
                break;
            case "xhguilty":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(true);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                roleName.Add("艾小红");
                break;
            case "majoblackM":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(true);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                roleName.Add("???");
                break;
            case "majoblack":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(true);
                majoordinary.SetActive(false);
                majosmile.SetActive(false);
                roleName.Add("???");
                break;
            case "majoordinary":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(true);
                majosmile.SetActive(false);
                roleName.Add("迷之美少女?");
                break;
            case "majosmile":
                xhordinaryM.SetActive(false);
                xhordinary.SetActive(false);
                xhsurprise.SetActive(false);
                xhguilty.SetActive(false);
                majoblackM.SetActive(false);
                majoblack.SetActive(false);
                majoordinary.SetActive(false);
                majosmile.SetActive(true);
                roleName.Add("迷之美少女?");
                break;

        }
        detail.Add(role_detail);//加载当前的对话 
    }
}


