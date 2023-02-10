namespace fingerprint_service;

public class VerifyRequest
{

    public string SampleBase64 { get; set; } = string.Empty;

    public string CandidateBase64 { get; set; } = string.Empty;

    public string SampleDPI { get; set; } = string.Empty;

    public string CandidateDPI { get; set; } = string.Empty;

    public string ScannerName { get; set; } = string.Empty;
}


public class VerifyResponse
{
    public string result { get; set; } = string.Empty;

    public string status { get; set; } = string.Empty;

    public string error { get; set; } = string.Empty;

    public string probability { get; set; } = string.Empty;

    public string weight { get; set; } = string.Empty;
}
