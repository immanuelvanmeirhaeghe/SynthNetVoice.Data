Scriptname SynthNetVoiceAPI extends Quest
{Attaches to any character on starting a dialogue with the player.}

SynthNetVoiceSDK Property api Auto

bool isSpeakerInit = false
int apiPort = 7230

;HTTP request using custom library
Function HttpRequest(String method, String url)
    
    	return api.CallApi(method, url)

EndFunction

;HTTP GET request
Function HttpGet(String url)

	 return HttpRequest("GET", url)

EndFunction

;HTTP POST request
Function HttpPost(String url)
		isSpeakerInit = true
		return HttpRequest("POST", url)
    
EndFunction

;Initialize the API for this NPC
Function InitVoice(String npc)

		String initApiUrl = "https://localhost:"+apiPort+"/npc/init?gameName=Fallout4&npcName="+npc
		return HttpPost(initApiUrl)      
   
EndFunction

;Get the instructions used to initialize the NPC
Function GetInstruction(String npc)

		String instructApiUrl = "https://localhost:"+apiPort+"/npc/instruction?gameName=Fallout4&npcName="+npc
		return HttpGet(instructApiUrl)

EndFunction

;Speak using API
Function SpeakToPlayer(String npc, String prompt)
    
    	String promptApiUrl = "https://localhost:"+apiPort+"/npc/prompt?gameName=Fallout4&scribe=true&gpt=true&npcName="+npc+"&question="+prompt
		return HttpGet(promptApiUrl)
	
EndFunction