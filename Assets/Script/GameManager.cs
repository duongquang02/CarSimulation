using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float thoiGianChoPhepVeDich = 60f;
    public bool ketThucGame = false;
    public bool winGame = false;
    private static GameManager instance;
    public GameObject gameOverObject;
    public GameObject timeGameObjecct;
    public GameObject winGameObject;
    [SerializeField]
    private float thoiGianHoiKhiQuaCheckPoint = 61f;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if(instance == null)
                {
                    GameObject gameManagerGameObject = new GameObject("GameManager");
                    instance = gameManagerGameObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Update()
    {
        if (!ketThucGame)
        {
            thoiGianChoPhepVeDich -= Time.deltaTime;
            Debug.Log(thoiGianChoPhepVeDich);
            if(thoiGianChoPhepVeDich <= 0)
            {
                timeGameObjecct.SetActive(false);
                gameOverObject.SetActive(true);
                KetThucGame();
            }
        }

        if (winGame) 
        {
            timeGameObjecct.SetActive(false);
            winGameObject.SetActive(true);
        }
    }

    public void KetThucGame()
    {
        ketThucGame = true;
    }

    public void QuaCheckPoint()
    {
        if (!ketThucGame) 
        {
            thoiGianChoPhepVeDich = thoiGianHoiKhiQuaCheckPoint;
        }
    }

    public void QuaWinPoint()
    {
        if (!ketThucGame)
        {
            winGame = true;
        }
    }
}
