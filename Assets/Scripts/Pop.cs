using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour {

    //　出現させる敵を入れておく
    [SerializeField] GameObject Enemy;


    //　次に敵が出現するまでの時間
    [SerializeField] float appearNextTime;
    //　この場所から出現する敵の数
    [SerializeField] int maxNumOfEnemys;
    //　今何人の敵を出現させたか
    private int numberOfEnemys;
    //　待ち時間計測フィールド
    private float elapsedTime;

    // Use this for initialization
    IEnumerator Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;

        enabled = false;
        yield return new WaitForSeconds(3); //三秒待ってUpdate()を有効化してキーそのものを受け付けない
        enabled = true;
    }


    // Update is called once per frame
    void Update () {
        //　この場所から出現する最大数を超えてたら何もしない
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }
        //　経過時間を足す
        elapsedTime += Time.deltaTime;

        //　経過時間が経ったら
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearEnemy();
        }
        Resources.UnloadUnusedAssets();
    }
    //　敵出現メソッド
    void AppearEnemy()
    {

        float x = Random.Range(10f, 450f);
        float y = 116;
        float z = Random.Range(10f, 450f);
        Vector3 position = new Vector3(x,y, z);
        Instantiate(Enemy, new Vector3(x,y,z),Quaternion.identity);

        numberOfEnemys++;
        elapsedTime = 0f;
    }

    

}
