using UnityEngine;

public class Coin : MonoBehaviour
{
    #region DEFAULT STATUS
    private float x, y;
    private AudioSource audio_Source;
    private AudioClip audio_Clip5;
    public static int coin;

    void Start()
    {
        audio_Source = GetComponent<AudioSource>();
        audio_Clip5 = Resources.Load<AudioClip>("Audios/Sfxs/5");   // COIN

        if (LevelManager.condition == 0 || LevelManager.condition == 2)
        {
            coin = 1;
            RandomCoin();
        }
        if (LevelManager.condition == 1)
        {
            coin = 15;
            InvokeRepeating("RandomCoin", 0, 1);
        }
    }

    void Update()
    {
        if (coin == 0 && LevelManager.condition == 1)
        {
            CancelInvoke("RandomCoin");
        }
    }

    void RandomCoin()
    {
        x = Random.Range(-7.45f, 7.45f);
        y = Random.Range(-2.5f, 2.5f);
        transform.position = new Vector2(x, y);
    }
    #endregion

    #region COLLISIONS
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);

            if (coin > 0 && LevelManager.condition == 1)
            {
                RandomCoin();
            }
            if(coin == 0)
            {
                LevelManager.win = true;
            }
            if (PlayerPrefs.GetInt("AUDIO") == 1)
            {
                audio_Source.PlayOneShot(audio_Clip5);
            }
        }
    }
    #endregion
}