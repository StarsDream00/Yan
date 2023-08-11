﻿using System.Text.Json;

namespace Yanzheng.Utils;
internal record ConfigHelper(string Token, string ProxyUrl, bool EnableAutoI18n)
{
    public ConfigHelper(string path) : this("", "", default)
    {
        string configStr = FileHelper.CheckFile(path, JsonSerializer.Serialize(this));
        ConfigHelper? config = JsonSerializer.Deserialize<ConfigHelper>(configStr);
        if (config is null)
        {
            return;
        }
        Token = config.Token;
        ProxyUrl = config.ProxyUrl;
        EnableAutoI18n = config.EnableAutoI18n;
    }
}
