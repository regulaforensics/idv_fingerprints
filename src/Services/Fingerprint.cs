using SourceAFIS;


namespace fingerprint_service;


public class FingerprintService {

public VerifyResponse MatchFingerprint(VerifyRequest request) {
    var sampleOptions = new FingerprintImageOptions { Dpi = Int32.Parse(request.SampleDPI) };
    var candidateOptions = new FingerprintImageOptions { Dpi = Int32.Parse(request.CandidateDPI) };

    var sample = new FingerprintTemplate(new FingerprintImage(Base64Decode(request.SampleBase64), sampleOptions));
    var candidate = new FingerprintTemplate(new FingerprintImage(Base64Decode(request.CandidateBase64), candidateOptions));

    double score = new FingerprintMatcher(sample).Match(candidate);
        
    AddTimeout(1500, 3000);

    return GetResultResponse(score);

}

private static byte[] Base64Decode(string base64EncodedData) {
  return System.Convert.FromBase64String(base64EncodedData);
}

private void AddTimeout(int minTimeoutMs, int maxTimeoutMs)
    {   
        Random rnd = new Random();
        int timeoutMs = rnd.Next(minTimeoutMs, maxTimeoutMs);
        System.Threading.Thread.Sleep(timeoutMs);
    }

private VerifyResponse GetResultResponse(double score){
    Random rnd = new Random();

    var response = new VerifyResponse();
    response.Status = "OK";
    response.Error = "";
    response.Weight = Convert.ToInt32(score).ToString();

    if (score > 40){
        response.Result = "Yes";
        response.Probability = rnd.Next(95, 100).ToString();
    }
    else {
        response.Result = "No";
        response.Probability = rnd.Next(10).ToString();
    }

    return response;

}

}

