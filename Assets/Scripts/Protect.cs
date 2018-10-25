using UnityEngine;

public class Protect : MonoBehaviour
{
    #region DEFAULT STATUS
    public static int life;

    void Start()
    {
        life = 3;
    }
    #endregion

    #region COLLISIONS
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BOSS" || collision.tag == "BulletBoss")
        {
            life--;

            if (life == 0)
            {
                PlayerManager.protect = false;
            }
        }
    }
    #endregion
}