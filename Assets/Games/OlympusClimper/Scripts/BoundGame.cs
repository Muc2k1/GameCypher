using System.Collections;
using System.Collections.Generic;
using OlympusClimper;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundGame : MonoBehaviour
{
    private List<Node> choosenNodes = new();
    private void Start()
    {
        OCEvent.ON_MOVE_DOWN_FINISH += UpdateNodes;
    }
    private void OnDestroy()
    {
        OCEvent.ON_MOVE_DOWN_FINISH -= UpdateNodes;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("OlympusMain", LoadSceneMode.Single);
        }
        if (col.gameObject.CompareTag("Node"))
        {
            this.choosenNodes.Add(col.gameObject.GetComponent<Node>());
        }
    }
    private void UpdateNodes()
    {
        foreach (Node node in choosenNodes) //Set new position for old node
        {
            node.SetRandomPosition();
        }

        int additionalScore = choosenNodes.Count; //it is used for calculating score
        this.choosenNodes.Clear();
        OCEvent.ON_ADD_SCORE?.Invoke(additionalScore);
    }
}
