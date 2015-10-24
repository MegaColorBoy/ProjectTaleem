using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

//Voice assistant for the entire application
namespace MetroFrameworkDLLExample
{
    class VoiceAssistant
    {
        SpeechSynthesizer voiceSynth;
        PromptBuilder builder;

        public VoiceAssistant()
        {
            this.voiceSynth = new SpeechSynthesizer();
            this.builder = new PromptBuilder();
        }

        public void SpeakMessage(String message)
        {
            builder.ClearContent();
            builder.AppendText(message);
            voiceSynth.SpeakAsync(builder);
        }
    }
}
