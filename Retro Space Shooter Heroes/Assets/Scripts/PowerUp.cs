using UnityEngine;

public class PowerUp : MonoBehaviour
{
    #region DEFAULT STATUS
    private float x, y;
    public static int r;
    private AudioSource audio_Source;
    private AudioClip audio_Clip6;
    public static bool check;

    void Start()
    {
        check = false;
        audio_Source = GetComponent<AudioSource>();
        audio_Clip6 = Resources.Load<AudioClip>("Audios/Sfxs/6");   // POWERUP

        if (LevelManager.condition == 0 || LevelManager.condition == 2)
        {
            // RANDOM POSITION
            x = Random.Range(-7.45f, 7.45f);
            y = Random.Range(-2.5f, 2.5f);
            transform.position = new Vector2(x, y);
        }
    }
    #endregion

    #region COLLISIONS
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (r == 0)
            {
                PlayerManager.shot2 = true;
            }
            else
            {
                PlayerManager.protect = true;
            }

            if (PlayerPrefs.GetInt("AUDIO") == 1)
            {
                audio_Source.PlayOneShot(audio_Clip6);
            }

            check = true;
        }
    }
    #endregion
}