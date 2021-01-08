using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //点数を表示するテキスト
    private GameObject pointsText;

    //点数を加算する変数
    private int points = 0;

    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");

        this.pointsText = GameObject.Find("PointsText");
    }

    void Update()
    {
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        this.pointsText.GetComponent<Text>().text = points.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "SmallStarTag")
        {
            //小さい星に当たったら10点加算する
            this.points += 10;
        }
        else if(other.gameObject.tag == "LargeStarTag")
        {
            //大きい星に当たったら20点加算する
            this.points += 20;
        }
        else if(other.gameObject.tag == "SmallCloudTag")
        {
            //小さい雲に当たったら50点加算する
            this.points += 50;
        }
        else if(other.gameObject.tag == "LargeCloudTag")
        {
            //大きい雲に当たったら100点加算する
            this.points += 100;
        }
    }
}
