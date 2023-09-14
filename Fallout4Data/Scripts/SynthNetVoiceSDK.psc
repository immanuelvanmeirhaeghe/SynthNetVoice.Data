ScriptName SynthNetVoiceSDK extends ObjectReference

Import System:Reflection

Function CallAPI(String method, String url)

        var SynthNetVoiceData = Assembly.LoadAssembly("C:/Program Files (x86)/Steam/steamapps/common/Fallout 4/Data/Libs/SynthNetVoice.Data.dll")
        var wrapper = SynthNetVoiceData.GetType("SynthNetVoice.Data.SynthNetVoiceApiWrapper")
        var api = SynthNetVoiceData.CreateInstance(wrapper)
        return SynthNetVoiceData.InvokeMethod(api, "CallApi", method, url)        

EndFunction