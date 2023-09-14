Scriptname SynthNetVoiceAPI extends ObjectReference

Import winhttp

Function HttpRequest(method as String, url as String) as String
    
    String myuseragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36 Edg/113.0.1774.42"

    winhttp:WinHttpOpen(myuseragent)
    winhttp:WinHttpConnect(url, 7230)

    winhttp:WinHttpOpenRequest(method, url)
    
    winhttp:WinHttpAddRequestHeaders("Content-Type: application/json")    
    ;winhttp:WinHttpAddRequestHeaders(myuseragent)
    
    winhttp:WinHttpSendRequest()    
    winhttp:WinHttpReceiveResponse()    
    winhttp:WinHttpReadData()    
    winhttp:WinHttpCloseHandle()
    
    return winhttp:ResponseBody

EndFunction

Function HttpGet(url as String) as String

    return HttpRequest("GET", url)

EndFunction

Function HttpPost(url as String) as String
    
    return HttpRequest("POST", url)
    
EndFunction

Function InitVoice(npc as String)

    String url = "https://localhost/npc/init?gameName=Fallout4&npcName="
    String response = HttpPost(url)
      
    Debug.Notification(response.GetBody())
   
EndFunction

Function GetInstruction(npc as String)

    String url = "https://localhost/npc/instruction"
    HttpRequest request = HttpRequest(url)
    request.SetQueryParameter("gameName", "Fallout4")
    request.SetQueryParameter("npcName", npc)
    
    HttpResponse response = request.Get()
    Debug.Notification(response.GetBody())

EndFunction

Function AskQuestion(npc as String, prompt as String)
    
    String url = "https://localhost/npc/prompt"
	HttpRequest request = HttpRequest(url)
    request.SetQueryParameter("gameName", "Fallout4")
    request.SetQueryParameter("npcName", npc)
    request.SetQueryParameter("scribe", true)
    request.SetQueryParameter("gpt", true)
    request.SetQueryParameter("question", prompt)
	
    HttpResponse response = request.Get()
    Debug.Notification(response.GetBody())
	
EndFunction

;"C:\Program Files (x86)\Steam\steamapps\common\Fallout 4\Data\Libs\SynthNetVoice.Data.dll"