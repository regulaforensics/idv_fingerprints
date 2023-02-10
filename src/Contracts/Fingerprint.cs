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
    public string Result { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Error { get; set; } = string.Empty;

    public string Probability { get; set; } = string.Empty;

    public string Weight { get; set; } = string.Empty;
}
