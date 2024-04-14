using System;
using System.Collections.Generic;

namespace DotNetTemplate.Infrastructure.Logging;
public class LogModel
{
    public DateTime? Timestamp { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public TimeSpan? ResponseTimeInMilliseconds { get; set; }
    public RequestModel? Request { get; set; }
    public ResponseModel? Response { get; set; }
    // Add more properties as needed to track additional information
}

public class RequestModel
{
    public string? Url { get; set; }
    public string? Method { get; set; }
    public string? Protocol { get; set; }
    public string? IpAddress { get; set; }
    // public string? Method { get; set; }
    public IDictionary<string, string>? Headers { get; set; }
    public IDictionary<string, string>? QueryParameters { get; set; }
    public IDictionary<string, string>? Body { get; set; }
    // public string? Body { get; set; }
    // Add more properties as needed to track additional information
}

public class ResponseModel
{
    public int? StatusCode { get; set; }
    public IDictionary<string, string>? Headers { get; set; }
    // public IDictionary<string, string>? Body { get; set; }
    public string? Body { get; set; }
    // Add more properties as needed to track additional information
}

