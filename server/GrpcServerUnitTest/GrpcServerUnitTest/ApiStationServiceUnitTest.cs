using Moq;
using grpc_server.Services;
using grpc_server.Repositories.Interface;
using Microsoft.Extensions.Logging;
using grpc_server;
using Grpc.Core.Testing;

namespace GrpcServerUnitTest;

public class GrpcServerUnitTest()
{
    private ApiStationService _apiStationService;
    private Mock<IUserRepository> _userRepository;
    private Mock<ILogger<ApiStationService>> _logger;

    [SetUp]
    public void Setup()
    {
        _userRepository = new Mock<IUserRepository>();
        _logger = new Mock<ILogger<ApiStationService>>();
        _apiStationService = new ApiStationService(_logger.Object, _userRepository.Object);
    }

    [Test]
    public void TestPing()
    {
        // Arrange
        var serverCallContext = TestServerCallContext.Create(
            method: "Ping",
            host: "",
            deadline: DateTime.UtcNow.AddMinutes(30),
            requestHeaders: [],
            cancellationToken: CancellationToken.None,
            peer: "localhost",
            authContext: null,
            contextPropagationToken: null,
            writeHeadersFunc: null,
            writeOptionsGetter: null,
            writeOptionsSetter: null
        );

        // Act
        var response = _apiStationService.Ping(new PingRequest { }, serverCallContext).Result;

        // Assert
        Assert.That(response.Message, Is.EqualTo("Pong"));
    }
}