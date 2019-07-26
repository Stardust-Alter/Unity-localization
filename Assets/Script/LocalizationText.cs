﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    private static LocalizationText instance = null;
    /// <summary>
    /// 单例
    /// </summary>
    public static LocalizationText Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// 语言
    /// </summary>
    [SerializeField]
    private SystemLanguage language;

    /// <summary>
    /// <summary>
    /// 相同的key 对应 不同国家的value
    /// </summary>
    private Dictionary<string, string> dict = new Dictionary<string, string>();

    /// <summary>
    /// 加载预翻译的语言
    /// </summary>
    private void loadLocalizationText()
    {
        //从resours文件中加载text
        TextAsset ta = Resources.Load<TextAsset>(language.ToString());

        if (ta == null)
        {
            Debug.LogWarning("没有这个语言的翻译文件");
            return;
        }

        //获取每一行
        string[] lines = ta.text.Split('\n');
        //获取key value
        for (int i = 0; i < lines.Length; i++)
        {
            //检测
            if (string.IsNullOrEmpty(lines[i]))
                continue;
            //获取 key:kv[0] value kv[1]
            string[] kv = lines[i].Split(':');
            //保存到字典
            dict.Add(kv[0], kv[1]);

            Debug.Log(string.Format("key:{0}, value:{1}", kv[0], kv[1]));
        }
    }

    void Awake()
    {
        instance = this;

        loadLocalizationText();
    }

    /// <summary>
    /// 获取对应的value
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>返回对应的value 如果不存在这个key 就返回空串</returns>
    public string GetText(string key)
    {
        if (dict.ContainsKey(key))
            return dict[key];
        else//没有这个key
        {
            return string.Empty;
        }
    }
}
