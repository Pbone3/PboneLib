﻿using System.Collections.Generic;
using Terraria.ModLoader;
using Tomlet;
using Tomlet.Models;
using TModLocalizationLoader = Terraria.ModLoader.LocalizationLoader;

namespace PboneLib.CustomLoading.Localization.Parsers
{
    public class TomlFileParser : ILocalizationFileParser
    {
        public IDictionary<string, ModTranslation> ParseText(Mod mod, string culture, string text)
        {
            TomlDocument document = new TomlParser().Parse(text);
            Dictionary<string, ModTranslation> dictionary = new Dictionary<string, ModTranslation>();
            foreach (KeyValuePair<string, TomlValue> kvp in document.Entries)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                GetValues(kvp.Key, kvp.Value, ref values);

                foreach (KeyValuePair<string, string> tr in values)
                {
                    string key = tr.Key;
                    string value = tr.Value;
                    value = value.Replace("\\n", "\n");

                    if (!dictionary.TryGetValue(key, out var translation))
                    {
                        translation = (dictionary[key] = TModLocalizationLoader.CreateTranslation(mod, key));
                    }
                    translation.AddTranslation(culture, value);
                }
            }

            return dictionary;
        }

        public void GetValues(string key, TomlValue toml, ref Dictionary<string, string> values)
        {
            if (toml is TomlTable table)
            {
                values = new Dictionary<string, string>();

                foreach (KeyValuePair<string, TomlValue> kvp in table.Entries)
                {
                    // key + "." + kvp.Key is needed to the name of the table is added to the translations key
                    GetValues(key + "." + kvp.Key, kvp.Value, ref values);
                }

                return;
            }

            values.Add(key, toml.StringValue);
        }
    }
}
