using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OlympusClimper;

namespace OlympusClimper
{
    public class NodeController : MonoBehaviour //this script is used for special node
    {
        private Node node;  

        private void Start()
        {
            node = GetComponent<Node>();
        }
        private void StateCheck()
        {
            switch (node.TYPE)
            {
                case Node.eNodeType.Tiny:
                case Node.eNodeType.Confusion:
                case Node.eNodeType.Faster:
                    Faster();
                    break;
                case Node.eNodeType.HorizontalMove:
                    break;
                case Node.eNodeType.VerticleMove:
                    break; 
                case Node.eNodeType.Revert:
                case Node.eNodeType.Score:
                case Node.eNodeType.Scope:
                case Node.eNodeType.Slower:
                    Slower();
                    break;
                case Node.eNodeType.Giant:
                case Node.eNodeType.Heal:                
                default:
                    break;
            }
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                StateCheck();
            }
        }
        private void Faster()
        {
            OCEvent.ON_BUFF_APPLY?.Invoke("Faster");
        }
        private void VerticleMove()
        {
            Debug.Log("The node is moving vertically");
        }
        private void HorizontalMove()
        {
            Debug.Log("The node is moving Horizontally");
        }
        private void Slower()
        {
            OCEvent.ON_BUFF_APPLY?.Invoke("Slower");
        }

    }
}