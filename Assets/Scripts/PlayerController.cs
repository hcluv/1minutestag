using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour    // コンポーネントに追加できるクラスとして　PlayerControl_MadeBySome　を設定
{
    // このスクリプトで使う変数一覧
    

    private CharacterController charaCon;       // キャラクターコンポーネント用の変数
    private Animator animCon;  //  アニメーションするための変数
    private Vector3 moveDirection = Vector3.zero;   //  移動する方向とベクトル（動く力、速度）の変数（最初は初期化しておく）

    //public float:インスペクタで調整可能な変数
    public float MoveSpeed = 5.0f;         // 移動速度
    public float RotateSpeed = 3.0F;     // 向きを変える速度
    public float RollSpeed = 1200.0f;   // プレイヤーの回転速度
    public float gravity = 20.0F;   //重力の強さ
    public float jumpPower = 6.0F;  //ジャンプのスピード


    // ■最初に1回だけ実行する処理
   IEnumerator Start()
    {
        charaCon = GetComponent<CharacterController>(); // キャラクターコントローラーのコンポーネントを参照する
        animCon = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する
        enabled = false;
        yield return new WaitForSeconds(3); //三秒待ってUpdate()を有効化してキーそのものを受け付けない
        enabled = true;
    }

    

    // ■毎フレーム常に実行する処理
    void LateUpdate()
    {

        // ▼▼▼カメラの難しい処理▼▼▼
        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;  //  カメラが追従するための動作
        Vector3 direction = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");  //  テンキーや3Dスティックの入力（GetAxis）があるとdirectionに値を返す



        // ▼▼▼移動処理▼▼▼
        charaCon.Move(moveDirection * Time.deltaTime);  //CharacterControllerの付いているこのオブジェクトを移動させる処理

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)  //  テンキーや3Dスティックの入力（GetAxis）がゼロの時の動作
        {
            animCon.SetBool("Running", false);  //  Runモーションしない
        }

        else //  テンキーや3Dスティックの入力（GetAxis）がゼロではない時の動作
        {
            Rotate(direction);  //  向きを変える動作の処理を実行する（後述）
            animCon.SetBool("Running", true);  //  Runモーションする
        }


        // ▼▼▼落下処理▼▼▼
        if (charaCon.isGrounded)    //CharacterControllerの付いているこのオブジェクトが接地している場合の処理
        {
            animCon.SetBool("Jumping", Input.GetKey(KeyCode.Space));  //  キーorボタンを押したらジャンプアニメを実行
            moveDirection.y = 0f;  //Y方向への速度をゼロにする
            moveDirection = direction * MoveSpeed;  //移動スピードを向いている方向に与える

            if (Input.GetKey(KeyCode.Space) ) //Spaceキーorジャンプボタンが押されている場合
            {
                moveDirection.y = jumpPower; //Y方向への速度に「ジャンプパワー」の変数を代入する
            }
            else //Spaceキーorジャンプボタンが押されていない場合
            {
                moveDirection.y -= gravity * Time.deltaTime; //マイナスのY方向（下向き）に重力を与える
            }

        }
        else  //CharacterControllerの付いているこのオブジェクトが接地していない場合の処理
        {
            moveDirection.y -= gravity * Time.deltaTime;  //マイナスのY方向（下向き）に重力を与える
        }


    }


    // ■向きを変える動作の処理
    void Rotate(Vector3 Hope_Rotate)
    {
        Quaternion q = Quaternion.LookRotation(Hope_Rotate);          // 向きたい方角をQuaternion型に直す
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, RollSpeed * Time.deltaTime);   // 向きを q に向けてじわ～っと変化させる.
    }
}