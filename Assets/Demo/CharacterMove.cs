using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public CharacterController _player;
    private Vector3 playerVelocity;
   
    private float playerSpeed = 2.0f;
   
    private float gravityValue = -9.81f;

    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _player.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            _anim.SetBool("Walk", true);
        }
        else
        {
            _anim.SetBool("Walk", false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        _player.Move(playerVelocity * Time.deltaTime);

    }
}
