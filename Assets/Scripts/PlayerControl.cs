using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    bool wait = false;

    public GameObject prefab;
    public GameObject spawnPoint;
    public float velocity = 100f;
    //public Text TextLife;

    Rigidbody2D rb;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //TextLife.text = life.ToString();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Coin")) {
            SFXManager.instance.ShowBoneParticles(other.gameObject);
            AudioManager.instance.PlaySoundbonePickup(other.gameObject);
            Destroy(other.gameObject);
            LevelManager.instance.IncrementBoneCount();
        }
        else if (other.gameObject.CompareTag("Gift")) {
            StopMusicAndTape();
            AudioManager.instance.PlaySoundLevelComplete(gameObject);
            Destroy(gameObject);
            LevelManager.instance.ShowLevelCompletePanel();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
            HurtPlayer();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Forbidden")) {
            KillPlayer();
        }
    }

    void StopMusicAndTape() {
        Camera.main.GetComponentInChildren<AudioSource>().mute = true;
        LevelManager.instance.SetTapeSpeed(0);  
    }

    void KillPlayer() {
        Destroy(gameObject);
        StopMusicAndTape();
        AudioManager.instance.PlaySoundFail(gameObject);
        LevelManager.instance.ShowGameOverPanel();
    }


    void HurtPlayer() {
        if (!wait) {
            LevelManager.instance.DecrementLifeCount();
            ChangeAlpha(0.5f);
            if (LevelManager.instance.GetLifeCount() == 0) {
                KillPlayer();
            }
            else {         
                //AudioManager.instance.PlaySoundHurt(gameObject); // OPCIONAL: TOCAR UM SOM DE MACHUCADO       
                wait = true;
                StartCoroutine(DisableWait(2.0f));
            }
        }
    }

    private IEnumerator DisableWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangeAlpha(1f);        
        wait = false;
    }

    private void ChangeAlpha(float alpha) {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = alpha;
        GetComponent<SpriteRenderer>().color = tmp;
    }    
}
