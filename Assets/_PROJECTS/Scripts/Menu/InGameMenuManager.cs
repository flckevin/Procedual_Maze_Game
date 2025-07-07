using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    /// <summary>
    /// function to activate given target
    /// </summary>
    /// <param name="_target"> target to activate </param>
    public void ActivateTarget(GameObject _target)
    {
        //activating target
        _target.SetActive(true);
    }

    /// <summary>
    /// function to deactivate target
    /// </summary>
    /// <param name="_target"> target </param>
    public void DeactivateTarget(GameObject _target)
    {
        //deactivate target
        _target.SetActive(false);
    }

    public void ChangeScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

    public void Hint()
    {
        GameManager.Instance.hintBug.gameObject.SetActive(true);
        GameManager.Instance.hintBug.MoveAI(true);
    }

    public void AutoMove()
    {
        GameManager.Instance.mainBug.MoveAI(true);
    }
    

}
