using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class top_control : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scor_txt;
    public TMPro.TextMeshProUGUI heart_txt;
    public TMPro.TextMeshProUGUI brick_txt;

    public Rigidbody ball_rigi;

    Vector3 start_coordinate;
    GameObject[] bricks;

    float speed=7.0f;
    int scor=0;
    int broken_brick=0;
    int sum_bricks;
    int sum_heart;

    void Start() {
        bricks=GameObject.FindGameObjectsWithTag("brick");
        sum_bricks=bricks.Length;

        brick_txt.text=broken_brick+"/"+sum_bricks;
        start_coordinate=transform.position;
        start_hit();
    }

    void start_hit(){
        ball_rigi.velocity=Vector3.zero;
        transform.position=start_coordinate;
        ball_rigi.velocity= new Vector3(speed,0,speed);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="brick"){
            Destroy(collision.gameObject);

            scor+=100;
            broken_brick++;

            scor_txt.text="Scor: "+scor;
            brick_txt.text=broken_brick+"/"+sum_bricks;

            if(broken_brick==sum_bricks){
                Debug.Log("Kazandin");
            }
        }

        if (collision.gameObject.name == "right_wall"){
            ball_rigi.velocity = new Vector3(-speed, 0, ball_rigi.velocity.z); 
        }

        if (collision.gameObject.name == "left_wall"){
            ball_rigi.velocity = new Vector3(speed, 0, ball_rigi.velocity.z); 
        }

        if (collision.gameObject.name == "over_border"){
            sum_heart--;
            heart_txt.text = sum_heart.ToString();
            if (sum_heart == 0){
                SceneManager.LoadScene("scenes/SampleScene");
            }
            start_hit();
        }
    }
}
