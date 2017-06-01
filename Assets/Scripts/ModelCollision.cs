using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelCollision : MonoBehaviour
{

    public static int points = 0;
    public Text text;
    CharacterControlScript controlScript;
    private Animation animator;
    public int score = 0;
    // Use this for initialization
    private void Awake()
    {

    }
    void Start()
    {
        text = GameObject.Find("Coins").GetComponent<Text>();
        GameObject thePlayer = GameObject.Find("model1");
        controlScript = thePlayer.GetComponent<CharacterControlScript>();
        animator = thePlayer.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if ((collision.gameObject.tag == "Coin"))
        {
            points++;
            Destroy(collision.gameObject);
            text.text = points.ToString();

        }
        if ((collision.gameObject.tag == "Snowman") || (collision.gameObject.tag == "Object"))
        {
            Debug.Log("Kolizja!");
            StartCoroutine(Collide());
      
      
            //GroundVariables.stop = true;
            //Time.timeScale = 0;
            //controlScript.collided = true;
        }
        if ((collision.gameObject.tag == "Wall"))
        {
            Debug.Log("Kolizja!");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            controlScript.collided = true;
        }
    }

    IEnumerator Collide()
    {
        animator.Play("Armature|crash");
        yield return new WaitForSeconds(animator["Armature|crash"].length);
        GroundVariables.stop = true;
        Time.timeScale = 0;
        controlScript.collided = true;
        score = ShowTime.playTime + 2*int.Parse(text.text);
    }
    private IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }
}
