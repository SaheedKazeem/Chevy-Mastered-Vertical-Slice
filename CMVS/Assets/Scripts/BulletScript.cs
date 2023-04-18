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
        if (gameObject != null)
        {
            if (other.gameObject.CompareTag("TileMap"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brokenBullet;
            await Task.Delay(300); // Wait for 1 second (1000 milliseconds)
            Destroy(this.gameObject);       
        }
        if (other.gameObject.CompareTag("Player"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = brokenBullet;
            await Task.Delay(500); // Wait for 1 second (1000 milliseconds)
            transform.parent.GetComponent<BeeMobScript>().RefToPlayerCombatScript.TakeDamage(50);
            Destroy(gameObject);  
        }
        }
        if (gameObject == null)
        {
            return;
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
