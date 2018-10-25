using UnityEngine;

public class Life : MonoBehaviour
{
    #region DEFAULT STATUS
    private float x, y;
    private AudioSource audio_Source;
    private AudioClip audio_Clip7;
    public static bool check;

    void Start()
    {
        check = false;
        audio_Source = GetComponent<AudioSource>();
        audio_Clip7 = Resources.Load<AudioClip>("Audios/Sfxs/7");

        if (LevelManager.condition == 0 || LevelManager.condition == 2)
        {
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
            check = true;

            if (PlayerPrefs.GetInt("AUDIO") == 1)
            {
                audio_Source.PlayOneShot(audio_Clip7);
            }
        }
    }
    #endregion
}