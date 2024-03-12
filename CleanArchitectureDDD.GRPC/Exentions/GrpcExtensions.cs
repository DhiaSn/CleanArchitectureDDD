using Google.Protobuf.WellKnownTypes;

namespace CleanArchitectureDDD.gRPC.Exentions
{
    public static class GrpcExtensions
    {
        public static Timestamp ToGrpcTimestamp(this DateTime dateTime)
        {
            return Timestamp.FromDateTime(dateTime.ToUniversalTime());
        }
    }
}
