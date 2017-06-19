﻿using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Factories;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IAboutIntent : IIntent { }

    public class AboutIntent : IAboutIntent {

        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IOleSettings Settings;
        protected readonly IServiceProvider Provider;

        public Guid ApplicationId => Settings.OleApplicationId;

        public string Name => "about";

        public string Description => "Tell you about my abilities";

        public AboutIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings,
            IServiceProvider provider) {
            Translator = translator;
            Settings = settings;
            Provider = provider;
            }
        
        public string Respond(LuisResult result, ItemContextParameters parameters)
        {
            var intents = Provider.GetServices<IIntentFactory<IIntent>>()
                .Select(a => a.Create())
                .Where(g => g.ApplicationId.Equals(ApplicationId) && !g.Name.Equals("none"));
                
            var list = intents.Select(i => $"<li>{i.Description}</li>");

            var str = string.Join("", list);

            return $"Here's the list of things I can do: <br/><ul>{str}</ul>";
        }
    }
}