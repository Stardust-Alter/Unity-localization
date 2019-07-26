using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    /// <summary>
    /// 对应的key
    /// </summary>
    [SerializeField]
    private string key;

    void Start()
    {
        //设置key之后 才需要改变
        if (!string.IsNullOrEmpty(key))
        {
            //获取对应的value
            string value = LocalizationText.Instance.GetText(this.key);
            if (!string.IsNullOrEmpty(value))
                //给text组件赋值
                GetComponent<Text>().text = value;
        }
    }
}
