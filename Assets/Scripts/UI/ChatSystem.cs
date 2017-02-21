using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSystem : MonoBehaviour {

    public List<string> chatHistory = new List<string>();

    private string currenMessage = string.Empty;

    private void OnGUI()
    {
        GUILayout.BeginHorizontal(GUILayout.Width(400));
        currenMessage = GUILayout.TextField(currenMessage);
        if (GUILayout.Button("Send"))
        {
            if (!string.IsNullOrEmpty(currenMessage.Trim()))
            {
                //networkView.RPC("ChatMessage", RPCMode.AllBuffered, new object[] { currenMessage });
                currenMessage = string.Empty;
            }
        }
        GUILayout.EndHorizontal();

        foreach (string s in chatHistory)
        {
            GUILayout.Label(s);
        }
    }

    [RPC]
    public void ChatMessage(string message)
    {
        chatHistory.Add(message);
    }
}
