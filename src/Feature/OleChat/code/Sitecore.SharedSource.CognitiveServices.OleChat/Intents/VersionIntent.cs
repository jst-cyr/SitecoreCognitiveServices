﻿using System;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IVersionIntent : IIntent { }

    public class VersionIntent : IVersionIntent 
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IOleSettings Settings;

        public Guid ApplicationId => Settings.OleApplicationId;

        public string Name => "version";

        public string Description => "Provide my version information";

        public VersionIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) {
            Translator = translator;
            Settings = settings;
        }

        public string Respond(LuisResult result, ItemContextParameters parameters) {

            var path = HttpContext.Current.Server.MapPath("~/sitecore/shell/sitecore.version.xml");
            if (!System.IO.File.Exists(path))
                return string.Empty;

            string xmlText = System.IO.File.ReadAllText(path);
            XDocument xdoc = XDocument.Parse(xmlText);

            var version = xdoc.Descendants("version").First();
            var major = version.Descendants("major").First().Value;
            var minor = version.Descendants("minor").First().Value;
            var revision = version.Descendants("revision").First().Value;

            return $"My version is {major}.{minor} rev {revision}";
        }
    }
}