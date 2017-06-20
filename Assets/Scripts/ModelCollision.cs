using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModelCollision : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup progressBar;
    [SerializeField]
    private CanvasGroup bonusTextCanvas;
    [SerializeField]
    private Text bonusText;
    CharacterControlScript controlScript;
    private Animation animator;
    private PauseMenuButtons pmbScript;
    public AudioClip coinAudio;
    private int bonusNumber;
    private float oldGameSpeed;
    //SGameObject asd;
    // Use this for initialization
    private void Awake()
    {

    }
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = coinAudio;
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
            GameScript.ActualizeCoins();
            GetComponent<AudioSource>().Play();
            
            Destroy(collision.gameObject);
        }
        if ((collision.gameObject.tag == "Bonus"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            bonusNumber = Random.Range(1,4);
            ShowProgressBar();
            switch (bonusNumber) {
                case 1:
                    GroundVariables.coinMultipler = 2;
                    bonusText.text = "DOUBLE COINS";
                    break;
                case 2:
                    GroundVariables.normalControll = false;
                    bonusText.text = "CHANGED DIRECTIONS";
                    break;
                case 3:
                    oldGameSpeed = GroundVariables.gameSpeed;
                    GroundVariables.gameSpeed /= 2;
                    bonusText.text = "GAME SPEED SLOWED";
                    break;
            }
            StartCoroutine(waitForSeconds());
            
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

    IEnumerator waitForSeconds()
    {
        yield return new WaitForSeconds(10);
        HideProgressBar();
        switch (bonusNumber)
        {
            case 1:
                GroundVariables.coinMultipler = 1;
                break;
            case 2:
                GroundVariables.normalControll = true;
                break;
            case 3:
                GroundVariables.gameSpeed = oldGameSpeed;
                break;
        }
    }

    private void ShowProgressBar()
    {
        ProgressBarScript.ResetProgressBar();
        progressBar.alpha = 1;
        progressBar.interactable = true;
        progressBar.blocksRaycasts = true;
        bonusTextCanvas.alpha = 1;
        bonusTextCanvas.interactable = true;
        bonusTextCanvas.blocksRaycasts = true;
    }

    private void HideProgressBar()
    {
        progressBar.alpha = 0;
        progressBar.interactable = false;
        progressBar.blocksRaycasts = false;
        bonusTextCanvas.alpha = 0;
        bonusTextCanvas.interactable = false;
        bonusTextCanvas.blocksRaycasts = false;
    }
}
