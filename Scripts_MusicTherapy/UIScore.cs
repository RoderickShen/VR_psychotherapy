using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour {
    public static UIScore Instance = null;
    void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    private Text txtScore;
    /// <summary>
    /// 当前多少分
    /// </summary>
    private int score = 0;
    public void Add(int score)//加分
    {
        this.score += score;
        txtScore.text = this.score.ToString();
    }
}
