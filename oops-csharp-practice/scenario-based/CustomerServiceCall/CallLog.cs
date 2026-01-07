using System;
public class CallLog
    {
        public string PhoneNumber { get; private set; }
        public string Message { get; private set; }
        public DateTime Timestamp { get; private set; }

        public CallLog(string phoneNumber, string message, DateTime timestamp)
        {
            PhoneNumber = phoneNumber;
            Message = message;
            Timestamp = timestamp;
        }

        // Override ToString()
        public override string ToString()
        {
            return $"[{Timestamp}] {PhoneNumber} : {Message}";
        }
    }