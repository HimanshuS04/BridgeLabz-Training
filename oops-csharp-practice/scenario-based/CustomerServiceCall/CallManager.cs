using System;
public class CallLogManager
    {
        private CallLog[] callLogs;
        private int count;

        public CallLogManager(int capacity)
        {
            callLogs = new CallLog[capacity];
            count = 0;
        }

        // Add a new call log
        public void AddCallLog(CallLog log)
        {
            if (count >= callLogs.Length)
            {
                Console.WriteLine("Call log storage is full.");
                return;
            }

            callLogs[count++] = log;
        }

        // Search logs by keyword in message
        public void SearchByKeyword(string keyword)
        {
            Console.WriteLine($"\n--- Search Results for \"{keyword}\" ---");

            for (int i = 0; i < count; i++)
            {
                if (callLogs[i].Message.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(callLogs[i]);
                }
            }
        }

        // Filter logs by time range
        public void FilterByTime(DateTime start, DateTime end)
        {
            Console.WriteLine($"\n--- Logs from {start} to {end} ---");

            for (int i = 0; i < count; i++)
            {
                DateTime time = callLogs[i].Timestamp;
                if (time >= start && time <= end)
                {
                    Console.WriteLine(callLogs[i]);
                }
            }
        }
    }