using Grpc.Core;
using grpc_server.Repositories.Interface;

namespace grpc_server.Services
{
    public class ApiStationService : ApiStation.ApiStationBase
    {
        private readonly ILogger<ApiStationService> _logger;
        private readonly IUserRepository _userRepository;
        public ApiStationService(ILogger<ApiStationService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public override async Task<PingResponse> Ping(PingRequest request, ServerCallContext context)
        {
            return await Task.FromResult(new PingResponse { Message = "Pong" });
        }
    }
}
