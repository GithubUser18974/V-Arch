using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool disActive = false;
    public GameObject MainCan;
    public GameObject CloseMainCan;
    public GameObject MaterialCan;
    public GameObject WallPanel;
    public GameObject GroundPanel;
    public GameObject FerniturePanel;
    private bool isPosition = false;
    private bool isScailing = false;
    private Transform vPlayer;

    // Use this for initialization
    void Start()
    {
        MainCan.SetActive(false);
        MaterialCan.SetActive(false);
        vPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("showcan") == "True")
        {
            mShowMainMenu();
        }
        else
        {
            mHideMainMenu();
        }


    }
    // activeMenu Fucition ......./// <summary>
    private void mShowMainMenu()
    {
        MainCan.SetActive(true);
        CloseMainCan.SetActive(true);
        MaterialCan.SetActive(false);
    }
    private void mHideMainMenu()
    {
        MainCan.SetActive(false);
        CloseMainCan.SetActive(false);
    }

    // Delete Button .......////
    public void DeleteObject()
    {
        GameObject obj = GameObject.Find(PlayerPrefs.GetString("fab"));
        Destroy(obj);
    }
    // Material Button........////
    public void OpenMaterialMenu()
    {
        PlayerPrefs.SetString("showcan", "False");
        MainCan.SetActive(false);
        MaterialCan.SetActive(true);

    }
    public void SetWallPAnel(){
        WallPanel.SetActive(true);
        GroundPanel.SetActive(false);
        FerniturePanel.SetActive(false);
    }
    public void SetGroundPAnel()
    {
        WallPanel.SetActive(false);
        GroundPanel.SetActive(true);
        FerniturePanel.SetActive(false);
    }
    public void SetFerniturePAnel()
    {
        WallPanel.SetActive(false);
        GroundPanel.SetActive(false);
        FerniturePanel.SetActive(true);
    }

    //Positon Button .......////
    public void PostionAvtivity()
    {
        isPosition = true;
        isScailing = false;
    }
    //Scaling Button .......////
    public void ScalAvtivity()
    {
        isScailing = true;
        isPosition = false;
    }

    public bool getPosition()
    {
        return isPosition;
    }
    public bool getScailng()
    {
        return isScailing;
    }
    public void ChangeMaterial(Material newMat)
    {
        GameObject obj = GameObject.Find(PlayerPrefs.GetString("fob"));

        if(obj!=null)
        obj.GetComponent<Renderer>().material = newMat;
        Debug.Log("Clicked  "+obj.name+"    ");
      
    }
    public void mCreateFurniture(GameObject vObj)
    {
        
        GameObject temp = Instantiate(vObj, new Vector3(vPlayer.position.x + 0.5f, 0, vPlayer.position.z + 0.5f),new Quaternion(0,0,0,0));

    }
    public void mCloseMAinMenue()
    {
        PlayerPrefs.SetString("showcan", "False");
        CloseMainCan.SetActive(false);
    }
    
}
