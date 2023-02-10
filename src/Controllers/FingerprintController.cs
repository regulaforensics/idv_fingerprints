using Microsoft.AspNetCore.Mvc;

namespace fingerprint_service.Controllers;

[ApiController]
public class FingerprintController : ControllerBase
{

    private readonly ILogger<FingerprintController> _logger;

    public FingerprintController(ILogger<FingerprintController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/verify")]
    public VerifyResponse Verify(VerifyRequest request)
    {
      return new FingerprintService().MatchFingerprint(request);
    }

}
