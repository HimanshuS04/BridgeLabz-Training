using System;
using System.ComponentModel.DataAnnotations;

public enum PriorityLevel
{
    Low = 1,
    Medium = 2,
    High = 3
}
public enum NotificationType
{
    Email,
    SMS,
    App
}
public class Notification
{
    [Required]
    public string Id {get; set;}

    [Required]
    [EmailAddress(ErrorMessage = "Recipient must be valid email format")]
    public string Recipient { get; set; }

    [Required]
    public string Message{get; set;}
    public PriorityLevel Priority {get; set;}
    public NotificationType Type {get; set;}
    public DateTime CreatedTime{get; set;} = DateTime.Now;
    public string Status {get; set;} = "Pending";
}