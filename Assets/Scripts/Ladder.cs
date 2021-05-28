﻿using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{

    private  bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D colliderLadder;
    public Text interactUI;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

      if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E)){ //descendre de l'echelle
          playerMovement.isClimbing = false;
          colliderLadder.isTrigger = false;
          return;
      }

      if(isInRange && Input.GetKeyDown(KeyCode.E)){//monter à l'échelle
          playerMovement.isClimbing = true;
          colliderLadder.isTrigger = true;
      }
    }

    private void OnTriggerEnter2D(Collider2D collision){
      if(collision.CompareTag("Player")){
        interactUI.enabled = true;
        isInRange = true;
      }
    }

    private void OnTriggerExit2D(Collider2D collision){
      if(collision.CompareTag("Player")){
        isInRange = false;
        playerMovement.isClimbing = false;
        colliderLadder.isTrigger = false;
        interactUI.enabled = false;
      }
    }
}
