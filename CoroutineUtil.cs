using System.Collections;

public class WaitForButtonClick:IEnumerator
{
    bool isBTNClicked = false;
    void buttonclick()
    {
        isBTNClicked = true;
    }
    
    public WaitForButtonClick(UnityEngine.UI.Button button)
    {
        button.onClick.AddListener(buttonclick);
    }
    
    #region IEnumerator implementation
    public bool MoveNext()
    {
        return !isBTNClicked;
    }
    public void Reset()
    {
        
    }
    public object Current
    {
        get
        {
            return null;
        }
    }
    #endregion
}