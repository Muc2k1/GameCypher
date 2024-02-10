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
        private void Update()
        {
            MovementTypeNodeCheck();
        }
        private void BuffTypeNodeCheck()
        {
            switch (node.TYPE)
            {
                case Node.eNodeType.Tiny:
                case Node.eNodeType.Confusion:
                    break;
                case Node.eNodeType.Faster:
                    Faster();
                    break; 
                case Node.eNodeType.Revert:
                case Node.eNodeType.Score:
                case Node.eNodeType.Scope:
                    break;
                case Node.eNodeType.Slower:
                    Slower();
                    break;
                case Node.eNodeType.Giant:
                case Node.eNodeType.Heal:                
                default:
                    break;
            }
        }
        private void MovementTypeNodeCheck()
        {
            switch (node.TYPE)
            {
                case Node.eNodeType.HorizontalMove:
                    break;
                case Node.eNodeType.VerticleMove:
                    break; 
                default:
                    break;
            }
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
            {
                BuffTypeNodeCheck();
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