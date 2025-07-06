using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MenuInitializer();
    }

    /// <summary>
    /// function to initialize menu
    /// </summary>
    private void MenuInitializer()
    {
        //randomizing unlocked level
        int _unlockedrand = UnityEngine.Random.Range(1, 10);
        //set unlocked level to static data
        DataM.unlockedLevel = _unlockedrand;
    }

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
}
