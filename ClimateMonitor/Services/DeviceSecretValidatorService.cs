using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace ClimateMonitor.Services;

public class DeviceSecretValidatorService
{
    private const string VERSION_REGEX = "^(0|[1-9]\\d*)\\.(0|[1-9]\\d*)\\.(0|[1-9]\\d*)(?:-((?:0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\\.(?:0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\\+([0-9a-zA-Z-]+(?:\\.[0-9a-zA-Z-]+)*))?$";
    private static readonly ISet<string> ValidSecrets = new HashSet<string>
    {
        "secret-ABC-123-XYZ-001",
        "secret-ABC-123-XYZ-002",
        "secret-ABC-123-XYZ-003"
    };

    public bool ValidateDeviceSecret(string deviceSecret) 
        => ValidSecrets.Contains(deviceSecret);

    public bool ValidateFirmwareVersion(string version) =>
        Regex.IsMatch(version, VERSION_REGEX);
}
