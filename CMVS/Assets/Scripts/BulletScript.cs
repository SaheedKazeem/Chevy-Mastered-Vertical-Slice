using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using PlayerControllers;

public class BulletScript : MonoBehaviour
{
    public Sprite brokenBullet;
    [SerializeField] PlayerCombatScript playerRef;

     void Awake()
    {
        GameObject RefofPlayer;
        RefofPlayer = GameObject.Find("Chevy - Player");
        playerRef = RefofPlayer.GetComponent<PlayerCombatScript>();
    }
    IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject == null)
        {
            yield break;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You've been hit");

            playerRef.TakeDamage(30);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brokenBullet;
        }
        if (other.gameObject.CompareTag("TileMap"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brokenBullet;
            yield return new WaitForSeconds(0.325f); // Wait for 0.5 seconds
            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }
        }

    }


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
}
