using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OlympusClimper
{
    public class NodesPool : MonoBehaviour //NodeManager
    {
        [SerializeField] private List<Node> nodes;
        private void Start()
        {
            OCGameManager.ON_PLAYER_UPDATE_POSITION += OnPlayerChangePosition;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UpdateQueue();
            }
        }
        private void OnDestroy()
        {
            OCGameManager.ON_PLAYER_UPDATE_POSITION -= OnPlayerChangePosition;
        }
        private void OnPlayerChangePosition(Node newNode)
        {
            PlayerController currentPlayer = OCGameManager.Instance.Player;
            if (currentPlayer == null)
                return;
            Node currentNode = currentPlayer.CurrentNode == null ? nodes[0] : currentPlayer.CurrentNode;
            float flyHeight = newNode.transform.position.y - currentNode.transform.position.y;
            Debug.Log(newNode.transform.position.x + " - " + newNode.transform.position.y);
            Debug.Log(currentNode.transform.position.x + " - " + currentNode.transform.position.y);
            OCGameManager.ON_START_MOVE_DOWN?.Invoke(flyHeight);
            OCGameManager.ON_PLAYER_LATE_UPDATE_POSITION?.Invoke(newNode);
            Debug.Log(flyHeight);
        }
        private void UpdateQueue()
        {
            Node temp = this.nodes[this.nodes.Count - 1];
            for (int i = (this.nodes.Count - 1); i > 0 ; i--)
            {
                nodes[i] = nodes[i - 1];
            }
            nodes[0] = temp;
        }
    }
}