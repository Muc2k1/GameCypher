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
            OCEvent.ON_PLAYER_UPDATE_POSITION += OnPlayerChangePosition;
        }
        private void OnDestroy()
        {
            OCEvent.ON_PLAYER_UPDATE_POSITION -= OnPlayerChangePosition;
        }
        private void OnPlayerChangePosition(Node newNode)
        {
            PlayerController currentPlayer = OCGameManager.Instance.Player;
            if (currentPlayer == null)
                return;

            Node currentNode = currentPlayer.CurrentNode == null ? nodes[0] : currentPlayer.CurrentNode; //calculating the height changes between the new and old position of player
            float flyHeight = newNode.transform.position.y - currentNode.transform.position.y; //3.5f / 1 step 
            
            OCEvent.ON_PLAYER_LATE_UPDATE_POSITION?.Invoke(newNode);
            OCEvent.ON_START_MOVE_DOWN?.Invoke(flyHeight);
        }
        public Node GetTheHighestNode()
        {
            Node result = nodes[0];
            foreach (Node node in nodes)
            {
                if (result.transform.position.y < node.transform.position.y)
                    result = node;
            }
            return result;
        }
    }
}