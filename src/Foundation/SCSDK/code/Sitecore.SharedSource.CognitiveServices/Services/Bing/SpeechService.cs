﻿using System;
using System.IO;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.Speech;
using Microsoft.SharedSource.CognitiveServices.Repositories.Bing;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing {
    public class SpeechService : ISpeechService {

        protected ISpeechRepository SpeechRepository;
        protected ILogWrapper Logger;

        public SpeechService(
            ISpeechRepository speechRepository,
            ILogWrapper logger) {
            SpeechRepository = speechRepository;
            Logger = logger;
        }

        public virtual SpeechToTextResponse SpeechToText(Stream audioStream, ScenarioOptions scenario, BingSpeechLocaleOptions locale, SpeechOsOptions os, Guid fromDeviceId, int maxnbest = 1, int profanitycheck = 1)
        {
            try {
                var result = SpeechRepository.SpeechToText(audioStream, scenario, locale, os, fromDeviceId, maxnbest, profanitycheck);

                return result;
            } catch (Exception ex) {
                Logger.Error("SpeechService.SpeechToText failed", this, ex);
            }

            return null;
        }

        public virtual Stream TextToSpeech(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat)
        {
            try {
                var result = SpeechRepository.TextToSpeech(text, locale, voiceName, voiceType, outputFormat);

                return result;
            } catch (Exception ex) {
                Logger.Error("SpeechService.TextToSpeech failed", this, ex);
            }

            return null;
        }
    }
}