using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModelCollision : MonoBehaviour
{
    CharacterControlScript controlScript;
    private Animation animator;
    private PauseMenuButtons pmbScript;
    //SGameObject asd;
    // Use this for initialization
    private void Awake()
    {

    }
    void Start()
    {
        GameObject thePlayer = GameObject.Find("model1");
        controlScript = thePlayer.GetComponent<CharacterControlScript>();
        animator = thePlayer.GetComponent<Animation>();
        GameObject buttonsPanel = GameObject.Find("pauseMenu");
        pmbScript = buttonsPanel.GetComponent<PauseMenuButtons>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if ((collision.gameObject.tag == "Coin"))
        {
            GameScript.actualizeCoins();
            Destroy(collision.gameObject);
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
        pmbScript.ShowGameOverMenu();
        pmbScript.HideTimeCoinsGroup();
    }
    private IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }
}
