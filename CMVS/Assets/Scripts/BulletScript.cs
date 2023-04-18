using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BulletScript : MonoBehaviour
{
    public Sprite brokenBullet;
    Transform parentTransform;
    async void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject == null)
        {
            return;
        }

        if (other.gameObject.CompareTag("TileMap"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brokenBullet;
            await Task.Delay(500); // Wait for 1 second (1000 milliseconds)
            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (parentTransform != null && other.gameObject.CompareTag("Player"))
            {
                parentTransform.GetComponent<BeeMobScript>().RefToPlayerCombatScript.TakeDamage(30);
                
            }
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brokenBullet;
           
        }



    }


    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
