using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour {
<<<<<<< HEAD

	void Start () {

=======
    public List<string> collisionTags;
   

    void Start() {
        collisionTags = new List<string>();
      
        
>>>>>>> origin/master
    }

    void Update()
    {
<<<<<<< HEAD

=======
       
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.tag == "Wave" ? "Wave" : "Wall";
        collisionTags.Add(tag);

     
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.collider.tag == "Wave" ? "Wave" : "Wall";
        collisionTags.Remove(tag);
>>>>>>> origin/master
    }



}
