using System;
using System.Collections.Generic;

namespace P03Problem03
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> chatLog = new List<string>();
            string input = Console.ReadLine();
            while (!input.Equals("end"))
            {
                string command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                string message = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                int getIndex = -1;
                switch (command)
                {
                    case "Chat":
                        chatLog.Add(message);
                        break;
                    case "Delete":
                        if (!chatLog.Contains(message))
                        {
                            continue;
                        }
                         getIndex = chatLog.FindIndex(x => x.Contains(message));
                        chatLog.RemoveAt(getIndex);
                        break;
                    case "Edit":
                        if (!chatLog.Contains(message))
                        {
                            continue;
                        }
                        string editedVersion = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];
                        getIndex = chatLog.FindIndex(x => x.Contains(message));
                        chatLog.RemoveAt(getIndex);
                        chatLog.Insert(getIndex, editedVersion);
                        break;
                    case "Pin":
                        if (!chatLog.Contains(message))
                        {
                            continue;
                        }
                        getIndex = chatLog.FindIndex(x => x.Contains(message));
                        chatLog.RemoveAt(getIndex);
                        chatLog.Add(message);
                        break;
                    case "Spam":
                        string[] spamMessages = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 1; i < spamMessages.Length; i++)
                        {
                            chatLog.Add(spamMessages[i]);
                        }

                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }


            Console.WriteLine(String.Join(Environment.NewLine, chatLog));
        }
    }
}
